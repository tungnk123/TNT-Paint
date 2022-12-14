﻿using System;
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
    public partial class Form1 : Form
    {
        Graphics g; // đồ hoạ từ màn hình vẽ chính
        Bitmap bm;
        Pen p; // bút vẽ chính
        Pen eraser; // tẩy
        Point px, py;
        int SelectedMode; // mỗi giá trị là mỗi mode vẽ lên màn hình chính
        bool AllowPaint; // nếu là true thì cho phép vẽ lên màn hình chính
        Color mainColor = Color.Black;

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pb_mainScreen.Image = bm;
            p = new Pen(mainColor, 1);
            eraser = new Pen(Color.White, 20);
            SelectedMode = 1; // chọn bút chì làm mặc định
            // Khởi tạo ban đầu
        }
        private void Btn_Pencil_Click(object sender, EventArgs e)
        {
            SelectedMode = 1;
        }

        private void Btn_Eraser_Click(object sender, EventArgs e)
        {
            SelectedMode = 2;
        }
        private void pb_mainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if(SelectedMode == 3)
            {
                if (pb_mainScreen.Cursor == System.Windows.Forms.Cursors.Hand)
                {
                    mainColor = ((Bitmap)pb_mainScreen.Image).GetPixel(e.X, e.Y);
                    pb_color.BackColor = mainColor;
                    p.Color = mainColor;
                    pb_mainScreen.Cursor = System.Windows.Forms.Cursors.Default;
                    SelectedMode = 1;
                    return;
                }
            }
            if(SelectedMode == 4)
            {
                Fill(bm, e.X, e.Y, mainColor);
            }
            AllowPaint = true;
            px = e.Location;
        }
        private void pb_mainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowPaint)
            {
                if (SelectedMode == 1)
                {
                    py = e.Location;
                    g.DrawLine(p, px, py);
                    px = py;
                }
                if (SelectedMode == 2)
                {
                    py = e.Location;
                    g.DrawLine(eraser, px, py);
                    px = py;
                }
            }
            pb_mainScreen.Refresh();
        }

        private void Btn_ColorPanel_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pb_color.BackColor = colorDialog1.Color;
                mainColor = colorDialog1.Color;
                p.Color = colorDialog1.Color;
            }
        }

        private void Btn_ColorPicker_Click(object sender, EventArgs e)
        {
            SelectedMode = 3;
            pb_mainScreen.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
        }
        private void validate(Bitmap bm, Stack<Point>sp,int x, int y,Color oldColor, Color newColor)
        {
            // hàm thay thế pixel với màu cũ bằng màu mới
            Color cl = bm.GetPixel(x, y);
            if(cl == oldColor)
            {
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y, newColor); 
            }
        }

        private void Btn_Fill_Click(object sender, EventArgs e)
        {
            SelectedMode = 4;
        }

        private void Fill(Bitmap bm,int x, int y, Color newColor)
        {
            Color oldColor = bm.GetPixel(x, y);
            Stack<Point>pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            bm.SetPixel(x, y, newColor);
            if(oldColor == newColor) { return; }

            while(pixel.Count > 0)
            {
                Point pt = pixel.Pop();
                if(pt.X > 0 && pt.Y > 0 && pt.X < bm.Width - 1 && pt.Y < bm.Height - 1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y - 1, oldColor, newColor);
                    validate(bm, pixel, pt.X + 1, pt.Y, oldColor, newColor);
                    validate(bm, pixel, pt.X, pt.Y + 1, oldColor, newColor);
                }
            }
        }
    }
}
