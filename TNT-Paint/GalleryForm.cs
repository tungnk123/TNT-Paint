using CefSharp.WinForms;
using CefSharp;
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
    public partial class GalleryForm : Form
    {
        public GalleryForm()
        {
            InitializeComponent();
            chromiumWebBrowser1.Load("https://artwork-gallery-nu.vercel.app");
        }


        private void btnReload_Click(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Reload();
        }
    }
}
