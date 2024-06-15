using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;
using TNT_Paint.UserControls;
using System.Threading.Tasks;
using CloudinaryDotNet;
using FacebookWrapper;
using System.Drawing.Imaging;

namespace TNT_Paint
{
    public partial class Form1 : Form
    {
        LoginResult m_LoginResult;
        TransparentRichTextBox textBox1 = new TransparentRichTextBox();
        public Graphics g; // đồ hoạ từ màn hình vẽ chính
        public Bitmap bm;
        Pen p; // bút vẽ chính
        Pen eraser; // tẩy
        Point px, py;
        int SelectedMode; // mỗi giá trị là mỗi mode vẽ lên màn hình chính
        bool AllowPaint; // nếu là true thì cho phép vẽ lên màn hình chính
        bool isPainted = false;
        Color currentColor = Color.Black;
        VeHinh veHinh;
        //
        //
        //
        public bool isDown = false;// biến chỉ ra các dáu chấm thay đổi kích thước có nhấn ko
        public Point oldPoint = new Point();
        public bool isSaved = false;
        public static string path = "";// bien string luu duong dan luu file
        public string tenFileTieuDe = "Untitled";

        public bool isGridLine = false;
        public bool isFullScreen = false;
        //
        public static Form1 instance;

        //stack
        public Stack<Bitmap> UndoStack = new Stack<Bitmap>();
        public Stack<Bitmap> RedoStack = new Stack<Bitmap>();
        //

        //crop variable
        bool isCropping = false;
        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        //
        //
        bool isBold = false;
        bool isItalic = false;
        bool isUnderline = false;

        private float lightLineWidth = 1;
        private float mediumLineWidth = 3;
        private float bigLineWidth = 6;


        public FormWindowState LastWindowState { get; private set; }

        public Form1()
        {
            instance = this;
            InitializeComponent();
            bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pb_mainScreen.Image = bm;
            p = new Pen(Color.Black, lightLineWidth);
            currentBrushSize = lightLineWidth * 3;
            eraser = new Pen(Color.White, currentBrushSize);
            SelectedMode = 1; // chọn bút chì làm mặc định

            // Khởi tạo ban đầu
            veHinh = new VeHinh();
            pb_mainScreen.MouseDown += pb_mainScreen_MouseDown;
            pb_mainScreen.MouseMove += pb_mainScreen_MouseMove;
            pb_mainScreen.MouseUp += pb_mainScreen_MouseUp;
            FormClosing += new FormClosingEventHandler(Form1_Closing);
            timer1.Start();

            Text = "TNT Paint     | " + tenFileTieuDe + " - Paint";
            textBox1.Font = new Font("Arial", 14);
            textBox1.Width = 300;
            textBox1.Height = 100;
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Margin = new Padding(0);
            textBox1.BorderStyle = BorderStyle.Fixed3D;
            textBox1.Visible = false;
            loadcbFont();

            // set back color for button
            // gray
            button22.BackColor = Color.FromArgb(64, 64, 64);
            // sephia
            button21.BackColor = Color.FromArgb(255, 230, 179);
            // fog
            button20.BackColor = Color.FromArgb(192, 192, 192);
            // flash
            button19.BackColor = Color.FromArgb(255, 255, 0);
            // frozen
            button18.BackColor = Color.FromArgb(0, 255, 255);
            //  red scale
            button17.BackColor = Color.FromArgb(255, 0, 0);
            // grammatic
            button16.BackColor = Color.FromArgb(0, 255, 0);
            // kakao
            button15.BackColor = Color.FromArgb(255, 255, 0);
        }



        #region All buttons event

