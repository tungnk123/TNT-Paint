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
    public partial class FormStockImages : Form
    {
        public FormStockImages()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Form1.instance.g.Clear(Color.White);
                int index = listView1.SelectedItems[0].Index;
                Image image = listView1.SelectedItems[0].ImageList.Images[index];
                Form1.instance.g.DrawImage(image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y, 
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
            }
            this.Close();
        }
    }
}
