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
    public partial class Form1 : Form
    {
        Graphics g; // graphics from main screen
        Bitmap bm;
        Pen p; // main pen
        Pen eraser;
        Point px, py;
        int SelectedMode;
        bool AllowPaint;

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
            AllowPaint = true;
            px = e.Location;
        }

        private void pb_mainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowPaint)
            {
                if(SelectedMode == 1)
                {
                    py = e.Location;
                    g.DrawLine(p, px, py);
                    px = py;
                }
                if(SelectedMode == 2)
                {
                    py = e.Location;
                    g.DrawLine(eraser, px, py);
                    px = py;
                }
            }
            pb_mainScreen.Refresh();
        }

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
        }

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pb_mainScreen.Image = bm;
            p = new Pen(Color.Black, 1);
            eraser = new Pen(Color.White, 20);
            SelectedMode = 1;
            // Khởi tạo ban đầu
        }
    }
}
