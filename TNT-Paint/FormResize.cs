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
    public partial class FormResize : Form
    {
        public float ratio = 1.0f;
        public FormResize()
        {
            InitializeComponent();
        }

        private void FormResize_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.instance.pb_mainScreen.Width.ToString();
            textBox2.Text = Form1.instance.pb_mainScreen.Height.ToString();
            ratio = Form1.instance.pb_mainScreen.Width / Form1.instance.pb_mainScreen.Height;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int width = Int32.Parse(textBox1.Text);
                int height = Int32.Parse(textBox2.Text);
                Form1.instance.pb_mainScreen.Width = width;
                Form1.instance.pb_mainScreen.Height = height;
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập kích thước hợp lệ!", "Resize");
                return;
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    int width = Int32.Parse(textBox1.Text);
                    textBox2.Text = (width / ratio).ToString();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập kích thước hợp lệ!", "Resize");
                    return;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    int height = Int32.Parse(textBox2.Text);
                    textBox1.Text = (height * ratio).ToString();
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập kích thước hợp lệ!", "Resize");
                    return;
                }
            }
        }
    }
}
