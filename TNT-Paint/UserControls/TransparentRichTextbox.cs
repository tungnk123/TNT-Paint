using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TNT_Paint.UserControls
{
    public class TransparentRichTextBox : RichTextBox
    {
        public TransparentRichTextBox()
        {
            this.ContentsResized += new ContentsResizedEventHandler(TransparentRichTextBox_ContentsResized);

            this.Multiline = true;
            this.BorderStyle = BorderStyle.None;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.Transparent;
        }

        private void TransparentRichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            this.Height = e.NewRectangle.Height + this.Font.Height;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // Kích hoạt WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += Parent_BackColorChanged;
                this.BackColor = Color.Transparent;
            }
        }

        private void Parent_BackColorChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Không vẽ nền mặc định để tránh nhấp nháy
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                // Vẽ nền trong suốt trước khi vẽ RichTextBox
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 255, 255)), this.ClientRectangle);
                }
            }
            base.WndProc(ref m);
        }
    }
}
