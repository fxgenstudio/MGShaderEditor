using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGShaderEditor
{
  public partial class AboutForm : Form
  {
    public AboutForm()
    {
      InitializeComponent();

      labelAbout.Text = labelAbout.Text.Replace("##V##", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
    }
  }
}
