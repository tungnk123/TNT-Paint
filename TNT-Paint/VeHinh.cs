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
        public VeHinh() { }
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
    }
}
