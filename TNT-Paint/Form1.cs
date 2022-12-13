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
        Point px, py;

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pb_mainScreen.Width, pb_mainScreen.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pb_mainScreen.Image = bm;
            p = new Pen(Color.Black, 1);
            // Khởi tạo ban đầu
        }
    }
}
