namespace MGShaderEditor
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.toolStripComboBoxModel = new System.Windows.Forms.ToolStripComboBox();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.panelTextEditor = new System.Windows.Forms.Panel();
      this.webBrowserHelp = new System.Windows.Forms.WebBrowser();
      this._outputWindow = new System.Windows.Forms.TextBox();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
      this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buildShaderF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.toolStripComboBoxModel,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(888, 27);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // toolStripComboBoxModel
      // 
      this.toolStripComboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.toolStripComboBoxModel.Name = "toolStripComboBoxModel";
      this.toolStripComboBoxModel.Size = new System.Drawing.Size(256, 23);
      this.toolStripComboBoxModel.ToolTipText = "3D Primitives";
      this.toolStripComboBoxModel.SelectedIndexChanged += new System.EventHandler(this.Evt_ModelSelIndexChanged);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItemAbout});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // aboutToolStripMenuItemAbout
      // 
      this.aboutToolStripMenuItemAbout.Name = "aboutToolStripMenuItemAbout";
      this.aboutToolStripMenuItemAbout.Size = new System.Drawing.Size(152, 22);
      this.aboutToolStripMenuItemAbout.Text = "About";
      this.aboutToolStripMenuItemAbout.Click += new System.EventHandler(this.aboutToolStripMenuItemAbout_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 27);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this._outputWindow);
      this.splitContainer1.Size = new System.Drawing.Size(888, 400);
      this.splitContainer1.SplitterDistance = 293;
      this.splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.panelTextEditor);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.webBrowserHelp);
      this.splitContainer2.Size = new System.Drawing.Size(888, 293);
      this.splitContainer2.SplitterDistance = 650;
      this.splitContainer2.TabIndex = 0;
      // 
      // panelTextEditor
      // 
      this.panelTextEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelTextEditor.Location = new System.Drawing.Point(0, 0);
      this.panelTextEditor.Name = "panelTextEditor";
      this.panelTextEditor.Size = new System.Drawing.Size(650, 293);
      this.panelTextEditor.TabIndex = 0;
      // 
      // webBrowserHelp
      // 
      this.webBrowserHelp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowserHelp.Location = new System.Drawing.Point(0, 0);
      this.webBrowserHelp.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowserHelp.Name = "webBrowserHelp";
      this.webBrowserHelp.Size = new System.Drawing.Size(234, 293);
      this.webBrowserHelp.TabIndex = 0;
      // 
      // _outputWindow
      // 
      this._outputWindow.AcceptsReturn = true;
      this._outputWindow.BackColor = System.Drawing.SystemColors.WindowFrame;
      this._outputWindow.Dock = System.Windows.Forms.DockStyle.Fill;
      this._outputWindow.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._outputWindow.ForeColor = System.Drawing.Color.Wheat;
      this._outputWindow.Location = new System.Drawing.Point(0, 0);
      this._outputWindow.Multiline = true;
      this._outputWindow.Name = "_outputWindow";
      this._outputWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this._outputWindow.Size = new System.Drawing.Size(888, 103);
      this._outputWindow.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItemExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // exitToolStripMenuItemExit
      // 
      this.exitToolStripMenuItemExit.Name = "exitToolStripMenuItemExit";
      this.exitToolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItemExit.Text = "Exit";
      this.exitToolStripMenuItemExit.Click += new System.EventHandler(this.Evt_Exit);
      // 
      // buildToolStripMenuItem
      // 
      this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildShaderF5ToolStripMenuItem});
      this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
      this.buildToolStripMenuItem.Size = new System.Drawing.Size(46, 23);
      this.buildToolStripMenuItem.Text = "Build";
      // 
      // buildShaderF5ToolStripMenuItem
      // 
      this.buildShaderF5ToolStripMenuItem.Image = global::MGShaderEditor.Properties.Resources.servicerunning;
      this.buildShaderF5ToolStripMenuItem.Name = "buildShaderF5ToolStripMenuItem";
      this.buildShaderF5ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.buildShaderF5ToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
      this.buildShaderF5ToolStripMenuItem.Text = "Build Shader";
      this.buildShaderF5ToolStripMenuItem.Click += new System.EventHandler(this.buildShaderToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(888, 427);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "MGShaderEditor";
      this.Load += new System.EventHandler(this.Evt_Loaded);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox _outputWindow;
    private System.Windows.Forms.ToolStripComboBox toolStripComboBoxModel;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.WebBrowser webBrowserHelp;
    private System.Windows.Forms.Panel panelTextEditor;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItemAbout;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemExit;
    private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem buildShaderF5ToolStripMenuItem;
  }
}