        private void pb_ColorTable_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = setPoint(pb_ColorTable, e.Location);
            pb_currentColor.BackColor = ((Bitmap)(pb_ColorTable.Image)).GetPixel(pt.X, pt.Y);
            currentColor = pb_currentColor.BackColor;
            p.Color = currentColor;
            textBox1.ForeColor = currentColor;
        }
        private void Btn_ColorDialog_Click(object sender, EventArgs e)
        {
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
                p.Color = colorDialog1.Color;
                pb_currentColor.BackColor = colorDialog1.Color;
            }
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            isCropping = false;
            tenFileTieuDe = "Untitled";
            g.Clear(Color.White);
            pb_mainScreen.Refresh();
            pb_mainScreen.Image = bm;// xoa hinh anh dang co o trong pb_mainScreen
            isPainted = false;
        }
        private void Btn_Pencil_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_edit_48, new Size(30, 30));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 1;
            veHinh.inPolygon = false;
        }

        private void Btn_Eraser_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Cursor cursor = new Cursor(TNT_Paint.Properties.Resources.icons8_erase_30.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 2;
            veHinh.inPolygon = false; ;
        }
        private void Btn_ColorPicker_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_color_dropper_48, new Size(30, 30));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 3;
            veHinh.inPolygon = false;
        }
        private void Btn_Fill_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_fill_color_64, new Size(30, 30));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 4;
            veHinh.inPolygon = false;
        }
        private void btn_SmallLine_Click(object sender, EventArgs e)
        {
            isCropping = false;
            p.Width = lightLineWidth;
            currentBrushSize = lightLineWidth * 3;
            eraser = new Pen(Color.White, currentBrushSize);
            button8.BackgroundImage = btn_SmallLine.BackgroundImage;
        }
        private void Btn_MediumLine_Click(object sender, EventArgs e)
        {
            isCropping = false;
            p.Width = mediumLineWidth;
            currentBrushSize = mediumLineWidth * 3;
            eraser = new Pen(Color.White, currentBrushSize);
            button8.BackgroundImage = Btn_MediumLine.BackgroundImage;
        }
        private void Btn_BigLine_Click(object sender, EventArgs e)
        {
            isCropping = false;
            p.Width = bigLineWidth;
            currentBrushSize = bigLineWidth * 3;
            eraser = new Pen(Color.White, currentBrushSize);
            button8.BackgroundImage = Btn_BigLine.BackgroundImage;
        }
        private void Btn_DrawLine_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 5;
            veHinh.inPolygon = false;
        }
        private void Btn_Ellipse_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 6;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRect_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 7;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawTriangle_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 8;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRightTriangle_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 9;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRoundedRectangle_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 10;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawDiamond_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 11;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawPentagon_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 12;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawHexagon_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 13;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawUpArrow_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 14;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawLeftArrow_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 15;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRightArrow_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 16;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawDownArrow_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 17;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawPolygon_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 18;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawFivePointStar_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Default;
            isCropping = false;
            SelectedMode = 19;
            veHinh.inPolygon = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_color_picker_67, new Size(18, 18));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.air_brush, new Size(25, 25));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 21;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_color_picker_67, new Size(18, 18));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 22;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isCropping = false;
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_color_picker_67, new Size(18, 18));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
            SelectedMode = 23;
        }
        private void buttonAddText_Click(object sender, EventArgs e)
        {
            isCropping = false;
            SelectedMode = 24;
            pb_mainScreen.Cursor = System.Windows.Forms.Cursors.IBeam;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(TNT_Paint.Properties.Resources.icons8_edit_48, new Size(30, 30));
            Cursor cursor = new Cursor(bitmap.GetHicon());
            pb_mainScreen.Cursor = cursor;
        }


        #endregion

        #region MainScreen Mouse Event

        private void pb_mainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.Visible == true)
            {
                Brush brush = new SolidBrush(currentColor);
                g.DrawString(textBox1.Text, textBox1.Font, brush, new Point(textBox1.Location.X, textBox1.Location.Y));
                textBox1.Visible = false;
                textBox1.Text = "";
                panelText.Visible = false;
                tabControl.SelectedIndex = 0;
                return;
            }

            //
            //
            if (isCropping)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Cursor = Cursors.Cross;
                    cropX = e.X;
                    cropY = e.Y;
                    cropPen = new Pen(Color.Black, 1);
                    cropPen.DashStyle = DashStyle.DashDotDot;
                }
                pb_mainScreen.Refresh();
                return;
            }
            isPainted = true;
            if (SelectedMode == 3)
            {
                if (pb_mainScreen.Cursor != Cursors.Default)
                {
                    currentColor = ((Bitmap)(pb_mainScreen.Image)).GetPixel(e.X - 10, e.Y + 10);
                    p.Color = currentColor;
                    pb_currentColor.BackColor = currentColor;
                    pb_mainScreen.Cursor = Cursors.Default;
                }

            }
            if (SelectedMode == 24)
            {

                textBox1.Location = new Point(e.X, e.Y);
                pb_mainScreen.Controls.Add(textBox1);
                textBox1.Visible = true;
                panelText.Visible = true;
                tabControl.SelectedIndex = 1;
                textBox1.Select();

            }

            if (SelectedMode == 4)
            {
                Fill(bm, e.X, e.Y, currentColor);
            }
            AllowPaint = true;
            px = e.Location;
            //
            UndoStack.Push((Bitmap)pb_mainScreen.Image.Clone());
            RedoStack.Clear();
            //

        }
        private void pb_mainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCropping)
            {
                if (pb_mainScreen.Image == null)
                    return;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    pb_mainScreen.Refresh();
                    cropWidth = e.X - cropX;
                    cropHeight = e.Y - cropY;
                    pb_mainScreen.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
                }
                return;
            }
            if (AllowPaint)
            {
                py = e.Location;
                if (SelectedMode == 1)
                {
                    g.DrawLine(p, new Point(px.X - 10, px.Y + 10), new Point(py.X - 10, py.Y + 10));
                    px = py;
                }
                if (SelectedMode == 2)
                {
                    g.DrawLine(eraser, px, py);
                    px = py;
                }
                if (SelectedMode == 20)
                {
                    System.Drawing.Image image = TNT_Paint.Properties.Resources.test_black_2;
                    Bitmap coloredBitmap = ChangeBitmapColor(new Bitmap(image), currentColor);
                    Bitmap bitmap = new Bitmap(coloredBitmap, (int)currentBrushSize, (int)currentBrushSize);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size((int)currentBrushSize, (int)currentBrushSize));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 21)
                {
                    System.Drawing.Image image = TNT_Paint.Properties.Resources.Screenshot_2023_02_03_111748;
                    Bitmap coloredBitmap = ChangeBitmapColor(new Bitmap(image), currentColor);
                    Bitmap bitmap = new Bitmap(coloredBitmap, (int)currentBrushSize, (int)currentBrushSize);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size((int)currentBrushSize, (int)currentBrushSize));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 22)
                {
                    System.Drawing.Image image = TNT_Paint.Properties.Resources.test_black;
                    Bitmap coloredBitmap = ChangeBitmapColor(new Bitmap(image), currentColor);
                    Bitmap bitmap = new Bitmap(coloredBitmap, (int)currentBrushSize, (int)currentBrushSize);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size((int)currentBrushSize, (int)currentBrushSize));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 23)
                {
                    System.Drawing.Image image = TNT_Paint.Properties.Resources.brush_pattern_5;
                    Bitmap coloredBitmap = ChangeBitmapColor(new Bitmap(image), currentColor);
                    Bitmap bitmap = new Bitmap(coloredBitmap, (int)currentBrushSize, (int)currentBrushSize);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size((int)currentBrushSize, (int)currentBrushSize));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
            }
            if (!isGridLine)
            {
                pb_mainScreen.Refresh();
            }
            toolStripStatusLabel1.Text = e.X + ", " + e.Y + "px";
            toolStripStatusLabel2.Text = pb_mainScreen.Width + " x " + pb_mainScreen.Height + "px";

        }

        private static Bitmap ChangeBitmapColor(Bitmap bitmap, Color color)
        {
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                float r = color.R / 255f;
                float gC = color.G / 255f;
                float b = color.B / 255f;
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
            new float[] {r, 0, 0, 0, 0},
            new float[] {0, gC, 0, 0, 0},
            new float[] {0, 0, b, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                           0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            }
            return newBitmap;
        }

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
            if (SelectedMode == 5)
            {
                veHinh.DrawLine(p, g, px, py);
            }
            if (SelectedMode == 6)
            {
                veHinh.DrawEllipse(p, g, px, py);
            }
            if (SelectedMode == 7)
            {
                veHinh.DrawRect(p, g, px, py);
            }
            if (SelectedMode == 8)
            {
                veHinh.DrawTriangle(p, g, px, py);
            }
            if (SelectedMode == 9)
            {
                veHinh.DrawRightTriangle(p, g, px, py);
            }
            if (SelectedMode == 10)
            {
                veHinh.DrawRoundedRectangle(p, g, px, py);
            }
            if (SelectedMode == 11)
            {
                veHinh.DrawDiamond(p, g, px, py);
            }
            if (SelectedMode == 12)
            {
                veHinh.DrawPentagon(p, g, px, py);
            }
            if (SelectedMode == 13)
            {
                veHinh.DrawHexagon(p, g, px, py);
            }
            if (SelectedMode == 14)
            {
                veHinh.DrawUpArrow(p, g, px, py);
            }
            if (SelectedMode == 15)
            {
                veHinh.DrawLeftArrow(p, g, px, py);
            }
            if (SelectedMode == 16)
            {
                veHinh.DrawRightArrow(p, g, px, py);
            }
            if (SelectedMode == 17)
            {
                veHinh.DrawDownArrow(p, g, px, py);
            }
            if (SelectedMode == 18)
            {
                veHinh.DrawPolygon(p, g, px, py);
            }
            if (SelectedMode == 19)
            {
                veHinh.DrawFivePointStar(p, g, px, py);
            }

        }

        #endregion

        #region Text Event
        private void cb_Font_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panelText.Visible == false)
            {
                return;
            }
            try
            {
                int i = int.Parse(cb_Size.Text);
                Font font = new Font(cb_Font.Text, i);
                textBox1.SelectionColor = currentColor;
                textBox1.Font = font;

            }
            catch
            {
                MessageBox.Show("Loi font chu");
            }
        }
        private void cb_Size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panelText.Visible == false)
            {
                return;
            }
            try
            {
                int i = int.Parse(cb_Size.Text);
                Font font = new Font(cb_Font.Text, i);
                textBox1.SelectionColor = currentColor;
                textBox1.Font = font;

            }
            catch
            {
                MessageBox.Show("Loi font chu");
            }
        }
        private void tabControl_VisibleChanged(object sender, EventArgs e)
        {
            textBox1.SelectionColor = currentColor;
        }
        private void btn_Bold_Click(object sender, EventArgs e)
        {

            //
            if (isBold == false)
            {
                isBold = true;

                //
                if (isItalic == true)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic);
                    }
                }
                else if (isItalic == false)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold);
                    }
                }
                //
                //isItalic = false;
                //checkBox3.CheckState = CheckState.Unchecked;
                //textBox1.SelectionFont = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold );
            }
            else
            {
                isBold = false;

                if (isItalic == true)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic);
                    }
                }
                else if (isItalic == false)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Regular);
                    }
                }
            }
            //
        }
        private void btn_Italic_Click(object sender, EventArgs e)
        {
            if (isItalic == false)
            {
                isItalic = true;

                //
                if (isBold == true)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic);
                    }
                }
                else if (isBold == false)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic);
                    }
                }
                //
                //isItalic = false;
                //checkBox3.CheckState = CheckState.Unchecked;
                //textBox1.SelectionFont = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold );
            }
            else
            {
                isItalic = false;

                if (isBold == true)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic);
                    }
                }
                else if (isItalic == false)
                {
                    if (isUnderline == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Regular);
                    }
                }
            }
            //
        }
        private void btn_Underline_Click(object sender, EventArgs e)
        {
            if (isUnderline == false)
            {
                isUnderline = true;

                //
                if (isBold == true)
                {
                    if (isItalic == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold | FontStyle.Italic);
                    }
                }
                else if (isBold == false)
                {
                    if (isItalic == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic | FontStyle.Underline);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Underline);
                    }
                }
                //
                //isItalic = false;
                //checkBox3.CheckState = CheckState.Unchecked;
                //textBox1.SelectionFont = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold );
            }
            else
            {
                isUnderline = false;

                if (isBold == true)
                {
                    if (isItalic == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic | FontStyle.Bold);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Bold);
                    }
                }
                else if (isBold == false)
                {
                    if (isItalic == true)
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Italic);
                    }
                    else
                    {
                        textBox1.Font = new Font(cb_Font.Text, Convert.ToInt32(cb_Size.Text), FontStyle.Regular);
                    }
                }
            }
            //
        }


        #endregion

        #region Function
        private void loadcbFont()
        {
            InstalledFontCollection installedFont = new InstalledFontCollection();
            FontFamily[] fontFamilies = installedFont.Families;
            foreach (FontFamily ff in fontFamilies)
            {
                cb_Font.Items.Add(ff.Name);
            }
            cb_Font.Text = textBox1.Font.Name.ToString();
            cb_Size.Text = textBox1.Font.Size.ToString();
        }

        //fill function
        private void Fill(Bitmap bm, int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            if (oldColor.ToArgb() == newColor.ToArgb()) { return; }

            while (pixel.Count > 0)
            {
                Point pt = pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y - 1, oldColor, newColor);
                    validate(bm, pixel, pt.X + 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y + 1, oldColor, newColor);
                }
            }
        }

        private void validate(Bitmap bm, Stack<Point> pixel, int x, int y, Color oldColor, Color newColor)
        {
            Color cx = bm.GetPixel(x, y);

            // Kiểm tra màu sắc và độ trong suốt
            if (IsColorSimilar(cx, oldColor))
            {
                pixel.Push(new Point(x, y));
                bm.SetPixel(x, y, newColor);
            }
        }

        private bool IsColorSimilar(Color c1, Color c2, int tolerance = 50)
        {
            int r1 = c1.R, g1 = c1.G, b1 = c1.B, a1 = c1.A;
            int r2 = c2.R, g2 = c2.G, b2 = c2.B, a2 = c2.A;

            return Math.Abs(r1 - r2) <= tolerance &&
                   Math.Abs(g1 - g2) <= tolerance &&
                   Math.Abs(b1 - b2) <= tolerance &&
                   Math.Abs(a1 - a2) <= tolerance;
        }

        // set point function 
        private Point setPoint(PictureBox pb, Point pt)
        {
            float px = 1f * pb.Image.Width / pb.Width;
            float py = 1f * pb.Image.Height / pb.Height;
            return new Point((int)(pt.X * px), (int)(pt.Y * py));
        }



        // paint function
        private void pb_mainScreen_Paint(object sender, PaintEventArgs e)
        {

            Graphics gx = e.Graphics;
            if (AllowPaint)
            {
                if (SelectedMode == 5)
                {
                    veHinh.DrawLine(p, gx, px, py);
                }
                if (SelectedMode == 6)
                {
                    veHinh.DrawEllipse(p, gx, px, py);
                }
                if (SelectedMode == 7)
                {
                    veHinh.DrawRect(p, gx, px, py);
                }
                if (SelectedMode == 8)
                {
                    veHinh.DrawTriangle(p, gx, px, py);
                }
                if (SelectedMode == 9)
                {
                    veHinh.DrawRightTriangle(p, gx, px, py);
                }
                if (SelectedMode == 10)
                {
                    veHinh.DrawRoundedRectangle(p, gx, px, py);
                }
                if (SelectedMode == 11)
                {
                    veHinh.DrawDiamond(p, gx, px, py);
                }
                if (SelectedMode == 12)
                {
                    veHinh.DrawPentagon(p, gx, px, py);
                }
                if (SelectedMode == 13)
                {
                    veHinh.DrawHexagon(p, gx, px, py);
                }
                if (SelectedMode == 14)
                {
                    veHinh.DrawUpArrow(p, gx, px, py);
                }
                if (SelectedMode == 15)
                {
                    veHinh.DrawLeftArrow(p, gx, px, py);
                }
                if (SelectedMode == 16)
                {
                    veHinh.DrawRightArrow(p, gx, px, py);
                }
                if (SelectedMode == 17)
                {
                    veHinh.DrawDownArrow(p, gx, px, py);
                }
                if (SelectedMode == 18)
                {
                    veHinh.MinhHoaPolygon(p, gx, px, py);
                }
                if (SelectedMode == 19)
                {
                    veHinh.DrawFivePointStar(p, gx, px, py);
                }
            }

        }



        #endregion

        #region Menu events
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isPainted)
            {
                switch (MessageBox.Show("Bạn có muốn lưu file với tên " + tenFileTieuDe + " không", "Thông Báo", MessageBoxButtons.YesNoCancel))
                {
                    // truong hop nguoi dung muon luu anh dang ve lai va open file sau
                    case DialogResult.Yes:
                        {
                            saveToolStripMenuItem_Click(sender, e);
                            tenFileTieuDe = "Untitled";
                            isPainted = false;
                            g.Clear(Color.White);
                            pb_mainScreen.Refresh();
                            pb_mainScreen.Image = bm;
                            this.pb_mainScreen.Width = 870;
                            this.pb_mainScreen.Height = 434;
                            break;
                        }
                    // truong hop nguoi dung khong muon luu anh dang ve ma muon open file luon
                    case DialogResult.No:
                        {
                            tenFileTieuDe = "Untitled";
                            isPainted = false;
                            g.Clear(Color.White);
                            pb_mainScreen.Refresh();
                            pb_mainScreen.Image = bm;
                            this.pb_mainScreen.Width = 870;
                            this.pb_mainScreen.Height = 434;
                            break;
                        }

                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                tenFileTieuDe = "Untitled";
                isPainted = false;
                g.Clear(Color.White);
                pb_mainScreen.Refresh();
                pb_mainScreen.Image = bm;
                this.pb_mainScreen.Width = 870;
                this.pb_mainScreen.Height = 434;
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Trường hợp đã vẽ gì đó lên picturebox
            if (isPainted)
            {
                switch (MessageBox.Show("Bạn có muốn lưu file với tên " + tenFileTieuDe + " không", "Thông Báo", MessageBoxButtons.YesNoCancel))
                {
                    // Trường hợp người dùng muốn lưu ảnh đang vẽ lại và open file sau
                    case DialogResult.Yes:
                        {
                            saveToolStripMenuItem_Click(sender, e);
                            OpenImage();
                            break;
                        }
                    // Trường hợp người dùng không muốn lưu ảnh đang vẽ mà muốn open file luôn
                    case DialogResult.No:
                        {
                            OpenImage();
                            break;
                        }
                    case DialogResult.Cancel:
                        return;
                }
            }
            // Trường hợp chưa vẽ gì lên picturebox
            else
            {
                OpenImage();
            }
        }

        private void OpenImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Open image" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                tenFileTieuDe = openFileDialog.SafeFileName;
                Image img = Image.FromFile(fileName);

                // Tính toán kích thước mới dựa trên tỷ lệ của ảnh gốc và kích thước của pb_mainScreen
                Size newSize = CalculateNewSize(img.Width, img.Height, pb_mainScreen.Width, pb_mainScreen.Height);

                // Tạo bitmap mới với kích thước đã tính toán và vẽ ảnh lên đó
                Bitmap newBm = new Bitmap(newSize.Width, newSize.Height);
                using (Graphics gr = Graphics.FromImage(newBm))
                {
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height));
                }

                // Thay thế bm toàn cục với bitmap mới
                bm = newBm;

                // Thiết lập PictureBox để hiển thị bm mới và thay đổi kích thước của PictureBox
                pb_mainScreen.Size = new Size(newSize.Width, newSize.Height);
                pb_mainScreen.Refresh();
                pb_mainScreen.Image = bm;
                g = Graphics.FromImage(bm);
            }
        }

        private Size CalculateNewSize(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / originalWidth;
            double ratioY = (double)maxHeight / originalHeight;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(originalWidth * ratio);
            int newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // truong hop chua save lan nao 
            if (isSaved == false)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Save image" };
                saveFileDialog.RestoreDirectory = true;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    isSaved = true;
                    path = saveFileDialog.FileName;
                    tenFileTieuDe = Path.GetFileName(saveFileDialog.FileName);
                    pb_mainScreen.Image.Save(path);
                    this.Text = "TNT Paint     | " + tenFileTieuDe + " - Paint";
                }
            }
            // truong hop da save se goi ham saveas
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }



        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSaved)
            {
                pb_mainScreen.Image.Save(path);
                MessageBox.Show("Lưu thành công!", "TNT Paint");

            }
            else
            {
                saveToolStripMenuItem_Click(sender, e);
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            // truong hop khong ve cai gi het
            if (isPainted == false)
            {
                return;
            }
            // truong hop da ve cai gi len picturebox 
            else
            {
                switch (MessageBox.Show("Bạn có muốn lưu file với tên " + tenFileTieuDe + " không", "Thông Báo", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        saveToolStripMenuItem_Click(sender, e);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void magnifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\WINDOWS\system32\Magnify.exe"))
            {
                Process.Start("Magnify.exe");
            }
            else
            {
                MessageBox.Show("Your computer don't have this service. ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Timer ve cac dau cham
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "TNT Paint     | " + tenFileTieuDe + " - Paint";
            panelDauCham1.Location = new Point(this.pb_mainScreen.Width + pb_mainScreen.Location.X, pb_mainScreen.Height / 2 + pb_mainScreen.Location.Y);
            panelDauCham2.Location = new Point(this.pb_mainScreen.Width / 2 + pb_mainScreen.Location.X, pb_mainScreen.Height + pb_mainScreen.Location.Y);
            panelDauCham3.Location = new Point(this.pb_mainScreen.Width + pb_mainScreen.Location.X, pb_mainScreen.Height + pb_mainScreen.Location.Y);
            Graphics g = this.pb_mainScreen.CreateGraphics();
            if (isGridLine)
            {
                PaintGridLines(g);
            }
        }


        #endregion

        #region Events thay đổi vẽ 3 dấu chấm thay đổi kích thước

        private void panelDauCham1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }
        private void panelDauCham1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }


        private void panelDauCham1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                if (oldPoint != e.Location)
                {
                    this.pb_mainScreen.Width = (e.X + panelDauCham1.Location.X - pb_mainScreen.Location.X);
                    Image temp = pb_mainScreen.Image;
                    bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
                    g = Graphics.FromImage(bm);
                    g.Clear(Color.White);
                    g.DrawImage(temp, new Point(0, 0));
                    pb_mainScreen.Image = bm;
                    this.Invalidate();
                }
            }
            oldPoint = e.Location;
        }

        private void panelDauCham2_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
        }

        private void panelDauCham2_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }


        private void panelDauCham2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                if (oldPoint != e.Location)
                {
                    pb_mainScreen.Height = (e.Y + panelDauCham2.Location.Y - pb_mainScreen.Location.Y);
                    Image temp = pb_mainScreen.Image;// nếu để bm thì nó sẽ lấy cái bm cũ chưa thay đoi
                    bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
                    g = Graphics.FromImage(bm);
                    g.Clear(Color.White);
                    g.DrawImage(temp, new Point(0, 0));
                    pb_mainScreen.Image = bm;
                    this.Invalidate();
                }
            }
            oldPoint = e.Location;
        }

        private void panelDauCham3_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;

        }
        private void panelDauCham3_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
        }



        private void panelDauCham3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                if (oldPoint != e.Location)
                {
                    pb_mainScreen.Width = (e.X + panelDauCham1.Location.X - pb_mainScreen.Location.X);
                    pb_mainScreen.Height = (e.Y + panelDauCham2.Location.Y - pb_mainScreen.Location.Y);
                    Image temp = bm;
                    bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
                    g = Graphics.FromImage(bm);
                    g.Clear(Color.White);
                    g.DrawImage(temp, new Point(0, 0));
                    pb_mainScreen.Image = bm;
                    this.Invalidate();
                }
            }
            oldPoint = e.Location;
        }




        #endregion

        #region Zoom in zoom out
        private void zomeInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pb_mainScreen.Width = pb_mainScreen.Width + pb_mainScreen.Width / 3;
            this.pb_mainScreen.Height = pb_mainScreen.Height + pb_mainScreen.Height / 3;
            bm = new Bitmap(bm, pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pb_mainScreen.Image = bm;

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.pb_mainScreen.Width = 870;
            this.pb_mainScreen.Height = 434;
            bm = new Bitmap(bm, pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pb_mainScreen.Image = bm;
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isFullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                WindowState = FormWindowState.Normal;
                isFullScreen = false;
            }
        }

        private void zomeOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pb_mainScreen.Width = pb_mainScreen.Width - pb_mainScreen.Width / 3;
            this.pb_mainScreen.Height = pb_mainScreen.Height - pb_mainScreen.Height / 3;
            bm = new Bitmap(bm, pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pb_mainScreen.Image = bm;
        }




        #endregion

        #region Status bar

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = !statusStrip1.Visible;
        }


        #endregion

        #region GridLines và Ruler

        public void PaintGridLines(Graphics g)
        {
            int column = this.pb_mainScreen.Width / 10;
            int row = pb_mainScreen.Height / 10;
            int x = 0, y = 0;
            Pen p = new Pen(Color.Black) { Width = 1, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };
            for (int i = 0; i < column; i++)
            {
                g.DrawLine(p, x, 0, x, pb_mainScreen.Height);
                x += 10;
            }
            for (int i = 0; i < row; i++)
            {
                g.DrawLine(p, 0, y, pb_mainScreen.Width, y);
                y += 10;
            }

        }

        private void pb_mainScreen_SizeChanged(object sender, EventArgs e)
        {
            Graphics g = this.pb_mainScreen.CreateGraphics();
            if (isGridLine)
            {
                PaintGridLines(g);
            }
        }



        private void gridlinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isGridLine = !isGridLine;
            Graphics g = this.pb_mainScreen.CreateGraphics();
            if (isGridLine)
            {
                PaintGridLines(g);
            }
            this.Invalidate();
        }


        #endregion

        #region Information and About
        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.ShowDialog();
        }



        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }



        #endregion

        #region events và menu tools 
        private void imageEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChinhSuaAnh formChinhSuaAnh = new FormChinhSuaAnh();
            formChinhSuaAnh.ShowDialog();
        }
        private void onlineImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOnlineImage formOnlineImage = new FormOnlineImage();
            formOnlineImage.ShowDialog();
        }
        private void stockImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStockImages stockImages = new FormStockImages();
            stockImages.ShowDialog();
        }


        #endregion

        #region Undo Redo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UndoStack.Count > 0)
            {
                RedoStack.Push((Bitmap)pb_mainScreen.Image.Clone());
                g.DrawImage(UndoStack.Pop(), pb_mainScreen.Location);
                pb_mainScreen.Refresh();

            }
            else
            {
                MessageBox.Show("Nothing to Undo");
            }
        }



        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RedoStack.Count > 0)
            {
                UndoStack.Push((Bitmap)pb_mainScreen.Image.Clone());
                g.DrawImage(RedoStack.Pop(), pb_mainScreen.Location);
                pb_mainScreen.Refresh();

            }
            else
            {
                MessageBox.Show("Nothing to Redo");
            }
        }
        #endregion

        #region Crop + Resize

        private void button12_Click(object sender, EventArgs e)
        {
            pb_mainScreen.Cursor = Cursors.Cross;
            isCropping = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (isCropping)
            {
                Crop();
            }
            isCropping = false;
            pb_mainScreen.Invalidate();
            pb_mainScreen.Cursor = Cursors.Default;
        }


        public void Crop()
        {
            Cursor = Cursors.Default;
            if (cropWidth < 1)
            {
                return;
            }
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap OriginalImage = new Bitmap(pb_mainScreen.Image, pb_mainScreen.Width, pb_mainScreen.Height);
            bm = new Bitmap(cropWidth, cropHeight);
            g = Graphics.FromImage(bm);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
            pb_mainScreen.Width = bm.Width;
            pb_mainScreen.Height = bm.Height;
            pb_mainScreen.Image = bm;
            pb_mainScreen.Invalidate();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormResize formResize = new FormResize();
            formResize.ShowDialog();
        }
        #endregion

        #region Cut Copy Paste Delete
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pb_mainScreen.Image);
            Btn_Clear_Click(sender, e);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pb_mainScreen.Image);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                g.Clear(Color.White);
                g.DrawImage(Clipboard.GetImage(), pb_mainScreen.Location.X, pb_mainScreen.Location.Y, Clipboard.GetImage().Width, Clipboard.GetImage().Height);
            }
            catch
            {
                MessageBox.Show("Nothing to paste");
            }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;


                if (WindowState == FormWindowState.Maximized)
                {
                    Panel_size.Location = new Point(Panel_size.Location.X + 200, Panel_size.Location.Y);
                    groupBox1.Location = new Point(groupBox1.Location.X + 250, groupBox1.Location.Y);
                    gb_Shape.Location = new Point(gb_Shape.Location.X + 300, gb_Shape.Location.Y);
                    pb_ColorTable.Location = new Point(pb_ColorTable.Location.X + 150, pb_ColorTable.Location.Y);
                    pb_currentColor.Location = new Point(pb_currentColor.Location.X + 140, pb_currentColor.Location.Y);
                    pictureBoxCrop.Location = new Point(pictureBoxCrop.Location.X + 100, pictureBoxCrop.Location.Y);
                    pictureBox2.Location = new Point(pictureBox2.Location.X + 100, pictureBox2.Location.Y);
                    button13.Location = new Point(button13.Location.X + 100, button13.Location.Y);
                    button5.Location = new Point(button5.Location.X + 100, button5.Location.Y);
                    button12.Location = new Point(button12.Location.X + 80, button12.Location.Y);
                }
                if (WindowState == FormWindowState.Normal)
                {

                    Panel_size.Location = new Point(Panel_size.Location.X - 200, Panel_size.Location.Y);
                    groupBox1.Location = new Point(groupBox1.Location.X - 250, groupBox1.Location.Y);
                    gb_Shape.Location = new Point(gb_Shape.Location.X - 300, gb_Shape.Location.Y);
                    pb_ColorTable.Location = new Point(pb_ColorTable.Location.X - 150, pb_ColorTable.Location.Y);
                    pb_currentColor.Location = new Point(pb_currentColor.Location.X - 140, pb_currentColor.Location.Y);
                    pictureBoxCrop.Location = new Point(pictureBoxCrop.Location.X - 100, pictureBoxCrop.Location.Y);
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 100, pictureBox2.Location.Y);
                    button13.Location = new Point(button13.Location.X - 100, button13.Location.Y);
                    button5.Location = new Point(button5.Location.X - 100, button5.Location.Y);
                    button12.Location = new Point(button12.Location.X - 80, button12.Location.Y);
                }
            }
        }

        private void ptbSizeDrop_Click(object sender, EventArgs e)
        {
            Panel_size.BringToFront();
            Panel_size.Visible = !Panel_size.Visible;
            toolStripShape.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            pb_ColorTable.BringToFront();
            pb_ColorTable.Visible = !pb_ColorTable.Visible;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            toolStripShape.Visible = !toolStripShape.Visible;
            Panel_size.Visible = false;
        }
        private void imageFromCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCamera form = new FormCamera();
            form.ShowDialog();
        }

        private void genMusicFromTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGemini form = new FormGemini();
            form.ShowDialog();
        }

        private void shareImagesOnFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form1.path == "")
            {
                MessageBox.Show("Bạn phải lưu ảnh trước khi share facebook!");
                return;
            }

            if (m_LoginResult == null)
            {
                if (login())
                {
                    FormFaceBook form1 = new FormFaceBook(m_LoginResult.LoggedInUser);
                    form1.ShowDialog();
                }
                else
                {
                    m_LoginResult = null;
                }
            }
        }
        private bool login()
        {
            try
            {
                m_LoginResult = FacebookService.Login(
              /// (This is Desig Patter's App ID. replace it with your own)
              "823675602636361",
               /// requested permissions:
               "pages_manage_posts",
               "pages_manage_engagement",
               "pages_read_engagement",
               "pages_show_list"
               /// add any relevant permissions
               );

                return true;
            }
            catch
            {
                return false;
            }

        }

        private void pb_currentColor_BackColorChanged(object sender, EventArgs e)
        {
            pb_color2.BackColor = pb_currentColor.BackColor;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pb_ColorTable2.BringToFront();
            pb_ColorTable2.Visible = !pb_ColorTable2.Visible;
        }

        private Image originalImage;
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel_size.Visible = false;
            toolStripShape.Visible = false;
            if (tabControl.SelectedIndex == 2)
            {
                panel8.Visible = true;
                originalImage = pb_mainScreen.Image;
            }
            else
            {
                panel8.Visible = false;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Btn_Clear_Click(sender, e);
        }
        #endregion

        #region Image Editor
        public const float rwgt = 0.3086f;
        public const float gwgt = 0.6094f;
        public const float bwgt = 0.0820f;
        private static ImageAttributes imageAttributes = new ImageAttributes();
        private static ColorMatrix colorMatrix = new ColorMatrix();
        private float currentBrushSize;

        #region Events scroll
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float value = trackBar1.Value / 10.0f;

            pb_mainScreen.Image = AdjustBrightness(originalImage, value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            float value = trackBar2.Value;
            pb_mainScreen.Image = AdjustSaturation(originalImage, value / 10);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            float value = trackBar3.Value;
            pb_mainScreen.Image = AdjustContrast(originalImage, value);
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

            // Draw the image onto the new bitmap while applying the new ColorMatrix.
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
                gr.DrawImage(image, points, rect, GraphicsUnit.Pixel, attributes);
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

        public Bitmap MakeFogScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0.7f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }
        public Bitmap MakeFlashScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{1+0.9f, 0, 0, 0, 0},
            new float[]{0, 1+1.5f, 0, 0, 0},
            new float[]{0, 0, 1+1.3f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }
        public Bitmap MakeFrozenScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{1+0.3f, 0, 0, 0, 0},
            new float[]{0, 1+0f, 0, 0, 0},
            new float[]{0, 0, 1+5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }

        public Bitmap MakeRedScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{.393f, .349f, .272f+1.3f, 0, 0},
            new float[]{.769f, .686f+0.5f, .534f, 0, 0},
            new float[]{.189f+2.3f, .168f, .131f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }

        public Bitmap MakeDramaticScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{.393f, .349f+0.5f, .272f, 0, 0},
            new float[]{.769f+0.3f, .686f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.5f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }

        public Bitmap MakeKakaoScale(Image original)

        {
            Bitmap newBmp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBmp);
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]       // now creating the color matrix object to change the colors or apply  image filter on image
                {
                    new float[]{.393f+0.3f, .349f, .272f, 0, 0},
            new float[]{.769f, .686f+0.2f, .534f, 0, 0},
            new float[]{.189f, .168f, .131f+0.9f, 0, 0},
            new float[]{0, 0, 0, 1, 0},
            new float[]{0, 0, 0, 0, 1}
                });
            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBmp;
        }

        #endregion

        #region Events các button
        private void button2gr_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeGrayscale(pb_mainScreen.Image);
        }

        private void button3se_Click_1(object sender, EventArgs e)
        {

            Bitmap bmp = new Bitmap(pb_mainScreen.Image);

            int width = pb_mainScreen.Image.Width;
            int height = pb_mainScreen.Image.Height;

            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            //load sepia image in picturebox2
            pb_mainScreen.Image = bmp;

        }

        private void button4fo_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeFogScale(pb_mainScreen.Image);
        }

        private void button5fl_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeFlashScale(pb_mainScreen.Image);
        }

        private void button6fr_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeFrozenScale(pb_mainScreen.Image);
        }

        private void button7re_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeRedScale(pb_mainScreen.Image);
        }

        private void button8dr_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeDramaticScale(pb_mainScreen.Image);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel8.Visible = false;
            }
            else
            {
                panel8.Visible = true;
            }
        }

        private void button9ka_Click_1(object sender, EventArgs e)
        {
            pb_mainScreen.Image = MakeKakaoScale(pb_mainScreen.Image);
        }

        #endregion
        #endregion
    }
}
