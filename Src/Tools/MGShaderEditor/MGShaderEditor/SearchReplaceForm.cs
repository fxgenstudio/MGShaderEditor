/// <summary>
/// Original Code from mroshaw
///    https://github.com/mroshaw/ScintillaFindReplace
/// </summary>


using ScintillaNET;
using System;
using System.Windows.Forms;

namespace MGShaderEditor
{
  public partial class SearchReplaceForm : Form
  {

    public SearchReplaceForm()
    {
      InitializeComponent();
      // Initialise the SearchFlags
      _findSearchFlags = new SearchFlags();
      _replaceSearchFlags = new SearchFlags();
      _findSearchFlags = SearchFlags.None;
      _replaceSearchFlags = SearchFlags.None;
    }


    private void EvtShown(object sender, EventArgs e)
    {

      if (tabControlFindReplace.SelectedIndex == 0 )
      {
        textBoxFind.Focus();
      }
      else if (tabControlFindReplace.SelectedIndex == 1)
      {
        textBoxFindRep.Focus();
        ActiveControl = textBoxFindRep;
      }

    }

    private void EvtfindText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        SetFindSearchFlags();
        var text = textBoxFind.Text;
        FindNext(text, _findSearchFlags);
      }

    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData==Keys.Escape)
      {
        this.Hide();
        return true;
      }

      return base.ProcessCmdKey(ref msg, keyData);
    }


    #region Class Def

    // Pointer to the Scintilla control to apply actions to
    private Scintilla _scintilla;

    // Search Flags for Find and for Replace
    private SearchFlags _findSearchFlags;
    private SearchFlags _replaceSearchFlags;

  

    /// <summary>
    ///     Changes focus of the actions to the specified Scintilla control
    /// </summary>
    /// <param name="scintilla"></param>
    public void SetTarget(Scintilla scintilla)
    {
      _scintilla = scintilla;
    }

    /// <summary>
    ///     Inits the 'Find' dialog for the specified Scintilla control
    /// </summary>
    /// <param name="scintilla"></param>
    public void SetFind(Scintilla scintilla)
    {
      tabControlFindReplace.SelectTab(0);

      if (scintilla.SelectedText.Length>0)
        textBoxFind.Text = scintilla.SelectedText;

      _scintilla = scintilla;
    }

    /// <summary>
    ///     /// Inits the 'Replace' dialog for the specified Scintilla control
    /// </summary>
    /// <param name="scintilla"></param>
    public void SetReplace(Scintilla scintilla)
    {
      tabControlFindReplace.SelectTab(1);

      if (scintilla.SelectedText.Length > 0)
        textBoxFindRep.Text = scintilla.SelectedText;

      _scintilla = scintilla;
    }

    #endregion

    #region Control Handlers

    /// <summary>
    ///     Prevents the form from being destroyed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FindReplace_FormClosing(object sender, FormClosingEventArgs e)
    {
      Hide();
      e.Cancel = true;
    }

    /// <summary>
    ///     Handles the 'Find Previous' button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonFindPrev_Click(object sender, EventArgs e)
    {
      SetFindSearchFlags();
      var text = textBoxFind.Text;
      FindPrevious(text, _findSearchFlags);
    }

    /// <summary>
    ///     Handles the 'Find Next' button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonFindNext_Click(object sender, EventArgs e)
    {
      SetFindSearchFlags();
      var text = textBoxFind.Text;
      FindNext(text, _findSearchFlags);
    }

    /// <summary>
    ///     Handles the Replace Next button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonReplaceNext_Click(object sender, EventArgs e)
    {
      SetReplaceSearchFlags();
      ReplaceNext(textBoxFindRep.Text, textBoxReplace.Text);
    }

    /// <summary>
    ///     Handles with Replace All button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonReplaceAll_Click(object sender, EventArgs e)
    {
      // Set the replace Search Flags
      SetReplaceSearchFlags();
      // Record current position and anchor
      var currentPos = _scintilla.CurrentPosition;
      var currentAnchorPos = _scintilla.AnchorPosition;
      // Start search at the beginning of the control text
      _scintilla.CurrentPosition = 0;
      _scintilla.AnchorPosition = 0;
      // Call Replace All
      ReplaceAll(textBoxFindRep.Text, textBoxReplace.Text);
      // Restore the position and anchor
      _scintilla.CurrentPosition = currentPos;
      _scintilla.AnchorPosition = currentAnchorPos;
    }

    #endregion

    #region Text find and replace

    /// <summary>
    ///     Finds the next occurnce of the text in the active Scintilla control
    /// </summary>
    /// <param name="text"></param>
    /// <param name="searchFlags"></param>
    /// <returns></returns>
    public int FindNext(string text, SearchFlags searchFlags)
    {
      _scintilla.SearchFlags = searchFlags;
      _scintilla.TargetStart = Math.Max(_scintilla.CurrentPosition, _scintilla.AnchorPosition);
      _scintilla.TargetEnd = _scintilla.TextLength;

      var pos = _scintilla.SearchInTarget(text);
      if (pos >= 0)
        _scintilla.SetSel(_scintilla.TargetStart, _scintilla.TargetEnd);

      return pos;
    }

    /// <summary>
    ///     Finds the previous occurence of the text in the active Scintilla control
    /// </summary>
    /// <param name="text"></param>
    /// <param name="searchFlags"></param>
    /// <returns></returns>
    public int FindPrevious(string text, SearchFlags searchFlags)
    {
      _scintilla.SearchFlags = searchFlags;
      _scintilla.TargetStart = Math.Min(_scintilla.CurrentPosition, _scintilla.AnchorPosition);
      _scintilla.TargetEnd = 0;

      var pos = _scintilla.SearchInTarget(text);
      if (pos >= 0)
        _scintilla.SetSel(_scintilla.TargetStart, _scintilla.TargetEnd);

      return pos;
    }

    /// <summary>
    ///     Replaces the text with text specified
    /// </summary>
    /// <param name="findText"></param>
    /// <param name="replaceText"></param>
    /// <returns></returns>
    private int ReplaceNext(string findText, string replaceText)
    {
      // Find the text and, if found, replace the selection
      var pos = FindNext(findText, _replaceSearchFlags);
      if (pos >= 0)
        _scintilla.ReplaceSelection(replaceText);
      return pos;
    }

    /// <summary>
    ///     Replaces all occurences of text with text specified
    /// </summary>
    /// <param name="findText"></param>
    /// <param name="replaceText"></param>
    private void ReplaceAll(string findText, string replaceText)
    {
      var pos = 0;
      // Iterate until text is no longer found
      while (pos >= 0)
      {
        pos = ReplaceNext(findText, replaceText);
      }
    }

    #endregion

    #region UI helpers

    /// <summary>
    ///     Set the Find search flags based on checked options
    /// </summary>
    private void SetFindSearchFlags()
    {
      if (checkBoxMatchCase.Checked)
        _findSearchFlags |= SearchFlags.MatchCase;
      if (checkBoxRegEx.Checked)
        _findSearchFlags |= SearchFlags.Regex;
      if (checkBoxWholeWord.Checked)
        _findSearchFlags |= SearchFlags.WholeWord;
      if (checkBoxWordStart.Checked)
        _findSearchFlags |= SearchFlags.WordStart;
    }

    /// <summary>
    ///     Set the Replace search flags based on checked options
    /// </summary>
    private void SetReplaceSearchFlags()
    {
      if (checkBoxMatchCaseRep.Checked)
        _replaceSearchFlags |= SearchFlags.MatchCase;
      if (checkBoxRegExRep.Checked)
        _replaceSearchFlags |= SearchFlags.Regex;
      if (checkBoxWholeWordRep.Checked)
        _replaceSearchFlags |= SearchFlags.WholeWord;
      if (checkBoxWordStartRep.Checked)
        _replaceSearchFlags |= SearchFlags.WordStart;
    }

    #endregion

  }
}
