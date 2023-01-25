using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TNT_Paint
{
    public partial class FormChinhSuaAnh : Form
    {
        public static FormChinhSuaAnh instanceFormCSA;
        public const float rwgt = 0.3086f;
        public const float gwgt = 0.6094f;
        public const float bwgt = 0.0820f;
        private static ImageAttributes imageAttributes = new ImageAttributes();
        private static ColorMatrix colorMatrix = new ColorMatrix();
        public FormChinhSuaAnh()
        {
            Form1.instance.Visible = false;
            instanceFormCSA = this;
            InitializeComponent();
            trackBar1.SetRange(0, 30);
            trackBar2.SetRange(-100, 100);

        }
        
        private void FormChinhSuaAnh_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Form1.instance.pb_mainScreen.Image;
            
        }

        #region Events scroll
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = trackBar1.Value;

            pictureBox1.Image = AdjustBrightness(pictureBox1.Image, value / 10);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float value = trackBar2.Value;
            pictureBox1.Image = AdjustSaturation(pictureBox1.Image, value / 10);
        }
        #endregion
        #region Code thay đổi brightness và saturation
        private static Bitmap AdjustBrightness(Image image, float brightness)
        {
            // Make the ColorMatrix.
            float b = brightness;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
            new float[] {b, 0, 0, 0, 0},
            new float[] {0, b, 0, 0, 0},
            new float[] {0, 0, b, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            // Draw the image onto the new bitmap while applying
            // the new ColorMatrix.
            Point[] points =
            {
        new Point(0, 0),
        new Point(image.Width, 0),
        new Point(0, image.Height),
    };
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            // Make the result bitmap.
            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            // Return the result.
            return bm;
        }
        private static Bitmap AdjustSaturation(Image image, float saturation)
        {

            Bitmap TempBitmap = (Bitmap)image;

            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);

            Graphics NewGraphics = Graphics.FromImage(NewBitmap);

            saturation = (float)saturation + 255 / 255.0f;
            float rWeight = 0.3086f;
            float gWeight = 0.6094f;
            float bWeight = 0.0820f;

            float a = (1.0f - saturation) * rWeight + saturation;
            float b = (1.0f - saturation) * rWeight;
            float c = (1.0f - saturation) * rWeight;
            float d = (1.0f - saturation) * gWeight;
            float e = (1.0f - saturation) * gWeight + saturation;
            float f = (1.0f - saturation) * gWeight;
            float g = (1.0f - saturation) * bWeight;
            float h = (1.0f - saturation) * bWeight;
            float i = (1.0f - saturation) * bWeight + saturation;

            float[][] FloatColorMatrix = {
                new float[] {a,  b,  c,  0, 0},
                new float[] {d,  e,  f,  0, 0},
                new float[] {g,  h,  i,  0, 0},
                new float[] {0,  0,  0,  1, 0},
                new float[] {0, 0, 0, 0, 1}
            };
            ColorMatrix NewColorMatrix = new ColorMatrix(FloatColorMatrix);

            ImageAttributes Attributes = new ImageAttributes();

            Attributes.SetColorMatrix(NewColorMatrix);

            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);

            Attributes.Dispose();

            NewGraphics.Dispose();

            return NewBitmap;
        }


        #endregion

        #region Events các button
        private void button1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = Form1.instance.pb_mainScreen.Image;
                trackBar1.Value = 15;
                trackBar2.Value = 0;
            }
        }
        #endregion
    }
}
