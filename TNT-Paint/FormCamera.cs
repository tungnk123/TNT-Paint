using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TNT_Paint
{
    public partial class FormCamera : Form
    {
        FilterInfoCollection cameras;
        VideoCaptureDevice cam;
        public FormCamera()
        {
            InitializeComponent();
            cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (cam != null && cam.IsRunning) cam.Stop();
            cam = new VideoCaptureDevice(cameras[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap b = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void FormCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cam != null && cam.IsRunning) cam.Stop();
        }

        private void btn_chup_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.instance.g.DrawImage(pictureBox1.Image, Form1.instance.pb_mainScreen.Location.X, Form1.instance.pb_mainScreen.Location.Y,
                    Form1.instance.pb_mainScreen.Width, Form1.instance.pb_mainScreen.Height);
        }
    }
}
