using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using System.IO;
using TwoMGFX;
using NShader;
using NShader.Lexer;
using Primitives3D;

namespace MGShaderEditor
{
  public partial class Form1 : Form, IEffectCompilerOutput
  {
    #region -- Fields --
    Scintilla m_scintillaCtrl;
    Game1 m_game;
    BindingList<GeometricPrimitive> m_primitivesList;
    #endregion

    /// <summary>
    /// Ctor
    /// </summary>
    public Form1()
    {
      InitializeComponent();

      //Init Scintilla Component
      m_scintillaCtrl = new Scintilla();

      m_scintillaCtrl.Parent = panelTextEditor;
      m_scintillaCtrl.Dock = DockStyle.Fill;
      m_scintillaCtrl.Margins[0].Width = 16;
      m_scintillaCtrl.TabWidth = 2;

      // Configuring the default style with properties
      // we have common to every lexer style saves time.
      m_scintillaCtrl.StyleResetDefault();
      m_scintillaCtrl.Styles[Style.Default].Font = "Consolas";
      m_scintillaCtrl.Styles[Style.Default].Size = 10;
      m_scintillaCtrl.Styles[Style.Default].BackColor = Color.FromArgb(219, 227, 227);
      m_scintillaCtrl.StyleClearAll();

      // Configure the lexer styles
      m_scintillaCtrl.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
      m_scintillaCtrl.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
      m_scintillaCtrl.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
      m_scintillaCtrl.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
      m_scintillaCtrl.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
      m_scintillaCtrl.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
      m_scintillaCtrl.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
      m_scintillaCtrl.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
      m_scintillaCtrl.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
      m_scintillaCtrl.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
      m_scintillaCtrl.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
      m_scintillaCtrl.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
      m_scintillaCtrl.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

      m_scintillaCtrl.Lexer = Lexer.Cpp;

      //Create keywords for HLSL
      StringBuilder sb = new StringBuilder();
      var map = new EnumMap<ShaderToken>();
      map.Load("HLSLKeywords.map");
      foreach (var kw in map)
      {
        var str = kw.Key + " ";

        if (str[0] == ':')
          str = str.Substring(1);

        sb.Append(str);
      }
      m_scintillaCtrl.SetKeywords(0, sb.ToString());


    }

    /// <summary>
    /// Form Loaded
    /// </summary>
    private void Evt_Loaded(object sender, EventArgs e)
    {
      //Create MonoGame Wnd for 3D display
      // Can't change parent windows !?
      m_game = new Game1();

      m_game.IsMouseVisible = true;
      m_game.Window.AllowUserResizing = false;
      m_game.Window.AllowAltF4 = false;

      m_game.RunOneFrame();

      //Create Primitives List
      var gd = m_game.GraphicsDevice;

      m_primitivesList = new BindingList<GeometricPrimitive>();
      m_primitivesList.Add(new CubePrimitive(gd));
      m_primitivesList.Add(new SpherePrimitive(gd));
      m_primitivesList.Add(new CylinderPrimitive(gd));
      m_primitivesList.Add(new TorusPrimitive(gd));
      m_primitivesList.Add(new TeapotPrimitive(gd));

      toolStripComboBoxModel.ComboBox.DataSource = m_primitivesList;

      //IDLE event for 3D Drawing
      Application.Idle += Application_Idle;

      //Start Default effect
      var stream = File.OpenText("SimpleColor.fx");
      var shader = stream.ReadToEnd();
      m_scintillaCtrl.Text = shader;
      stream.Close();

      DoBuild(shader);

      //Help
      webBrowserHelp.Navigate(Path.Combine(Environment.CurrentDirectory, "HLSL_Help.html"));

    }

    /// <summary>
    /// Application IDLE
    /// </summary>
    private void Application_Idle(object sender, EventArgs e)
    {
      m_game.RunOneFrame();
      Invalidate();
    }

