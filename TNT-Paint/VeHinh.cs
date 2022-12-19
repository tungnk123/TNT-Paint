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
    class VeHinh
    {
        public bool inPolygon;
        public Point PreviousPoint;
        public Point StartPoint;
        public VeHinh()
        {
            inPolygon = false;
        }
        public void DrawLine(Pen p, Graphics g, Point px, Point py)
        {
            g.DrawLine(p, px, py);
        }
        public void DrawEllipse(Pen p, Graphics g, Point px, Point py)
        {
            g.DrawEllipse(p, px.X, px.Y, py.X - px.X, py.Y - px.Y);
        }
        public void DrawRect(Pen p, Graphics g, Point px, Point py)
        {
            g.DrawRectangle(p, px.X, px.Y, py.X - px.X, py.Y - px.Y);
        }
        public void DrawTriangle(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3;
            int width = py.X - px.X;
            int height = py.Y - px.Y;
            p1 = new Point(px.X + width / 2, px.Y);
            p2 = new Point(px.X, py.Y);
            p3 = py;
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p2, p3);
            g.DrawLine(p, p3, p1);
        }
        public void DrawRightTriangle(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3;
            p1 = px;
            p2 = new Point(px.X, py.Y);
            p3 = py;
            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p2, p3);
            g.DrawLine(p, p3, p1);
        }
        public void DrawRoundedRectangle(Pen p, Graphics g, Point px, Point py)
        {
            int width = py.X - px.X;
            int height = py.Y - px.Y;

            //top left
            Point tl1, tl2, tl3;
            tl1 = new Point(px.X, px.Y + height / 7);
            tl2 = new Point(px.X + width / 7,px.Y);
            tl3 = new Point((tl1.X + tl2.X) / 2 - width / 19, (tl1.Y + tl2.Y) / 2 - height / 19);
            Point[] pnt_tl = { tl1, tl3, tl2 };

            // bottom left
            Point bl1, bl2, bl3;
            bl1 = new Point(px.X, py.Y - height / 7);
            bl2 = new Point(px.X + width / 7, py.Y);
            bl3 = new Point((bl1.X + bl2.X) / 2 - width / 19, (bl1.Y + bl2.Y) / 2 + height / 19);
            Point[] pnt_bl = { bl1, bl3, bl2 };

            // top right
            Point tr1, tr2, tr3;
            tr1 = new Point(px.X + 6 * width / 7, px.Y);
            tr2 = new Point(py.X, px.Y + height / 7);
            tr3 = new Point((tr1.X + tr2.X) / 2 + width / 19, (tr1.Y + tr2.Y) / 2 - height / 19);
            Point[] pnt_tr = { tr1, tr3, tr2 };

            //bottom right
            Point br1, br2, br3;
            br1 = new Point(px.X + 6 * width / 7, py.Y);
            br2 = new Point(py.X, px.Y + 6 * height / 7);
            br3 = new Point((br1.X + br2.X) / 2 + width / 19, (br1.Y + br2.Y) / 2 + height / 20);
            Point[] pnt_br = { br1, br3, br2 };
            //

            g.DrawCurve(p, pnt_tl);
            g.DrawCurve(p, pnt_bl);
            g.DrawCurve(p, pnt_tr);
            g.DrawCurve(p, pnt_br);
            g.DrawLine(p, tl1, bl1);
            g.DrawLine(p, tl2, tr1);
            g.DrawLine(p, tr2, br2);
            g.DrawLine(p, bl2, br1);
        }
        public void DrawDiamond(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4;
            int width = py.X - px.X;
            int height = py.Y - px.Y;

            p1 = new Point(px.X + width / 2, px.Y);
            p2 = new Point(px.X, px.Y + height / 2);
            p3 = new Point(py.X, px.Y + height / 2);
            p4 = new Point(px.X + width / 2, py.Y);

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p4);
            g.DrawLine(p, p1, p3);
        }
        public void DrawPentagon(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5;
            int width = py.X - px.X;
            int height = py.Y - px.Y;

            p1 = new Point(px.X + width / 2, px.Y); // top
            p2 = new Point(px.X, px.Y + height / 3); // left
            p3 = new Point(py.X, px.Y + height / 3); // right
            p4 = new Point(px.X + width / 5, py.Y); // bottom left
            p5 = new Point(py.X - width / 5, py.Y); // bottom right

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p2);
            g.DrawLine(p, p4, p5);
        }
        public void DrawHexagon(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5, p6;
            int width = py.X - px.X;
            int height = py.Y - px.Y;

            p1 = new Point(px.X + width / 5, px.Y); // top left
            p2 = new Point(px.X + 4 * width / 5, px.Y); // top right
            p3 = new Point(px.X, px.Y + height / 2); // left
            p4 = new Point(py.X, px.Y + height / 2); // right
            p5 = new Point(px.X + width / 5, py.Y); // bottom left
            p6 = new Point(px.X + 4 * width / 5, py.Y); // bottom right

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p6);
            g.DrawLine(p, p5, p6);
        }
        public void DrawUpArrow(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5, p6, p7;
            int width = py.X - px.X;
            int height = py.Y - px.Y;
            p1 = new Point(px.X + width / 2, px.Y); // top
            p2 = new Point(px.X, px.Y + height / 3); // left
            p3 = new Point(py.X, px.Y + height / 3); // right
            p4 = new Point(px.X + width / 5, px.Y + height / 3); // middle left
            p5 = new Point(px.X + 4 * width / 5, px.Y + height / 3);// middle right
            p6 = new Point(px.X + width / 5, py.Y); // bottom left
            p7 = new Point(px.X + 4 * width / 5, py.Y); // bottom right

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p6);
            g.DrawLine(p, p5, p7);
            g.DrawLine(p, p6, p7);
        }
        public void DrawLeftArrow(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5, p6, p7;
            int width = py.X - px.X;
            int height = py.Y - px.Y;
            p1 = new Point(px.X, px.Y + height / 2); // right
            p2 = new Point(px.X + width/2, px.Y); // top
            p3 = new Point(px.X + width / 2, py.Y); // bottom
            p4 = new Point(px.X + width / 2, px.Y + height / 5); // middle top
            p5 = new Point(px.X + width / 2, py.Y - height / 5);// middle bottom
            p6 = new Point(py.X, px.Y + height / 5); // top left
            p7 = new Point(py.X, px.Y + 4 * height / 5); // bottom left

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p6);
            g.DrawLine(p, p5, p7);
            g.DrawLine(p, p6, p7);
        }
        public void DrawRightArrow(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5, p6, p7;
            int width = py.X - px.X;
            int height = py.Y - px.Y;
            p1 = new Point(py.X, px.Y + height / 2); // left
            p2 = new Point(px.X + width / 2, px.Y); // top
            p3 = new Point(px.X + width / 2, py.Y); // bottom
            p4 = new Point(px.X + width / 2, px.Y +  height / 5); // middle top
            p5 = new Point(px.X + width / 2, py.Y - height / 5); // middle  bottom
            p6 = new Point(px.X, px.Y + height / 5); // top left
            p7 = new Point(px.X, py.Y - height / 5); // bottom left

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p6);
            g.DrawLine(p, p5, p7);
            g.DrawLine(p, p6, p7);
        }
        public void DrawDownArrow(Pen p, Graphics g, Point px, Point py)
        {
            Point p1, p2, p3, p4, p5, p6, p7;
            int width = py.X - px.X;
            int height = py.Y - px.Y;
            p1 = new Point(px.X + width / 2, py.Y); // bottom
            p2 = new Point(px.X, py.Y - height / 3); // left
            p3 = new Point(py.X, py.Y - height / 3); // right
            p4 = new Point(px.X + width / 5, py.Y - height / 3); // middle left
            p5 = new Point(px.X + 4 * width / 5, py.Y - height / 3); // middle right
            p6 = new Point(px.X + width / 5, px.Y); // top left
            p7 = new Point(px.X + 4 * width / 5, px.Y);// top right

            g.DrawLine(p, p1, p2);
            g.DrawLine(p, p1, p3);
            g.DrawLine(p, p2, p4);
            g.DrawLine(p, p3, p5);
            g.DrawLine(p, p4, p6);
            g.DrawLine(p, p5, p7);
            g.DrawLine(p, p6, p7);
        }
        public void DrawPolygon(Pen p, Graphics g, Point px, Point py)
        {
            if (inPolygon == false)
            {
                StartPoint = px;
                g.DrawLine(p, px, py);
                PreviousPoint = py;
                inPolygon = true;
            }
            else
            {
                if (py.X - StartPoint.X < 10 && py.Y - StartPoint.Y < 10)
                {
                    g.DrawLine(p, StartPoint, PreviousPoint);
                    StartPoint = new Point(0, 0);
                    PreviousPoint = new Point(0, 0);
                    inPolygon = false;
                }
                else
                {
                    g.DrawLine(p, PreviousPoint, py);
                    PreviousPoint = py;
                }
            }
        }
        public void MinhHoaPolygon(Pen p, Graphics g, Point px, Point py)
        {
            if(inPolygon == false)
            {
                g.DrawLine(p, px, py);
            }
            else
            {
                g.DrawLine(p, PreviousPoint, py);
            }
        }
    }
}
