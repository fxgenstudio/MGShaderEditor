using MGShaderEditor.Controls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MGShaderEditor
{
    public class ParamDesc
    {
        public UIbaseParam param;
        public Control control;
    }

    public partial class ShaderParametersUserControl : UserControl
    {
        List<ParamDesc> m_parametersDesc;

        public ShaderParametersUserControl()
        {
            InitializeComponent();

            m_parametersDesc = new List<ParamDesc>();
        }

        public void DisplayParameters(List<UIbaseParam> _parameters)
        {
            SuspendLayout();
            foreach (var pd in m_parametersDesc)
            {
                if (pd.control is SlideCtrl)
                {
                    var slider = pd.control as SlideCtrl;
                    slider.ValueChanged -= Control_ValueChanging;
                    slider.Dispose();
                }
            }
            m_parametersDesc.Clear();
            ResumeLayout();

            int itemY = 0;
            int itemH = 16;
            foreach (var p in _parameters)
            {
                Control control = null;

                if (p is UIFloatParam)
                {
                    var fp = p as UIFloatParam;

                    var slider = new SlideCtrl();
                    slider.Location = new System.Drawing.Point(0, itemY);
                    slider.Height = itemH;
                    slider.SetRange(fp.MinRange, fp.MaxRange, 0.01f);
                    slider.SetPos(fp.Value);
                    slider.Parent = this;
                    slider.Text = p.Name;
                    slider.ValueChanging += Control_ValueChanging;
                    slider.Tag = p;
                    slider.CreateControl();

                    control = slider;
                } else if (p is UITexture2DParam) {

                    var tp = p as UITexture2DParam;

                    var textbox = new TextBox();
                    textbox.Location = new System.Drawing.Point(0, itemY);
                    textbox.Height = itemH;
                    textbox.Parent = this;
                    textbox.Text = tp.Value;
                    textbox.TextChanged += Textbox_TextChanged;
                    textbox.Tag = p;
                    textbox.CreateControl();

                    control = textbox;

                }

                var pd = new ParamDesc();
                pd.param = p;
                pd.control = control;

                itemY += itemH;

            }

        }

        private void Textbox_TextChanged(object sender, System.EventArgs e)
        {
            TextBox tb = sender as TextBox;
            UITexture2DParam p = tb.Tag as UITexture2DParam;
            p.Value = tb.Text;
        }

        private void Control_ValueChanging(object sender, System.EventArgs e)
        {
            SlideCtrl s = sender as SlideCtrl;
            UIFloatParam p = s.Tag as UIFloatParam;
            p.Value = s.Pos;
        }

      


    }
}
