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
            // Đăng ký sự kiện ContentsResized để tự động điều chỉnh chiều cao
            this.ContentsResized += new ContentsResizedEventHandler(TransparentRichTextBox_ContentsResized);

            this.Multiline = true;
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White; // Cần một màu nền tạm thời
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void TransparentRichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            // Điều chỉnh chiều cao của RichTextBox dựa trên nội dung
            this.Height = e.NewRectangle.Height + this.Font.Height;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_PAINT = 0xF;
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                // Vẽ nền trong suốt trước khi vẽ RichTextBox
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 255, 255)), this.ClientRectangle);
                }
            }
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
            base.OnPaintBackground(e);

            if (this.Parent != null)
            {
                Rectangle rect = new Rectangle(this.Left, this.Top, this.Width, this.Height);
                e.Graphics.FillRectangle(new SolidBrush(this.Parent.BackColor), rect);
            }
        }

    }
}
