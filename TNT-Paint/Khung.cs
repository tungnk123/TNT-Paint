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
        public void Ve3DauThayDoiKichThuocKhung(Graphics g, int height, int width)
        {
            
            Brush brush = new SolidBrush(Color.Black);
            viTriDauDuoi.X =  width / 2;
            viTriDauDuoi.Y =  height;

            viTriDauPhai.X =  width;
            viTriDauPhai.Y =  height / 2;

            viTriDauCheo.X =  width;
            viTriDauCheo.Y =  height;

            g.FillRectangle(brush, 0, 0, 10, 10);
            //g.DrawLine(a, viTriDauPhai.X + 2, viTriDauPhai.Y + 2, viTriDauPhai.X + 2, viTriDauPhai.Y - 2);
            //g.DrawLine(a, viTriDauCheo.X + 2, viTriDauCheo.Y + 2, viTriDauCheo.X + 2, viTriDauCheo.Y - 2);
            
        }
    }
}
