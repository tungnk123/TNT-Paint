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
        Graphics graphicPanel;
        Bitmap bm;
        Pen p; // bút vẽ chính
        Pen eraser; // tẩy
        Point px, py;
        int SelectedMode; // mỗi giá trị là mỗi mode vẽ lên màn hình chính
        bool AllowPaint; // nếu là true thì cho phép vẽ lên màn hình chính
        Color currentColor = Color.Black;
        VeHinh veHinh;
        Khung Khung = new Khung();// class khung de ve cac dau thay doi kich thuoc

        //
        
        //
        //
        public bool isSaved = false;
        public string path = "";// bien string luu duong dan luu file

        //

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
            veHinh = new VeHinh();
            graphicPanel = this.CreateGraphics();
            Khung.Ve3DauThayDoiKichThuocKhung(graphicPanel, this.pb_mainScreen.Height, this.pb_mainScreen.Width);
            pb_mainScreen.MouseDown += pb_mainScreen_MouseDown;
            pb_mainScreen.MouseMove += pb_mainScreen_MouseMove;
            pb_mainScreen.MouseUp += pb_mainScreen_MouseUp;
            pb_mainScreen.Paint += pb_mainScreen_Paint;
        }
        #region All buttons event

        private void pb_ColorTable_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = setPoint(pb_ColorTable, e.Location);
            pb_currentColor.BackColor = ((Bitmap)(pb_ColorTable.Image)).GetPixel(pt.X, pt.Y);
            currentColor = pb_currentColor.BackColor;
            p.Color = currentColor;
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
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pb_mainScreen.Refresh();
            pb_mainScreen.Image = bm;// xoa hinh anh dang co o trong pb_mainScreen
        }
        private void Btn_Pencil_Click(object sender, EventArgs e)
        {
            SelectedMode = 1;
            veHinh.inPolygon = false;
        }

        private void Btn_Eraser_Click(object sender, EventArgs e)
        {
            SelectedMode = 2;
            veHinh.inPolygon = false;;
        }
        private void Btn_ColorPicker_Click(object sender, EventArgs e)
        {
            SelectedMode = 3;
            pb_mainScreen.Cursor = Cursors.Hand;
            veHinh.inPolygon = false;
        }
        private void Btn_Fill_Click(object sender, EventArgs e)
        {
            SelectedMode = 4;
            veHinh.inPolygon = false;
        }
        private void btn_SmallLine_Click(object sender, EventArgs e)
        {
            p.Width = 1;
        }
        private void Btn_MediumLine_Click(object sender, EventArgs e)
        {
            p.Width = 3;
        }
        private void Btn_BigLine_Click(object sender, EventArgs e)
        {
            p.Width = 6;
        }
        private void Btn_DrawLine_Click(object sender, EventArgs e)
        {
            SelectedMode = 5;
            veHinh.inPolygon = false;
        }
        private void Btn_Ellipse_Click(object sender, EventArgs e)
        {
            SelectedMode = 6;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRect_Click(object sender, EventArgs e)
        {
            SelectedMode = 7;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawTriangle_Click(object sender, EventArgs e)
        {
            SelectedMode = 8;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRightTriangle_Click(object sender, EventArgs e)
        {
            SelectedMode = 9;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRoundedRectangle_Click(object sender, EventArgs e)
        {
            SelectedMode = 10;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawDiamond_Click(object sender, EventArgs e)
        {
            SelectedMode = 11;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawPentagon_Click(object sender, EventArgs e)
        {
            SelectedMode = 12;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawHexagon_Click(object sender, EventArgs e)
        {
            SelectedMode = 13;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawUpArrow_Click(object sender, EventArgs e)
        {
            SelectedMode = 14;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawLeftArrow_Click(object sender, EventArgs e)
        {
            SelectedMode = 15;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawRightArrow_Click(object sender, EventArgs e)
        {
            SelectedMode = 16;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawDownArrow_Click(object sender, EventArgs e)
        {
            SelectedMode = 17;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawPolygon_Click(object sender, EventArgs e)
        {
            SelectedMode = 18;
            veHinh.inPolygon = false;
        }
        private void Btn_DrawFivePointStar_Click(object sender, EventArgs e)
        {
            SelectedMode = 19;
            veHinh.inPolygon = false;
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
                py = e.Location;
                if (SelectedMode == 1)
                {
                    g.DrawLine(p, px, py);
                    px = py;
                }
                if (SelectedMode == 2)
                {
                    g.DrawLine(eraser, px, py);
                    px = py;
                }
            }
            pb_mainScreen.Refresh();
        }

        private void pb_mainScreen_MouseUp(object sender, MouseEventArgs e)
        {
            AllowPaint = false;
            if(SelectedMode == 5)
            {
                veHinh.DrawLine(p, g, px, py);
            }
            if(SelectedMode == 6)
            {
                veHinh.DrawEllipse(p, g, px, py);
            }
            if(SelectedMode == 7)
            {
                veHinh.DrawRect(p, g, px, py);
            }
            if(SelectedMode == 8)
            {
                veHinh.DrawTriangle(p, g, px, py);
            }
            if (SelectedMode == 9)
            {
                veHinh.DrawRightTriangle(p, g, px, py);
            }
            if(SelectedMode == 10)
            {
                veHinh.DrawRoundedRectangle(p, g, px, py);
            }
            if(SelectedMode == 11)
            {
                veHinh.DrawDiamond(p, g, px, py);
            }
            if(SelectedMode == 12)
            {
                veHinh.DrawPentagon(p, g, px, py);
            }
            if(SelectedMode == 13)
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
                if(SelectedMode == 5)
                {
                    veHinh.DrawLine(p, gx, px, py);
                }
                if(SelectedMode == 6)
                {
                    veHinh.DrawEllipse(p, gx, px, py);
                }
                if(SelectedMode == 7)
                {
                    veHinh.DrawRect(p, gx, px, py);
                }
                if (SelectedMode == 8)
                {
                    veHinh.DrawTriangle(p, gx, px, py);
                }
                if(SelectedMode == 9)
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
            g.Clear(Color.White);
            pb_mainScreen.Refresh();
            pb_mainScreen.Image = bm;

        }

        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "File *.png, *jpg, *.bmp, *.gif|*.png; *.jpg; *.bmp; *.gif ", Title = "Open image" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                pb_mainScreen.Image = Image.FromFile(fileName);
                pb_mainScreen.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        #endregion
    }
}
