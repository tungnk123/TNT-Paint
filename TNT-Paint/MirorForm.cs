using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TNT_Paint
{
    public partial class MirorForm : Form
    {
        Bitmap bm1, bm2;
        public MirorForm()
        {
            InitializeComponent();
            bm1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bm1 = (Bitmap)pictureBox1.Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string base64 = ConvertBitmapToBase64(bm1);
            bm2 = ConvertBase64ToBitmap(base64);
            pictureBox2.Image = bm2;

        }

        private string ConvertBitmapToBase64(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                byte[] bitmapBytes = ms.ToArray();
                return Convert.ToBase64String(bitmapBytes);
            }
        }

        private Bitmap ConvertBase64ToBitmap(string base64String)
        {
            byte[] bitmapBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(bitmapBytes))
            {
                return new Bitmap(ms);
            }
        }

    }
}