    /// <summary>
    /// Ask for BuildShader...
    /// </summary>
    private void buildShaderToolStripMenuItem_Click(object sender, EventArgs e)
    {
      DoBuild(m_scintillaCtrl.Text);
    }

    /// <summary>
    /// Selected Model Changed from ComboBox
    /// </summary>
    private void Evt_ModelSelIndexChanged(object sender, EventArgs e)
    {
      var prim = toolStripComboBoxModel.SelectedItem as GeometricPrimitive;
      m_game.CurPrimitive = prim;
    }

    /// <summary>
    /// Display About Box
    /// </summary>
    private void aboutToolStripMenuItemAbout_Click(object sender, EventArgs e)
    {
      FormAbout about = new FormAbout();
      about.Owner = this;
      about.ShowDialog();
    }

    /// <summary>
    /// Exit application
    /// </summary>
    private void Evt_Exit(object sender, EventArgs e)
    {
      Close();
    }

    #region -- HLSL Builder Methods  --
    bool DoBuild(string commands)
    {
      OutputClear();

      var options = new Options();
      // Parse the MGFX file expanding includes, macros, and returning the techniques.
      ShaderInfo shaderInfo;
      try
      {
        options.Debug = true;
        options.Profile = ShaderProfile.DirectX_11;
        options.SourceFile = string.Empty;
        options.OutputFile = string.Empty;

        shaderInfo = ShaderInfo.FromString(commands, "\\", options, this);

      }
      catch (Exception ex)
      {
        OutputAppend(ex.Message);
        OutputAppend("Failed to parse !");
        return false;
      }

      // Create the effect object.
      EffectObject effect;
      var shaderErrorsAndWarnings = string.Empty;
      try
      {
        effect = EffectObject.CompileEffect(shaderInfo, out shaderErrorsAndWarnings);

        if (!string.IsNullOrEmpty(shaderErrorsAndWarnings))
          OutputAppend(shaderErrorsAndWarnings);
      }
      catch (ShaderCompilerException)
      {
        // Write the compiler errors and warnings and let the user know what happened.
        OutputAppend(shaderErrorsAndWarnings);
        OutputAppend("Failed to compile !");
        return false;
      }
      catch (Exception ex)
      {
        // First write all the compiler errors and warnings.
        if (!string.IsNullOrEmpty(shaderErrorsAndWarnings))
          OutputAppend(shaderErrorsAndWarnings);

        // If we have an exception message then write that.
        if (!string.IsNullOrEmpty(ex.Message))
          OutputAppend(ex.Message);

        // Let the user know what happened.
        OutputAppend("Unexpected error compiling !");
        return false;
      }

      OutputAppend("Shader successed Compiled !");

      //Create Effect for Game View
      using (MemoryStream stream = new MemoryStream())
      {
        BinaryWriter bw = new BinaryWriter(stream);
        effect.Write(bw, options);

        byte[] bytecode = stream.ToArray();
        m_game.SetEffectBytesCode(bytecode);
      }

      return true;
    }
    public void WriteWarning(string file, int line, int column, string message)
    {
      OutputAppend(string.Format("Warning: ({0},{1}): {2}", line, column, message));
    }
    public void WriteError(string file, int line, int column, string message)
    {
      OutputAppend(string.Format("Warning: ({0},{1}): {2}", line, column, message));
    }
    void OutputClear()
    {
      _outputWindow.Clear();
    }
    void OutputAppend(string text)
    {
      if (text == null)
        return;

      // We need to append newlines.
      var line = string.Format("{0} {1}{2}", DateTime.Now.ToLongTimeString(), text, Environment.NewLine);

      // Write the output... safely if needed.
      if (InvokeRequired)
        _outputWindow.Invoke(new Action<string>(_outputWindow.AppendText), new object[] { line });
      else
        _outputWindow.AppendText(line);
    }
    #endregion





  }


}
