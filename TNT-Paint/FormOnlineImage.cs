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
    public partial class FormOnlineImage : Form
    {
        public FormOnlineImage()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void FormOnlineImage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchString = textBox1.Text;

            webBrowser1.Visible = true;
            //webBrowser1.Navigate("https://c.pxhere.com/photos/e7/82/road_forest_season_autumn_fall_landscape_nature_forest_landscape-839463.jpg!d");
            webBrowser1.Navigate("https://www.google.com.vn/search?q=" + searchString + "&tbm=isch&source=hp&biw=1366&bih=625&ei=TlXJY5yQAcyGoATg7q_IDg&iflsig=AK50M_UAAAAAY8ljXlPTL0DR76dtxTKtKIdQGq0H2wmv&ved=0ahUKEwic75bP7dP8AhVMA4gKHWD3C-kQ4dUDCAc&uact=5&oq=cuba&gs_lcp=CgNpbWcQAzIICAAQgAQQsQMyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQ6CwgAEIAEELEDEIMBOgQIABADOggIABCxAxCDAVDQB1juC2CeEGgBcAB4AIABeYgB3QOSAQMwLjSYAQCgAQGqAQtnd3Mtd2l6LWltZ7ABAA&sclient=img");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }


    }
}
