using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TNT_Paint.UserControls;

namespace TNT_Paint
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            TransparentRichTextBox rtb = new TransparentRichTextBox();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tungnk123/TNT-Paint.git");
        }
    }
}
