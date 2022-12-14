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
        Graphics g; // đồ hoạ từ màn hình vẽ chính
        Bitmap bm;
        Pen p; // bút vẽ chính
        Pen eraser; // tẩy
        Point px, py;
        int SelectedMode; // mỗi giá trị là mỗi mode vẽ lên màn hình chính
        bool AllowPaint; // nếu là true thì cho phép vẽ lên màn hình chính

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pb_mainScreen.Image = bm;
            p = new Pen(Color.Black, 1);
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

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
        }
    }
}
