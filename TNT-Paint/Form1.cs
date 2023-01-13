using System;
using System.Collections.Generic;
using System.Drawing;
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
        bool isPainted = false;
        Color currentColor = Color.Black;
        VeHinh veHinh;

        //
        //
        //
        public bool isDown = false;// biến chỉ ra các dáu chấm thay đổi kích thước có nhấn ko
        public Point oldPoint = new Point(); 
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
            pb_mainScreen.MouseDown += pb_mainScreen_MouseDown;
            pb_mainScreen.MouseMove += pb_mainScreen_MouseMove;
            pb_mainScreen.MouseUp += pb_mainScreen_MouseUp;
            pb_mainScreen.Paint += pb_mainScreen_Paint;

            this.FormClosing += new FormClosingEventHandler(Form1_Closing);

            timer1.Start();
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
            veHinh.inPolygon = false; ;
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
            isPainted = true;
            if (SelectedMode == 3)
            {
                if (pb_mainScreen.Cursor == Cursors.Hand)
                {
                    currentColor = ((Bitmap)(pb_mainScreen.Image)).GetPixel(e.X, e.Y);
                    p.Color = currentColor;
                    pb_currentColor.BackColor = currentColor;
                    pb_mainScreen.Cursor = Cursors.Default;
                }

            }
            if (SelectedMode == 4)
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
        #region Function
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
            g.Clear(Color.White);
            pb_mainScreen.Refresh();
            pb_mainScreen.Image = bm;
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // truong hop da ve gi do len picturebox
            if (isPainted)
            {
                switch (MessageBox.Show("Bạn có muốn lưu file không", "Thông Báo", MessageBoxButtons.YesNoCancel))
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
                switch (MessageBox.Show("Bạn có muốn lưu file không", "Thông Báo", MessageBoxButtons.YesNoCancel))
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

        
        #endregion

        #region Timer ve cac dau cham
        private void timer1_Tick(object sender, EventArgs e)
        {
            panelDauCham1.Location = new Point(this.pb_mainScreen.Width + pb_mainScreen.Location.X, pb_mainScreen.Height / 2 + pb_mainScreen.Location.Y);
            panelDauCham2.Location = new Point(this.pb_mainScreen.Width/2 + pb_mainScreen.Location.X, pb_mainScreen.Height + pb_mainScreen.Location.Y);
            panelDauCham3.Location = new Point(this.pb_mainScreen.Width + pb_mainScreen.Location.X, pb_mainScreen.Height + pb_mainScreen.Location.Y);

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
                    this.Invalidate();
                }
            }
            oldPoint = e.Location;
        }


        #endregion
    }
}
