namespace MGShaderEditor
{
  partial class SearchReplaceForm
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
      this.labelFindRep = new System.Windows.Forms.Label();
      this.tabPageFind = new System.Windows.Forms.TabPage();
      this.checkBoxWordStart = new System.Windows.Forms.CheckBox();
      this.checkBoxWholeWord = new System.Windows.Forms.CheckBox();
      this.checkBoxRegEx = new System.Windows.Forms.CheckBox();
      this.checkBoxMatchCase = new System.Windows.Forms.CheckBox();
      this.buttonFindPrev = new System.Windows.Forms.Button();
      this.buttonFindNext = new System.Windows.Forms.Button();
      this.textBoxFind = new System.Windows.Forms.TextBox();
      this.labelFind = new System.Windows.Forms.Label();
      this.checkBoxWordStartRep = new System.Windows.Forms.CheckBox();
      this.checkBoxWholeWordRep = new System.Windows.Forms.CheckBox();
      this.checkBoxRegExRep = new System.Windows.Forms.CheckBox();
      this.checkBoxMatchCaseRep = new System.Windows.Forms.CheckBox();
      this.buttonReplaceAll = new System.Windows.Forms.Button();
      this.textBoxReplace = new System.Windows.Forms.TextBox();
      this.labelReplace = new System.Windows.Forms.Label();
      this.buttonReplaceNext = new System.Windows.Forms.Button();
      this.tabPageReplace = new System.Windows.Forms.TabPage();
      this.textBoxFindRep = new System.Windows.Forms.TextBox();
      this.tabControlFindReplace = new System.Windows.Forms.TabControl();
      this.tabPageFind.SuspendLayout();
      this.tabPageReplace.SuspendLayout();
      this.tabControlFindReplace.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelFindRep
      // 
      this.labelFindRep.AutoSize = true;
      this.labelFindRep.Location = new System.Drawing.Point(10, 14);
      this.labelFindRep.Name = "labelFindRep";
      this.labelFindRep.Size = new System.Drawing.Size(30, 13);
      this.labelFindRep.TabIndex = 3;
      this.labelFindRep.Text = "Find:";
      // 
      // tabPageFind
      // 
      this.tabPageFind.Controls.Add(this.checkBoxWordStart);
      this.tabPageFind.Controls.Add(this.checkBoxWholeWord);
      this.tabPageFind.Controls.Add(this.checkBoxRegEx);
      this.tabPageFind.Controls.Add(this.checkBoxMatchCase);
      this.tabPageFind.Controls.Add(this.buttonFindPrev);
      this.tabPageFind.Controls.Add(this.buttonFindNext);
      this.tabPageFind.Controls.Add(this.textBoxFind);
      this.tabPageFind.Controls.Add(this.labelFind);
      this.tabPageFind.Location = new System.Drawing.Point(4, 22);
      this.tabPageFind.Name = "tabPageFind";
      this.tabPageFind.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageFind.Size = new System.Drawing.Size(454, 129);
      this.tabPageFind.TabIndex = 0;
      this.tabPageFind.Text = "Find";
      this.tabPageFind.UseVisualStyleBackColor = true;
      // 
      // checkBoxWordStart
      // 
      this.checkBoxWordStart.AutoSize = true;
      this.checkBoxWordStart.Location = new System.Drawing.Point(193, 64);
      this.checkBoxWordStart.Name = "checkBoxWordStart";
      this.checkBoxWordStart.Size = new System.Drawing.Size(77, 17);
      this.checkBoxWordStart.TabIndex = 6;
      this.checkBoxWordStart.Text = "Word Start";
      this.checkBoxWordStart.UseVisualStyleBackColor = true;
      // 
      // checkBoxWholeWord
      // 
      this.checkBoxWholeWord.AutoSize = true;
      this.checkBoxWholeWord.Location = new System.Drawing.Point(193, 87);
      this.checkBoxWholeWord.Name = "checkBoxWholeWord";
      this.checkBoxWholeWord.Size = new System.Drawing.Size(86, 17);
      this.checkBoxWholeWord.TabIndex = 7;
      this.checkBoxWholeWord.Text = "Whole Word";
      this.checkBoxWholeWord.UseVisualStyleBackColor = true;
      // 
      // checkBoxRegEx
      // 
      this.checkBoxRegEx.AutoSize = true;
      this.checkBoxRegEx.Location = new System.Drawing.Point(66, 87);
      this.checkBoxRegEx.Name = "checkBoxRegEx";
      this.checkBoxRegEx.Size = new System.Drawing.Size(117, 17);
      this.checkBoxRegEx.TabIndex = 5;
      this.checkBoxRegEx.Text = "Regular Expression";
      this.checkBoxRegEx.UseVisualStyleBackColor = true;
      // 
      // checkBoxMatchCase
      // 
      this.checkBoxMatchCase.AutoSize = true;
      this.checkBoxMatchCase.Location = new System.Drawing.Point(66, 64);
      this.checkBoxMatchCase.Name = "checkBoxMatchCase";
      this.checkBoxMatchCase.Size = new System.Drawing.Size(83, 17);
      this.checkBoxMatchCase.TabIndex = 4;
      this.checkBoxMatchCase.Text = "Match Case";
      this.checkBoxMatchCase.UseVisualStyleBackColor = true;
      // 
      // buttonFindPrev
      // 
      this.buttonFindPrev.Location = new System.Drawing.Point(344, 64);
      this.buttonFindPrev.Name = "buttonFindPrev";
      this.buttonFindPrev.Size = new System.Drawing.Size(89, 23);
      this.buttonFindPrev.TabIndex = 3;
      this.buttonFindPrev.Text = "Find Previous";
      this.buttonFindPrev.UseVisualStyleBackColor = true;
      this.buttonFindPrev.Click += new System.EventHandler(this.buttonFindPrev_Click);
      // 
      // buttonFindNext
      // 
      this.buttonFindNext.Location = new System.Drawing.Point(344, 35);
      this.buttonFindNext.Name = "buttonFindNext";
      this.buttonFindNext.Size = new System.Drawing.Size(89, 23);
      this.buttonFindNext.TabIndex = 2;
      this.buttonFindNext.Text = "Find Next";
      this.buttonFindNext.UseVisualStyleBackColor = true;
      this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
      // 
      // textBoxFind
      // 
      this.textBoxFind.Location = new System.Drawing.Point(66, 11);
      this.textBoxFind.Name = "textBoxFind";
      this.textBoxFind.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxFind.Size = new System.Drawing.Size(367, 20);
      this.textBoxFind.TabIndex = 1;
      this.textBoxFind.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EvtfindText_PreviewKeyDown);
      // 
      // labelFind
      // 
      this.labelFind.AutoSize = true;
      this.labelFind.Location = new System.Drawing.Point(10, 14);
      this.labelFind.Name = "labelFind";
      this.labelFind.Size = new System.Drawing.Size(30, 13);
      this.labelFind.TabIndex = 0;
      this.labelFind.Text = "Find:";
      // 
      // checkBoxWordStartRep
      // 
      this.checkBoxWordStartRep.AutoSize = true;
      this.checkBoxWordStartRep.Location = new System.Drawing.Point(193, 64);
      this.checkBoxWordStartRep.Name = "checkBoxWordStartRep";
      this.checkBoxWordStartRep.Size = new System.Drawing.Size(77, 17);
      this.checkBoxWordStartRep.TabIndex = 13;
      this.checkBoxWordStartRep.Text = "Word Start";
      this.checkBoxWordStartRep.UseVisualStyleBackColor = true;
      // 
      // checkBoxWholeWordRep
      // 
      this.checkBoxWholeWordRep.AutoSize = true;
      this.checkBoxWholeWordRep.Location = new System.Drawing.Point(193, 87);
      this.checkBoxWholeWordRep.Name = "checkBoxWholeWordRep";
      this.checkBoxWholeWordRep.Size = new System.Drawing.Size(86, 17);
      this.checkBoxWholeWordRep.TabIndex = 14;
      this.checkBoxWholeWordRep.Text = "Whole Word";
      this.checkBoxWholeWordRep.UseVisualStyleBackColor = true;
      // 
      // checkBoxRegExRep
      // 
      this.checkBoxRegExRep.AutoSize = true;
      this.checkBoxRegExRep.Location = new System.Drawing.Point(66, 87);
      this.checkBoxRegExRep.Name = "checkBoxRegExRep";
      this.checkBoxRegExRep.Size = new System.Drawing.Size(117, 17);
      this.checkBoxRegExRep.TabIndex = 12;
      this.checkBoxRegExRep.Text = "Regular Expression";
      this.checkBoxRegExRep.UseVisualStyleBackColor = true;
      // 
      // checkBoxMatchCaseRep
      // 
      this.checkBoxMatchCaseRep.AutoSize = true;
      this.checkBoxMatchCaseRep.Location = new System.Drawing.Point(66, 64);
      this.checkBoxMatchCaseRep.Name = "checkBoxMatchCaseRep";
      this.checkBoxMatchCaseRep.Size = new System.Drawing.Size(83, 17);
      this.checkBoxMatchCaseRep.TabIndex = 11;
      this.checkBoxMatchCaseRep.Text = "Match Case";
      this.checkBoxMatchCaseRep.UseVisualStyleBackColor = true;
      // 
      // buttonReplaceAll
      // 
      this.buttonReplaceAll.Location = new System.Drawing.Point(344, 93);
      this.buttonReplaceAll.Name = "buttonReplaceAll";
      this.buttonReplaceAll.Size = new System.Drawing.Size(89, 23);
      this.buttonReplaceAll.TabIndex = 15;
      this.buttonReplaceAll.Text = "Replace All";
      this.buttonReplaceAll.UseVisualStyleBackColor = true;
      this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
      // 
      // textBoxReplace
      // 
      this.textBoxReplace.Location = new System.Drawing.Point(66, 37);
      this.textBoxReplace.Name = "textBoxReplace";
      this.textBoxReplace.Size = new System.Drawing.Size(367, 20);
      this.textBoxReplace.TabIndex = 9;
      // 
      // labelReplace
      // 
      this.labelReplace.AutoSize = true;
      this.labelReplace.Location = new System.Drawing.Point(10, 40);
      this.labelReplace.Name = "labelReplace";
      this.labelReplace.Size = new System.Drawing.Size(50, 13);
      this.labelReplace.TabIndex = 6;
      this.labelReplace.Text = "Replace:";
      // 
      // buttonReplaceNext
      // 
      this.buttonReplaceNext.Location = new System.Drawing.Point(344, 64);
      this.buttonReplaceNext.Name = "buttonReplaceNext";
      this.buttonReplaceNext.Size = new System.Drawing.Size(89, 23);
      this.buttonReplaceNext.TabIndex = 10;
      this.buttonReplaceNext.Text = "Replace Next";
      this.buttonReplaceNext.UseVisualStyleBackColor = true;
      this.buttonReplaceNext.Click += new System.EventHandler(this.buttonReplaceNext_Click);
      // 
      // tabPageReplace
      // 
      this.tabPageReplace.Controls.Add(this.checkBoxWordStartRep);
      this.tabPageReplace.Controls.Add(this.checkBoxWholeWordRep);
      this.tabPageReplace.Controls.Add(this.checkBoxRegExRep);
      this.tabPageReplace.Controls.Add(this.checkBoxMatchCaseRep);
      this.tabPageReplace.Controls.Add(this.buttonReplaceAll);
      this.tabPageReplace.Controls.Add(this.textBoxReplace);
      this.tabPageReplace.Controls.Add(this.labelReplace);
      this.tabPageReplace.Controls.Add(this.buttonReplaceNext);
      this.tabPageReplace.Controls.Add(this.textBoxFindRep);
      this.tabPageReplace.Controls.Add(this.labelFindRep);
      this.tabPageReplace.Location = new System.Drawing.Point(4, 22);
      this.tabPageReplace.Name = "tabPageReplace";
      this.tabPageReplace.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageReplace.Size = new System.Drawing.Size(454, 129);
      this.tabPageReplace.TabIndex = 1;
      this.tabPageReplace.Text = "Replace";
      this.tabPageReplace.UseVisualStyleBackColor = true;
      // 
      // textBoxFindRep
      // 
      this.textBoxFindRep.Location = new System.Drawing.Point(66, 11);
      this.textBoxFindRep.Name = "textBoxFindRep";
      this.textBoxFindRep.Size = new System.Drawing.Size(367, 20);
      this.textBoxFindRep.TabIndex = 8;
      // 
      // tabControlFindReplace
      // 
      this.tabControlFindReplace.Controls.Add(this.tabPageFind);
      this.tabControlFindReplace.Controls.Add(this.tabPageReplace);
      this.tabControlFindReplace.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControlFindReplace.Location = new System.Drawing.Point(0, 0);
      this.tabControlFindReplace.Name = "tabControlFindReplace";
      this.tabControlFindReplace.SelectedIndex = 0;
      this.tabControlFindReplace.Size = new System.Drawing.Size(462, 155);
      this.tabControlFindReplace.TabIndex = 1;
      // 
      // SearchReplaceForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(462, 155);
      this.Controls.Add(this.tabControlFindReplace);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchReplaceForm";
      this.Opacity = 0.9D;
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Find & Replace ...";
      this.Shown += new System.EventHandler(this.EvtShown);
      this.tabPageFind.ResumeLayout(false);
      this.tabPageFind.PerformLayout();
      this.tabPageReplace.ResumeLayout(false);
      this.tabPageReplace.PerformLayout();
      this.tabControlFindReplace.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelFindRep;
    private System.Windows.Forms.TabPage tabPageFind;
    private System.Windows.Forms.CheckBox checkBoxWordStart;
    private System.Windows.Forms.CheckBox checkBoxWholeWord;
    private System.Windows.Forms.CheckBox checkBoxRegEx;
    private System.Windows.Forms.CheckBox checkBoxMatchCase;
    private System.Windows.Forms.Button buttonFindPrev;
    private System.Windows.Forms.Button buttonFindNext;
    private System.Windows.Forms.TextBox textBoxFind;
    private System.Windows.Forms.Label labelFind;
    private System.Windows.Forms.CheckBox checkBoxWordStartRep;
    private System.Windows.Forms.CheckBox checkBoxWholeWordRep;
    private System.Windows.Forms.CheckBox checkBoxRegExRep;
    private System.Windows.Forms.CheckBox checkBoxMatchCaseRep;
    private System.Windows.Forms.Button buttonReplaceAll;
    private System.Windows.Forms.TextBox textBoxReplace;
    private System.Windows.Forms.Label labelReplace;
    private System.Windows.Forms.Button buttonReplaceNext;
    private System.Windows.Forms.TabPage tabPageReplace;
    private System.Windows.Forms.TextBox textBoxFindRep;
    private System.Windows.Forms.TabControl tabControlFindReplace;
  }
}