namespace TNT_Paint
{
    partial class FormGemini
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_content = new System.Windows.Forms.TextBox();
            this.btn_tao = new System.Windows.Forms.Button();
            this.btn_chup = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.pb_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(393, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mô tả ảnh của bạn";
            // 
            // tb_content
            // 
            this.tb_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_content.Location = new System.Drawing.Point(12, 89);
            this.tb_content.Name = "tb_content";
            this.tb_content.Size = new System.Drawing.Size(837, 39);
            this.tb_content.TabIndex = 1;
            // 
            // btn_tao
            // 
            this.btn_tao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_tao.Location = new System.Drawing.Point(867, 88);
            this.btn_tao.Name = "btn_tao";
            this.btn_tao.Size = new System.Drawing.Size(166, 48);
            this.btn_tao.TabIndex = 2;
            this.btn_tao.Text = "Tạo";
            this.btn_tao.UseVisualStyleBackColor = false;
            this.btn_tao.Click += new System.EventHandler(this.btn_tao_Click);
            // 
            // btn_chup
            // 
            this.btn_chup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_chup.Location = new System.Drawing.Point(543, 583);
            this.btn_chup.Name = "btn_chup";
            this.btn_chup.Size = new System.Drawing.Size(114, 44);
            this.btn_chup.TabIndex = 5;
            this.btn_chup.Text = "Lấy ảnh";
            this.btn_chup.UseVisualStyleBackColor = false;
            this.btn_chup.Click += new System.EventHandler(this.btn_chup_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackColor = System.Drawing.Color.Red;
            this.btn_huy.ForeColor = System.Drawing.Color.White;
            this.btn_huy.Location = new System.Drawing.Point(385, 583);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(114, 44);
            this.btn_huy.TabIndex = 4;
            this.btn_huy.Text = "Hủy bỏ";
            this.btn_huy.UseVisualStyleBackColor = false;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // pb_image
            // 
            this.pb_image.Location = new System.Drawing.Point(239, 158);
            this.pb_image.Name = "pb_image";
            this.pb_image.Size = new System.Drawing.Size(610, 388);
            this.pb_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_image.TabIndex = 3;
            this.pb_image.TabStop = false;
            // 
            // FormGemini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1045, 655);
            this.Controls.Add(this.btn_chup);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.pb_image);
            this.Controls.Add(this.btn_tao);
            this.Controls.Add(this.tb_content);
            this.Controls.Add(this.label1);
            this.Name = "FormGemini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Màn hình tạo ảnh từ mô tả";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pb_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_content;
        private System.Windows.Forms.Button btn_tao;
        private System.Windows.Forms.PictureBox pb_image;
        private System.Windows.Forms.Button btn_chup;
        private System.Windows.Forms.Button btn_huy;
    }
}