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
        Color currentColor = Color.Black;

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
        #region All buttons event
        private void Btn_Pencil_Click(object sender, EventArgs e)
        {
            SelectedMode = 1;
        }

        private void Btn_Eraser_Click(object sender, EventArgs e)
        {
            SelectedMode = 2;
        }
        private void Btn_ColorPicker_Click(object sender, EventArgs e)
        {
            SelectedMode = 3;
            pb_mainScreen.Cursor = Cursors.Hand;
        }
        private void Btn_ColorDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog1.Color;
                p.Color = colorDialog1.Color;
                pb_currentColor.BackColor = colorDialog1.Color;
            }
        }
        private void Btn_Fill_Click(object sender, EventArgs e)
        {
            SelectedMode = 4;
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pb_mainScreen.Refresh();
        }
        #endregion
        #region MainScreen Mouse Event
        private void pb_mainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if(SelectedMode == 3)
            {
                if(pb_mainScreen.Cursor == Cursors.Hand)
                {
                    currentColor = ((Bitmap)(pb_mainScreen.Image)).GetPixel(e.X, e.Y);
                    p.Color = currentColor;
                    pb_currentColor.BackColor = currentColor;
                    pb_mainScreen.Cursor = Cursors.Default;
                }
                
            }
            if(SelectedMode == 4)
            {
                Fill(bm, e.X, e.Y, currentColor);
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

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
        }

        #endregion
        #region Function
        //fill function
        private void validate(Bitmap bm, Stack<Point>sp, int x, int y,Color oldColor, Color newColor)
        {
            Color cx = bm.GetPixel(x, y);
            if(cx == oldColor)
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

        #endregion
    }
}
