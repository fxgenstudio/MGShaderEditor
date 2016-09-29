using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MGShaderEditor.Controls
{
  public partial class SlideCtrl : UserControl
  {
    #region -- Fields --
    private float m_fMin;
    private float m_fMax;
    private float m_fStep;
    private float m_fPos;
    private float m_fArrowInc;
    bool m_bValueChanging;

    private Rectangle m_rcLeftArrow, m_rcRightArrow;
    private Point m_startMousePos;
    private float m_fStartValue;

    private StringFormat m_format;
    private TextBox m_textBox;

    private Timer m_timer;

    #endregion

    #region -- Properties --
    public float Pos
    {
      get { return m_fPos; }
    }
    #endregion

    #region -- Events --
    public event EventHandler ValueChanging;
    public event EventHandler ValueChanged;
    #endregion

    public SlideCtrl()
    {
      InitializeComponent();

      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.DoubleBuffer, true);
      SetStyle(ControlStyles.ResizeRedraw, true);

      m_timer = new Timer();
      m_timer.Enabled = false;
      m_timer.Interval = 100;
      m_timer.Tick += new EventHandler(Evt_TimerTick);

      m_format = new StringFormat();
      m_format.Trimming = StringTrimming.EllipsisWord;
      m_format.Alignment = StringAlignment.Center;

      m_textBox = new TextBox();

      m_fPos = 0.0f;
      Text = "Value";

      //SetRange(0.0f, 1.0f, 0.05f);
      SetRange(0.0f, 0.0f, 0.001f);
    }

    public void SetPos(float _fPos, bool _bNotify = true)
    {
      bool emit = _bNotify && m_fPos != _fPos;
      m_fPos = _fPos;
      if (emit && ValueChanged != null)
        ValueChanged(this, EventArgs.Empty);
    }

    public void SetRange(float _fMin, float _fMax, float _fStep)
    {
      m_fMin  = _fMin;
      m_fMax  = _fMax;
      m_fStep = _fStep;
    }
    public bool IsUnlimited() { return !(m_fMin < m_fMax); }

    protected override void OnPaint(PaintEventArgs e)
    {
      //base.OnPaint(e);

      //Pen pen = new Pen(Color.Gray);
      //UIRenderUtil.DrawRoundRectangle(e.Graphics, ClientRectangle, pen, 8);

      SolidBrush brushBack = new SolidBrush(Color.Gray);
      SolidBrush brush = new SolidBrush(Color.DarkGray);

      if (!IsUnlimited())
      {
        float x = (m_fPos-m_fMin) * (float)ClientSize.Width / (m_fMax - m_fMin);

        e.Graphics.FillRectangle(brushBack, ClientRectangle);
        e.Graphics.FillRectangle(brush, 0, 0, x, ClientSize.Height);
      }
      else
      {
        e.Graphics.FillRectangle(brushBack, ClientRectangle);
        //ControlPaint.DrawScrollButton(e.Graphics, ClientRectangle, ScrollButton.Left, ButtonState.Normal);

        Point[] pts = new Point[3];
        int size = ClientSize.Height;
        //Left Arrow
        pts[0].X = 0;       pts[0].Y = size/2;
        pts[1].X = size;    pts[1].Y = 0;
        pts[2].X = size;    pts[2].Y = size;

        e.Graphics.FillPolygon(brush, pts);

        m_rcLeftArrow.X = pts[0].X;
        m_rcLeftArrow.Y = pts[1].Y;
        m_rcLeftArrow.Width = pts[1].X - pts[0].X;
        m_rcLeftArrow.Height = pts[2].Y - pts[1].Y;

        //Right Arrow
        int x = Width - size;
        pts[0].X = x+size; pts[0].Y = size / 2;
        pts[1].X = x; pts[1].Y = 0;
        pts[2].X = x; pts[2].Y = size;

        e.Graphics.FillPolygon(brush, pts);

        m_rcRightArrow.X = pts[1].X;
        m_rcRightArrow.Y = pts[1].Y;
        m_rcRightArrow.Width = pts[0].X - pts[1].X;
        m_rcRightArrow.Height = pts[2].Y - pts[1].Y;

      }

      string str;
      str = string.Format("{0} :{1}", Text, m_fPos.ToString("0.0000"));

      e.Graphics.DrawString(str, this.Font, SystemBrushes.ControlText, ClientRectangle, m_format);

    }
    protected override bool ProcessKeyPreview(ref Message m)
    {
      if (m.Msg == 0x0100)  //WM_KEYDOWN
      {
        if ((int)m.WParam == 0x0D)  //VK_RETURN
        {
          float fVal;
          if (float.TryParse(m_textBox.Text, out fVal))
            SetPos(fVal, true);
          m_textBox.Visible = false;
          return true;
        }
        else if ((int)m.WParam == 0x1B)  //VK_ESCAPE
        {
          m_textBox.Visible = false;
          return true;
        }

      }

      return false;
    }

    private void Evt_MouseMove(object sender, MouseEventArgs e)
    {
      

      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        if (!IsUnlimited())
        {
          Cursor.Current = Cursors.NoMoveHoriz;

          float fRanged = (m_fMax - m_fMin) * (1.0f / m_fStep);
          float p = (float)Math.Floor((float)e.X * fRanged / (float)Width);
          p *= m_fStep;
          p += m_fMin;

          p = Math.Max(p, m_fMin);
          p = Math.Min(p, m_fMax);
          //SetPos(p, true);
          m_fPos = p;
          m_bValueChanging = true;
          if (ValueChanging != null)
            ValueChanging(this, EventArgs.Empty);

          Refresh();
        }
        else //unlimited, not ranged
        {
          if (!m_rcRightArrow.Contains(e.Location)
            && !m_rcLeftArrow.Contains(e.Location))
          {
            Cursor.Current = Cursors.NoMoveHoriz;

            int offset = e.Location.X - m_startMousePos.X;
            float p = m_fStartValue + ((float)offset * m_fStep);
            //SetPos(p, true);
            //ValueChanged(this, EventArgs.Empty);
            m_fPos = p;
            m_bValueChanging = true;
            if (ValueChanging != null)
              ValueChanging(this, EventArgs.Empty);

            Refresh();
          }
        }
      }

    }
    private void Evt_MouseDown(object sender, MouseEventArgs e)
    {
      float p;
      if (m_rcRightArrow.Contains(e.Location))
      {
        m_fArrowInc = +m_fStep;
        p = m_fPos + m_fStep;
        SetPos(p, true);
        Refresh();
        m_timer.Start();
      }
      else if (m_rcLeftArrow.Contains(e.Location))
      {
        m_fArrowInc = -m_fStep;
        p = m_fPos-m_fStep;
        SetPos(p, true);
        Refresh();
        m_timer.Start();
      }
      m_startMousePos = e.Location;
      m_fStartValue = m_fPos;
    }
    private void Evt_MouseUp(object sender, MouseEventArgs e)
    {
      m_timer.Stop();

      if (m_bValueChanging)
      {
        if (ValueChanged != null)
          ValueChanged(this, EventArgs.Empty);

        m_bValueChanging = false;
      }
    }
    private void Evt_MouseDblClick(object sender, MouseEventArgs e)
    {
      if (!m_rcRightArrow.Contains(e.Location)
        && !m_rcLeftArrow.Contains(e.Location)
        )
      {
        m_textBox.Location = ClientRectangle.Location;
        m_textBox.Size = ClientRectangle.Size;
        m_textBox.Visible = true;
        m_textBox.Parent = this;
        m_textBox.Text = m_fPos.ToString();
        m_textBox.Focus();
      }
    }
    private void Evt_TimerTick(object sender, EventArgs e)
    {
      //m_fPos += m_fArrowInc;
      //Refresh();
    }

  }
}
