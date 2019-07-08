using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Diagnostics;

namespace MGShaderEditor
{
  /// <summary>
  /// UserControl for Textures Slots display and selection
  /// </summary>
  public partial class TextureSlotsUserControl : UserControl
  {
    public const int SlotsCount = 4;

    #region -- Fields --
    Image []m_imagesSlots = new Image[SlotsCount];
    #endregion

    #region -- Properties --
    public Game1 Game1 { get; set; }
    #endregion

    #region -- ctor --
    public TextureSlotsUserControl()
    {
      InitializeComponent();
    }
    #endregion

    #region -- Methods --
    public void SetTextureSlot(int _nSlotIdx, string _strFileName)
    {
      var streamT = File.OpenRead(_strFileName);
      Texture2D tex01 = Texture2D.FromStream(Game1.GraphicsDevice, streamT);
      streamT.Close();

      SetTextureSlot(_nSlotIdx, tex01);
    }
    public void SetTextureSlot(int _nSlotIdx, Texture2D _tex)
    {
      if (_nSlotIdx < 0 || _nSlotIdx >= SlotsCount)
        return;

      MemoryStream mem = new MemoryStream();

      _tex.SaveAsPng(mem, 256, 256);

      m_imagesSlots[_nSlotIdx] = Image.FromStream(mem);

      Game1.SetTextureSlot(_nSlotIdx, _tex);

      Refresh();
    }
    #endregion

    #region -- UI Events --
    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);

      AutoScrollMinSize = new Size(0, Width * SlotsCount);
    }
    protected override void OnDoubleClick(EventArgs e)
    {
        //Get slot idx
        MouseEventArgs evt = e as MouseEventArgs;

        int nSlotIdx = (evt.Y - AutoScrollPosition.Y )/ ClientSize.Width;
        if (nSlotIdx < 0 || nSlotIdx >= SlotsCount)
            return;

        //Show FileDialog
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        openFileDialog1.Filter = "bmp files (*.bmp)|*.bmp|png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 4;
        openFileDialog1.RestoreDirectory = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            try
            {
                SetTextureSlot(nSlotIdx, openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
              MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
    protected override void OnScroll(ScrollEventArgs se)
    {
        base.OnScroll(se);

        Refresh();
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      int w = ClientSize.Width;
      int h = ClientSize.Height;

      e.Graphics.FillRectangle(Brushes.Black, 0,0, w,h);

      //Translate matrix to scrollbar offset
      e.Graphics.TranslateTransform(0, AutoScrollPosition.Y);

      //Draw texture slots
      Rectangle rc = new Rectangle(0,0, w, w);
      SolidBrush brSlotBk = new SolidBrush(Color.Gray);

      rc.Inflate(-4, -4);//For Borders

      for (int i = 0; i < SlotsCount; i++)
      {
        //Slot backgroud
        e.Graphics.FillRectangle(brSlotBk, rc);

        //Texture image
        var img = m_imagesSlots[i];

        if (img != null)
          e.Graphics.DrawImage(img, rc);

        //Display Slot Name
        if (img != null)
          e.Graphics.DrawString(string.Format("Texture Slot {0} {1}x{2}", i, img.Width, img.Height), SystemFonts.DefaultFont, Brushes.White, rc);
        else
          e.Graphics.DrawString(string.Format("Texture Slot {0} ", i), SystemFonts.DefaultFont, Brushes.White, rc);

        rc.Offset(0,w);
      }




    }
    #endregion
  }
}
