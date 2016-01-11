namespace MGShaderEditor
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
      this.loadToolStripMenuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buildShaderF5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripComboBoxModel = new System.Windows.Forms.ToolStripComboBox();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.panelTextEditor = new System.Windows.Forms.Panel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageTexSlots = new System.Windows.Forms.TabPage();
      this.textureSlotsUserControl1 = new MGShaderEditor.TextureSlotsUserControl();
      this.tabPageHelp = new System.Windows.Forms.TabPage();
      this.webBrowserHelp = new System.Windows.Forms.WebBrowser();
      this._outputWindow = new System.Windows.Forms.TextBox();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPageTexSlots.SuspendLayout();
      this.tabPageHelp.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.buildToolStripMenuItem,
            this.toolStripComboBoxModel,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(888, 27);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItemNew,
            this.loadToolStripMenuItemLoad,
            this.saveToolStripMenuItemSave,
            this.saveAsToolStripMenuItemSaveAs,
            this.toolStripSeparator1,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItemExit});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // newToolStripMenuItemNew
      // 
      this.newToolStripMenuItemNew.Name = "newToolStripMenuItemNew";
      this.newToolStripMenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItemNew.Size = new System.Drawing.Size(152, 22);
      this.newToolStripMenuItemNew.Text = "New";
      this.newToolStripMenuItemNew.Click += new System.EventHandler(this.newToolStripMenuItemNew_Click);
      // 
      // loadToolStripMenuItemLoad
      // 
      this.loadToolStripMenuItemLoad.Name = "loadToolStripMenuItemLoad";
      this.loadToolStripMenuItemLoad.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
      this.loadToolStripMenuItemLoad.Size = new System.Drawing.Size(152, 22);
      this.loadToolStripMenuItemLoad.Text = "Load...";
      this.loadToolStripMenuItemLoad.Click += new System.EventHandler(this.loadToolStripMenuItemLoad_Click);
      // 
      // saveToolStripMenuItemSave
      // 
      this.saveToolStripMenuItemSave.Name = "saveToolStripMenuItemSave";
      this.saveToolStripMenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItemSave.Size = new System.Drawing.Size(152, 22);
      this.saveToolStripMenuItemSave.Text = "Save";
      this.saveToolStripMenuItemSave.Click += new System.EventHandler(this.saveToolStripMenuItemSave_Click);
      // 
      // saveAsToolStripMenuItemSaveAs
      // 
      this.saveAsToolStripMenuItemSaveAs.Name = "saveAsToolStripMenuItemSaveAs";
      this.saveAsToolStripMenuItemSaveAs.Size = new System.Drawing.Size(152, 22);
      this.saveAsToolStripMenuItemSaveAs.Text = "Save as...";
      this.saveAsToolStripMenuItemSaveAs.Click += new System.EventHandler(this.saveAsToolStripMenuItemSaveAs_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
      // 
      // recentFilesToolStripMenuItem
      // 
      this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
      this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.recentFilesToolStripMenuItem.Text = "Recent Files";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
      // 
      // exitToolStripMenuItemExit
      // 
      this.exitToolStripMenuItemExit.Name = "exitToolStripMenuItemExit";
      this.exitToolStripMenuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItemExit.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItemExit.Text = "Exit";
      this.exitToolStripMenuItemExit.Click += new System.EventHandler(this.Evt_Exit);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // findToolStripMenuItem
      // 
      this.findToolStripMenuItem.Name = "findToolStripMenuItem";
      this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
      this.findToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.findToolStripMenuItem.Text = "Find...";
      this.findToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
      // 
      // replaceToolStripMenuItem
      // 
      this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
      this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
      this.replaceToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.replaceToolStripMenuItem.Text = "Replace...";
      this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
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
      this.aboutToolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
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
      this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
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
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageTexSlots);
      this.tabControl1.Controls.Add(this.tabPageHelp);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(234, 293);
      this.tabControl1.TabIndex = 1;
      // 
      // tabPageTexSlots
      // 
      this.tabPageTexSlots.Controls.Add(this.textureSlotsUserControl1);
      this.tabPageTexSlots.Location = new System.Drawing.Point(4, 22);
      this.tabPageTexSlots.Name = "tabPageTexSlots";
      this.tabPageTexSlots.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageTexSlots.Size = new System.Drawing.Size(226, 267);
      this.tabPageTexSlots.TabIndex = 0;
      this.tabPageTexSlots.Text = "Textures";
      this.tabPageTexSlots.UseVisualStyleBackColor = true;
      // 
      // textureSlotsUserControl1
      // 
      this.textureSlotsUserControl1.AutoScroll = true;
      this.textureSlotsUserControl1.AutoScrollMinSize = new System.Drawing.Size(0, 880);
      this.textureSlotsUserControl1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.textureSlotsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textureSlotsUserControl1.Game1 = null;
      this.textureSlotsUserControl1.Location = new System.Drawing.Point(3, 3);
      this.textureSlotsUserControl1.Name = "textureSlotsUserControl1";
      this.textureSlotsUserControl1.Size = new System.Drawing.Size(220, 261);
      this.textureSlotsUserControl1.TabIndex = 0;
      // 
      // tabPageHelp
      // 
      this.tabPageHelp.Controls.Add(this.webBrowserHelp);
      this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
      this.tabPageHelp.Name = "tabPageHelp";
      this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageHelp.Size = new System.Drawing.Size(226, 267);
      this.tabPageHelp.TabIndex = 1;
      this.tabPageHelp.Text = "HLSL Help";
      this.tabPageHelp.UseVisualStyleBackColor = true;
      // 
      // webBrowserHelp
      // 
      this.webBrowserHelp.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowserHelp.Location = new System.Drawing.Point(3, 3);
      this.webBrowserHelp.MinimumSize = new System.Drawing.Size(20, 20);
      this.webBrowserHelp.Name = "webBrowserHelp";
      this.webBrowserHelp.Size = new System.Drawing.Size(220, 261);
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
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(888, 427);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
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
      this.tabControl1.ResumeLayout(false);
      this.tabPageTexSlots.ResumeLayout(false);
      this.tabPageHelp.ResumeLayout(false);
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
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPageTexSlots;
    private System.Windows.Forms.TabPage tabPageHelp;
    private TextureSlotsUserControl textureSlotsUserControl1;
    private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItemLoad;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItemSave;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItemNew;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItemSaveAs;
    private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
  }
}

