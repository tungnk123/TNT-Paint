
namespace TNT_Paint
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zomeInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Fill = new System.Windows.Forms.Button();
            this.Btn_ColorPicker = new System.Windows.Forms.Button();
            this.Btn_ColorPanel = new System.Windows.Forms.Button();
            this.pb_color = new System.Windows.Forms.PictureBox();
            this.Btn_Eraser = new System.Windows.Forms.Button();
            this.Btn_Pencil = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pb_mainScreen = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.svaeToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // svaeToolStripMenuItem
            // 
            this.svaeToolStripMenuItem.Name = "svaeToolStripMenuItem";
            this.svaeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.svaeToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zomeInToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zomeInToolStripMenuItem
            // 
            this.zomeInToolStripMenuItem.Name = "zomeInToolStripMenuItem";
            this.zomeInToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.zomeInToolStripMenuItem.Text = "Zome in";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.Btn_Fill);
            this.panel1.Controls.Add(this.Btn_ColorPicker);
            this.panel1.Controls.Add(this.Btn_ColorPanel);
            this.panel1.Controls.Add(this.pb_color);
            this.panel1.Controls.Add(this.Btn_Eraser);
            this.panel1.Controls.Add(this.Btn_Pencil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 100);
            this.panel1.TabIndex = 1;
            // 
            // Btn_Fill
            // 
            this.Btn_Fill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_Fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Fill.Image = global::TNT_Paint.Properties.Resources.Fill;
            this.Btn_Fill.Location = new System.Drawing.Point(69, 54);
            this.Btn_Fill.Name = "Btn_Fill";
            this.Btn_Fill.Size = new System.Drawing.Size(39, 36);
            this.Btn_Fill.TabIndex = 5;
            this.Btn_Fill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_Fill, "Fill With Color");
            this.Btn_Fill.UseVisualStyleBackColor = true;
            this.Btn_Fill.Click += new System.EventHandler(this.Btn_Fill_Click);
            // 
            // Btn_ColorPicker
            // 
            this.Btn_ColorPicker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_ColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ColorPicker.Image = global::TNT_Paint.Properties.Resources.colorPicker2;
            this.Btn_ColorPicker.Location = new System.Drawing.Point(69, 12);
            this.Btn_ColorPicker.Name = "Btn_ColorPicker";
            this.Btn_ColorPicker.Size = new System.Drawing.Size(39, 36);
            this.Btn_ColorPicker.TabIndex = 4;
            this.Btn_ColorPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_ColorPicker, "Color Picker");
            this.Btn_ColorPicker.UseVisualStyleBackColor = true;
            this.Btn_ColorPicker.Click += new System.EventHandler(this.Btn_ColorPicker_Click);
            // 
            // Btn_ColorPanel
            // 
            this.Btn_ColorPanel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_ColorPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ColorPanel.Image = global::TNT_Paint.Properties.Resources.colorPicker;
            this.Btn_ColorPanel.Location = new System.Drawing.Point(205, 21);
            this.Btn_ColorPanel.Name = "Btn_ColorPanel";
            this.Btn_ColorPanel.Size = new System.Drawing.Size(69, 60);
            this.Btn_ColorPanel.TabIndex = 3;
            this.Btn_ColorPanel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_ColorPanel, "Color Table");
            this.Btn_ColorPanel.UseVisualStyleBackColor = true;
            this.Btn_ColorPanel.Click += new System.EventHandler(this.Btn_ColorPanel_Click);
            // 
            // pb_color
            // 
            this.pb_color.BackColor = System.Drawing.Color.Black;
            this.pb_color.Location = new System.Drawing.Point(144, 35);
            this.pb_color.Name = "pb_color";
            this.pb_color.Size = new System.Drawing.Size(44, 35);
            this.pb_color.TabIndex = 2;
            this.pb_color.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_color, "Current Color");
            // 
            // Btn_Eraser
            // 
            this.Btn_Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eraser.Image = global::TNT_Paint.Properties.Resources.Eraser;
            this.Btn_Eraser.Location = new System.Drawing.Point(12, 54);
            this.Btn_Eraser.Name = "Btn_Eraser";
            this.Btn_Eraser.Size = new System.Drawing.Size(39, 36);
            this.Btn_Eraser.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Btn_Eraser, "Eraser");
            this.Btn_Eraser.UseVisualStyleBackColor = true;
            this.Btn_Eraser.Click += new System.EventHandler(this.Btn_Eraser_Click);
            // 
            // Btn_Pencil
            // 
            this.Btn_Pencil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_Pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Pencil.Image = global::TNT_Paint.Properties.Resources.Pencil__2_;
            this.Btn_Pencil.Location = new System.Drawing.Point(12, 12);
            this.Btn_Pencil.Name = "Btn_Pencil";
            this.Btn_Pencil.Size = new System.Drawing.Size(39, 36);
            this.Btn_Pencil.TabIndex = 0;
            this.Btn_Pencil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_Pencil, "Pencil");
            this.Btn_Pencil.UseVisualStyleBackColor = true;
            this.Btn_Pencil.Click += new System.EventHandler(this.Btn_Pencil_Click);
            // 
            // pb_mainScreen
            // 
            this.pb_mainScreen.Cursor = System.Windows.Forms.Cursors.Default;
            this.pb_mainScreen.Location = new System.Drawing.Point(0, 124);
            this.pb_mainScreen.Name = "pb_mainScreen";
            this.pb_mainScreen.Size = new System.Drawing.Size(908, 471);
            this.pb_mainScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_mainScreen.TabIndex = 2;
            this.pb_mainScreen.TabStop = false;
            this.pb_mainScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_mainScreen_MouseDown);
            this.pb_mainScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_mainScreen_MouseMove);
            this.pb_mainScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_mainScreen_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 595);
            this.Controls.Add(this.pb_mainScreen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TNT Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem svaeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zomeInToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pb_mainScreen;
        private System.Windows.Forms.Button Btn_Eraser;
        private System.Windows.Forms.Button Btn_Pencil;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pb_color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Btn_ColorPanel;
        private System.Windows.Forms.Button Btn_ColorPicker;
        private System.Windows.Forms.Button Btn_Fill;
    }
}

