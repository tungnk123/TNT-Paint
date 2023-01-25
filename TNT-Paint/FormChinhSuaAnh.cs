using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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
        public Image imageFormPb_mainscreen = Form1.instance.pb_mainScreen.Image;
        public FormChinhSuaAnh()
        {
            //Form1.instance.Visible = false;
            instanceFormCSA = this;
            InitializeComponent();
            trackBar1.SetRange(0, 30);
            trackBar2.SetRange(-100, 100);

        }

        private void FormChinhSuaAnh_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = imageFormPb_mainscreen;


        }

        #region Events scroll
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = trackBar1.Value;

            pictureBox1.Image = AdjustBrightness(imageFormPb_mainscreen, value / 10);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float value = trackBar2.Value;
            pictureBox1.Image = AdjustSaturation(imageFormPb_mainscreen, value / 10);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float value = trackBar3.Value;
            pictureBox1.Image = AdjustContrast(imageFormPb_mainscreen, value);
        }
        #endregion
        #region Code thay đổi brightness, saturation, contrast, gray ...
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
        public static Bitmap AdjustContrast(Image Image, float Value)
        {
            Value = (100.0f + Value) / 100.0f;
            Value *= Value;
            Bitmap NewBitmap = (Bitmap)Image.Clone();
            BitmapData data = NewBitmap.LockBits(
                new Rectangle(0, 0, NewBitmap.Width, NewBitmap.Height),
                ImageLockMode.ReadWrite,
                NewBitmap.PixelFormat);
            int Height = NewBitmap.Height;
            int Width = NewBitmap.Width;

            unsafe
            {
                for (int y = 0; y < Height; ++y)
                {
                    byte* row = (byte*)data.Scan0 + (y * data.Stride);
                    int columnOffset = 0;
                    for (int x = 0; x < Width; ++x)
                    {
                        byte B = row[columnOffset];
                        byte G = row[columnOffset + 1];
                        byte R = row[columnOffset + 2];

                        float Red = R / 255.0f;
                        float Green = G / 255.0f;
                        float Blue = B / 255.0f;
                        Red = (((Red - 0.5f) * Value) + 0.5f) * 255.0f;
                        Green = (((Green - 0.5f) * Value) + 0.5f) * 255.0f;
                        Blue = (((Blue - 0.5f) * Value) + 0.5f) * 255.0f;

                        int iR = (int)Red;
                        iR = iR > 255 ? 255 : iR;
                        iR = iR < 0 ? 0 : iR;
                        int iG = (int)Green;
                        iG = iG > 255 ? 255 : iG;
                        iG = iG < 0 ? 0 : iG;
                        int iB = (int)Blue;
                        iB = iB > 255 ? 255 : iB;
                        iB = iB < 0 ? 0 : iB;

                        row[columnOffset] = (byte)iB;
                        row[columnOffset + 1] = (byte)iG;
                        row[columnOffset + 2] = (byte)iR;

                        columnOffset += 4;
                    }
                }
            }

            NewBitmap.UnlockBits(data);

            return NewBitmap;
        }
        public Bitmap MakeGrayscale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                   new float[] {.3f, .3f, .3f, 0, 0},
                   new float[] {.59f, .59f, .59f, 0, 0},
                   new float[] {.11f, .11f, .11f, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {0, 0, 0, 0, 1}
               });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
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
                trackBar3.Value = 0;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = MakeGrayscale(imageFormPb_mainscreen);
        }


        #endregion

        
    }
}
