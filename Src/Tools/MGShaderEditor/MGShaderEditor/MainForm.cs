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
using Microsoft.Xna.Framework.Graphics;
using JWC;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;

namespace MGShaderEditor
{
  public partial class MainForm : Form, IEffectCompilerOutput
  {
    #region -- Fields --
    Scintilla m_scintillaCtrl;
    Game1 m_game;
    BindingList<GeometricPrimitive> m_primitivesList;
    string m_strCurrentEffectFile;

    protected MruStripMenu mruMenu;
    static string mruRegKey = "SOFTWARE\\PROCFXGEN\\MGShaderEditor";

    #endregion

    /// <summary>
    /// Ctor
    /// </summary>
    public MainForm()
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

      //MRU
      mruMenu = new MruStripMenuInline(fileToolStripMenuItem, recentFilesToolStripMenuItem, new MruStripMenu.ClickedHandler(OnMruFile), mruRegKey + "\\MRU", 16);
      mruMenu.LoadFromRegistry();
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


      //UI init
      toolStripComboBoxModel.ComboBox.DataSource = m_primitivesList;
      textureSlotsUserControl1.Game1 = m_game;

      //Load default textures
      textureSlotsUserControl1.SetTextureSlot(0, "texture01.jpg");

      //IDLE event for 3D Drawing
      Application.Idle += Application_Idle;

      //Start Default effect
      using (var stream = File.OpenText("SimpleColor.fx"))
      {
        var shader = stream.ReadToEnd();
        m_scintillaCtrl.Text = shader;
        m_scintillaCtrl.SetSavePoint();

        DoBuild(shader);
      }

      //Help
      webBrowserHelp.Navigate(Path.Combine(Environment.CurrentDirectory, "HLSL_Help.html"));
      
      //Test...
      //HighlightWord("float4");
    }

    /// <summary>
    /// Application IDLE
    /// </summary>
    private void Application_Idle(object sender, EventArgs e)
    {
      try
      {
        m_game.RunOneFrame();
      }
      catch (Exception)
      {
      }

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
      AboutForm about = new AboutForm();
      about.Owner = this;
      about.ShowDialog();
    }

    /// <summary>
    /// New FX
    /// </summary>
    private void newToolStripMenuItemNew_Click(object sender, EventArgs e)
    {
      if (m_scintillaCtrl.Modified == true)
      {
        var ret = MessageBox.Show("Save current effect before ?", this.Text, MessageBoxButtons.YesNoCancel);
        if (ret == System.Windows.Forms.DialogResult.Cancel)
          return;

        if (ret == System.Windows.Forms.DialogResult.Yes)
        {
          saveToolStripMenuItemSave_Click(sender, e);
        }
      }

      SetCurrentEffectFileName(null);

      //Reset to default shader
      using (var stream = File.OpenText("SimpleColor.fx"))
      {
        var shader = stream.ReadToEnd();
        m_scintillaCtrl.Text = shader;
        m_scintillaCtrl.SetSavePoint();

        DoBuild(shader);
      }
    }

    private void SetCurrentEffectFileName(string _strFxName)
    {
      m_strCurrentEffectFile = _strFxName;
      Text = string.Format("MGShaderEditor - {0}", m_strCurrentEffectFile);
    }

    /// <summary>
    /// Load .FX
    /// </summary>
    private void loadToolStripMenuItemLoad_Click(object sender, EventArgs e)
    {
      //Show FileDialog
      OpenFileDialog openFileDialog1 = new OpenFileDialog();

      openFileDialog1.Filter = "effect files (*.fx)|*.fx|All files (*.*)|*.*";
      openFileDialog1.RestoreDirectory = true;

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        LoadEffectFile(openFileDialog1.FileName);
      }
    }

    /// <summary>
    /// Load effect from MRU
    /// </summary>
    private void OnMruFile(int number, String filename)
    {
      if (LoadEffectFile(filename) == false)
      {
        mruMenu.RemoveFile(filename);
      }
      else
      {
        mruMenu.SetFirstFile(number);
      }
    }

    /// <summary>
    /// Save .FX
    /// </summary>
    private void saveToolStripMenuItemSave_Click(object sender, EventArgs e)
    {
      //Filename not specified, show save file dialog
      if (string.IsNullOrEmpty(m_strCurrentEffectFile) == true)
      {
        saveAsToolStripMenuItemSaveAs_Click(sender, e);
        return;
      }

      //Save to current filename
      try
      {
        //Save Effect
        using (var stream = File.CreateText(m_strCurrentEffectFile))
        {
          stream.Write(m_scintillaCtrl.Text);
          m_scintillaCtrl.SetSavePoint();
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
      }
    }

    /// <summary>
    /// Save As .FX
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveAsToolStripMenuItemSaveAs_Click(object sender, EventArgs e)
    {
      //Show FileDialog
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();

      saveFileDialog1.Filter = "effect files (*.fx)|*.fx|All files (*.*)|*.*";
      saveFileDialog1.RestoreDirectory = true;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        try
        {
          //Save Effect
          using (var stream = File.CreateText(saveFileDialog1.FileName))
          {
            stream.Write(m_scintillaCtrl.Text);
            m_scintillaCtrl.SetSavePoint();

            SetCurrentEffectFileName(saveFileDialog1.FileName);

            mruMenu.AddFile(saveFileDialog1.FileName);
          }

        }
        catch (Exception ex)
        {
          MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
        }
      }

    }

    /// <summary>
    /// Exit application
    /// </summary>
    private void Evt_Exit(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// App Closing
    /// </summary>
    protected override void OnClosing(CancelEventArgs e)
    {
      mruMenu.SaveToRegistry();

      base.OnClosing(e);
    }

    /// <summary>
    /// Load Effect file
    /// </summary>
    private bool LoadEffectFile(string _strFileName)
    {
      try
      {
        //Load Effect
        using (var stream = File.OpenText(_strFileName))
        {
          var shader = stream.ReadToEnd();
          m_scintillaCtrl.Text = shader;
          m_scintillaCtrl.SetSavePoint();

          SetCurrentEffectFileName(_strFileName);

          DoBuild(shader);

          mruMenu.AddFile(_strFileName);
        }

      }
      catch (Exception ex)
      {
        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        return false;
      }

      return true;
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

        var strpathApp = Path.GetDirectoryName ( Process.GetCurrentProcess().MainModule.FileName );

        shaderInfo = ShaderInfo.FromString(commands, strpathApp, options, this);

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

      var lines = text.Split('\n');

      foreach (var line in lines)
      {
        // We need to append newlines.
        var fullline = string.Format("{0} {1}{2}", DateTime.Now.ToLongTimeString(), line, Environment.NewLine);

        // Write the output... safely if needed.
        if (InvokeRequired)
          _outputWindow.Invoke(new Action<string>(_outputWindow.AppendText), new object[] { fullline });
        else
          _outputWindow.AppendText(fullline);
      }

    }
    #endregion


    #region -- Find and Replace --

    SearchReplaceForm m_searchReplaceFrom = new SearchReplaceForm();

    private void searchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      m_searchReplaceFrom.SetFind(m_scintillaCtrl);
      m_searchReplaceFrom.Show(this);
    }

    private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      m_searchReplaceFrom.SetReplace(m_scintillaCtrl);
      m_searchReplaceFrom.Show(this);
    }

    #endregion


  }


}
