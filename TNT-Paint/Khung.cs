using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TNT_Paint
{
    class Khung
    {
        public Point viTriDauDuoi, viTriDauPhai, viTriDauCheo, tam = new Point(0, 0);
        public bool a = false, b = false, c = false;
        public void Ve3DauThayDoiKichThuocKhung(Graphics g, int width, int height)
        {
            
            Brush brush = new SolidBrush(Color.Black);
            viTriDauDuoi.X =  width / 2;
            viTriDauDuoi.Y =  height;

            viTriDauPhai.X =  width;
            viTriDauPhai.Y =  height / 2;

            viTriDauCheo.X =  width;
            viTriDauCheo.Y =  height;

            g.Clear(Color.Black);

            //g.FillRectangle(brush, 0, 0, 10, 10);
            //g.DrawLine(Pens.Black, width + 2, 0, width + 2, height + 2);
            //g.DrawLine(Pens.Black, viTriDauCheo.X + 2, viTriDauCheo.Y + 2, viTriDauCheo.X + 2, viTriDauCheo.Y - 2);
            
        }
    }
}
