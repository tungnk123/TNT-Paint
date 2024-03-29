﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Text;

namespace TNT_Paint
{
    public partial class Form1 : Form
    {
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
            p = new Pen(Color.Black, 1);

            eraser = new Pen(Color.White, 20);
            SelectedMode = 1; // chọn bút chì làm mặc định
            // Khởi tạo ban đầu
            veHinh = new VeHinh();
            pb_mainScreen.MouseDown += pb_mainScreen_MouseDown;
            pb_mainScreen.MouseMove += pb_mainScreen_MouseMove;
            pb_mainScreen.MouseUp += pb_mainScreen_MouseUp;
            pb_mainScreen.Paint += pb_mainScreen_Paint;

            this.FormClosing += new FormClosingEventHandler(Form1_Closing);

            timer1.Start();
            this.Text = "TNT Paint     | " + tenFileTieuDe + " - Paint";


            loadcbFont();
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
            p.Width = 1;
        }
        private void Btn_MediumLine_Click(object sender, EventArgs e)
        {
            isCropping = false;
            p.Width = 3;
        }
        private void Btn_BigLine_Click(object sender, EventArgs e)
        {
            isCropping = false;
            p.Width = 6;
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
            if(textBox1.Visible == true)
            {
                Brush brush = new SolidBrush(currentColor);
                g.DrawString(textBox1.Text, textBox1.Font, brush, new Point(textBox1.Location.X - 3, textBox1.Location.Y + 3));
                textBox1.Visible = false;
                textBox1.Text = "";
                tabControl.Visible = false;
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
            if(SelectedMode == 24)
            {
                textBox1.Location = new Point(e.X, e.Y - 20);
                textBox1.Visible = true;
                pb_mainScreen.Cursor = System.Windows.Forms.Cursors.Default;
                tabControl.Visible = true;
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
                    Image image = TNT_Paint.Properties.Resources.test_black_2;
                    Bitmap bitmap = new Bitmap(image, 10, 10);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);


                    Pen p = new Pen(Color.Red, 3);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size(10, 10));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 20)
                {
                    Image image = TNT_Paint.Properties.Resources.test_black_2;
                    Bitmap bitmap = new Bitmap(image, 10, 10);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);


                    Pen p = new Pen(Color.Red, 3);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size(10, 10));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 21)
                {
                    Image image = TNT_Paint.Properties.Resources.Screenshot_2023_02_03_111748;
                    Bitmap bitmap = new Bitmap(image, 10, 10);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);


                    Pen p = new Pen(Color.Red, 3);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size(10, 10));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 22)
                {
                    Image image = TNT_Paint.Properties.Resources.test_black;
                    Bitmap bitmap = new Bitmap(image, 10, 10);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);


                    Pen p = new Pen(Color.Red, 3);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size(10, 10));
                    graphicsPath.AddRectangle(rectangle);
                    g.FillPath(brush, graphicsPath);
                    px = e.Location;
                }
                if (SelectedMode == 23)
                {
                    Image image = TNT_Paint.Properties.Resources.brush_pattern_5;
                    Bitmap bitmap = new Bitmap(image, 10, 10);
                    Brush brush = new TextureBrush(bitmap, System.Drawing.Drawing2D.WrapMode.Tile);


                    Pen p = new Pen(Color.Red, 3);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    GraphicsPath graphicsPath = new GraphicsPath();
                    Rectangle rectangle = new Rectangle(px, new Size(10, 10));
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
            if(tabControl.Visible == false)
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
            if(tabControl.Visible == false)
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

                if (isBold== true)
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
        private void validate(Bitmap bm, Stack<Point> sp, int x, int y, Color oldColor, Color newColor)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == oldColor)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, newColor);
            }
        }

        private void Fill(Bitmap bm, int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            if (oldColor == newColor) { return; }

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
                switch (MessageBox.Show("Bạn có muốn lưu file với tên "+ tenFileTieuDe + " không", "Thông Báo", MessageBoxButtons.YesNoCancel))
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
            // truong hop da ve gi do len picturebox
            if (isPainted)
            {
                switch (MessageBox.Show("Bạn có muốn lưu file với tên " + tenFileTieuDe + " không", "Thông Báo", MessageBoxButtons.YesNoCancel))
                {
                    // truong hop nguoi dung muon luu anh dang ve lai va open file sau
                    case DialogResult.Yes:
                        {
                            saveToolStripMenuItem_Click(sender, e);
                            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Open image" };
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string fileName = openFileDialog.FileName;
                                Image img = Image.FromFile(fileName);
                                bm = new Bitmap(img, new Size(pb_mainScreen.Width, pb_mainScreen.Height));
                                pb_mainScreen.Refresh();
                                pb_mainScreen.Image = bm;
                                g = Graphics.FromImage(bm);
                            }
                            break;
                        }
                    // truong hop nguoi dung khong muon luu anh dang ve ma muon open file luon
                    case DialogResult.No:
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Open image" };
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string fileName = openFileDialog.FileName;
                                Image img = Image.FromFile(fileName);
                                bm = new Bitmap(img, new Size(pb_mainScreen.Width, pb_mainScreen.Height));
                                pb_mainScreen.Refresh();
                                pb_mainScreen.Image = bm;
                                g = Graphics.FromImage(bm);
                            }

                            break;
                        }

                    case DialogResult.Cancel:
                        return;

                }
            }
            // truong hop chua ve gi len picturebox
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Open image" };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    tenFileTieuDe = openFileDialog.SafeFileName;
                    Image img = Image.FromFile(fileName);
                    bm = new Bitmap(img, new Size(pb_mainScreen.Width, pb_mainScreen.Height));
                    pb_mainScreen.Refresh();
                    pb_mainScreen.Image = bm;
                    g = Graphics.FromImage(bm);
                }
            }

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

                    pb_mainScreen.Image.Save(path);
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
                MessageBox.Show("Your computer don't have this service. ", "Thông báo !", MessageBoxButtons.OK ,MessageBoxIcon.Error);
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
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 100, pictureBox1.Location.Y);
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
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 100, pictureBox1.Location.Y);
                    pictureBox2.Location = new Point(pictureBox2.Location.X - 100, pictureBox2.Location.Y);
                    button13.Location = new Point(button13.Location.X - 100, button13.Location.Y);
                    button5.Location = new Point(button5.Location.X - 100, button5.Location.Y);
                    button12.Location = new Point(button12.Location.X - 80, button12.Location.Y);
                }
            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Btn_Clear_Click(sender, e);
        }
        #endregion
    }
}
