using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TNT_Paint
{
    public partial class FormChinhSuaAnh : Form
    {
        public static FormChinhSuaAnh instanceFormCSA;
        public FormChinhSuaAnh()
        {
            instanceFormCSA = this;
            InitializeComponent();
        }
        
        

        private void FormChinhSuaAnh_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Form1.instance.pb_mainScreen.Image;
            
        }
    }
}
