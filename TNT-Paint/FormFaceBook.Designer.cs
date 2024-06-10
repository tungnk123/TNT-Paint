namespace TNT_Paint
{
    partial class FormFaceBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_ava = new System.Windows.Forms.PictureBox();
            this.lb_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_status = new System.Windows.Forms.RichTextBox();
            this.pb_image = new System.Windows.Forms.PictureBox();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_post = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ava)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_ava
            // 
            this.pb_ava.Location = new System.Drawing.Point(35, 40);
            this.pb_ava.Name = "pb_ava";
            this.pb_ava.Size = new System.Drawing.Size(100, 100);
            this.pb_ava.TabIndex = 0;
            this.pb_ava.TabStop = false;
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(163, 73);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(93, 32);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Image";
            // 
            // rtb_status
            // 
            this.rtb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_status.Location = new System.Drawing.Point(35, 218);
            this.rtb_status.Name = "rtb_status";
            this.rtb_status.Size = new System.Drawing.Size(574, 96);
            this.rtb_status.TabIndex = 4;
            this.rtb_status.Text = "";
            // 
            // pb_image
            // 
            this.pb_image.Location = new System.Drawing.Point(169, 367);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(309, 180);
            this.pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_image.TabIndex = 5;
            this.pb_image.TabStop = false;
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.Red;
            this.btn_huy.Location = new System.Drawing.Point(157, 593);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(130, 43);
            this.btn_huy.TabIndex = 6;
            this.btn_huy.Text = "Hủy";
            this.btn_huy.UseVisualStyleBackColor = false;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_post
            // 
            this.btn_post.BackColor = System.Drawing.Color.Lime;
            this.btn_post.Location = new System.Drawing.Point(338, 593);
            this.btn_post.Name = "btn_post";
            this.btn_post.Size = new System.Drawing.Size(130, 43);
            this.btn_post.TabIndex = 7;
            this.btn_post.Text = "Post";
            this.btn_post.UseVisualStyleBackColor = false;
            this.btn_post.Click += new System.EventHandler(this.btn_post_Click);
            // 
            // FormFaceBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 660);
            this.Controls.Add(this.btn_post);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.rtb_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.pb_ava);
            this.Name = "FormFaceBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share image to facebook";
            ((System.ComponentModel.ISupportInitialize)(this.pb_ava)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_ava;
        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_status;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_post;
    }
}