
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svaeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zomeInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zomeOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridlinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel_size = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gb_Shape = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.pb_mainScreen = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Btn_BigLine = new System.Windows.Forms.Button();
            this.Btn_MediumLine = new System.Windows.Forms.Button();
            this.btn_SmallLine = new System.Windows.Forms.Button();
            this.Btn_ColorDialog = new System.Windows.Forms.Button();
            this.Btn_Fill = new System.Windows.Forms.Button();
            this.pb_currentColor = new System.Windows.Forms.PictureBox();
            this.Btn_ColorPicker = new System.Windows.Forms.Button();
            this.Btn_Eraser = new System.Windows.Forms.Button();
            this.Btn_Pencil = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_size.SuspendLayout();
            this.gb_Shape.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_currentColor)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 25);
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
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // svaeToolStripMenuItem
            // 
            this.svaeToolStripMenuItem.Name = "svaeToolStripMenuItem";
            this.svaeToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.svaeToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(117, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(110, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zomeInToolStripMenuItem,
            this.zomeOutToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.rulerToolStripMenuItem,
            this.gridlinesToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // zomeInToolStripMenuItem
            // 
            this.zomeInToolStripMenuItem.Name = "zomeInToolStripMenuItem";
            this.zomeInToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.zomeInToolStripMenuItem.Text = "Zome in";
            // 
            // zomeOutToolStripMenuItem
            // 
            this.zomeOutToolStripMenuItem.Name = "zomeOutToolStripMenuItem";
            this.zomeOutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.zomeOutToolStripMenuItem.Text = "Zome out";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "100%";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // rulerToolStripMenuItem
            // 
            this.rulerToolStripMenuItem.Name = "rulerToolStripMenuItem";
            this.rulerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.rulerToolStripMenuItem.Text = "Ruler";
            // 
            // gridlinesToolStripMenuItem
            // 
            this.gridlinesToolStripMenuItem.Name = "gridlinesToolStripMenuItem";
            this.gridlinesToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.gridlinesToolStripMenuItem.Text = "Gridlines";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.statusBarToolStripMenuItem.Text = "Status Bar";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.gb_Shape);
            this.panel1.Controls.Add(this.Panel_size);
            this.panel1.Controls.Add(this.Btn_Clear);
            this.panel1.Controls.Add(this.Btn_ColorDialog);
            this.panel1.Controls.Add(this.Btn_Fill);
            this.panel1.Controls.Add(this.pb_currentColor);
            this.panel1.Controls.Add(this.Btn_ColorPicker);
            this.panel1.Controls.Add(this.Btn_Eraser);
            this.panel1.Controls.Add(this.Btn_Pencil);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 100);
            this.panel1.TabIndex = 1;
            // 
            // Panel_size
            // 
            this.Panel_size.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Panel_size.Controls.Add(this.label1);
            this.Panel_size.Controls.Add(this.Btn_BigLine);
            this.Panel_size.Controls.Add(this.Btn_MediumLine);
            this.Panel_size.Controls.Add(this.btn_SmallLine);
            this.Panel_size.Location = new System.Drawing.Point(484, 3);
            this.Panel_size.Name = "Panel_size";
            this.Panel_size.Size = new System.Drawing.Size(91, 97);
            this.Panel_size.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size";
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Clear.Location = new System.Drawing.Point(811, 11);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 36);
            this.Btn_Clear.TabIndex = 6;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // gb_Shape
            // 
            this.gb_Shape.Controls.Add(this.toolStrip1);
            this.gb_Shape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Shape.Location = new System.Drawing.Point(581, 3);
            this.gb_Shape.Name = "gb_Shape";
            this.gb_Shape.Size = new System.Drawing.Size(174, 97);
            this.gb_Shape.TabIndex = 8;
            this.gb_Shape.TabStop = false;
            this.gb_Shape.Text = "Shapes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(168, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // pb_mainScreen
            // 
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
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TNT_Paint.Properties.Resources.Line;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(25, 25);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // Btn_BigLine
            // 
            this.Btn_BigLine.Image = global::TNT_Paint.Properties.Resources.BigLine;
            this.Btn_BigLine.Location = new System.Drawing.Point(0, 55);
            this.Btn_BigLine.Name = "Btn_BigLine";
            this.Btn_BigLine.Size = new System.Drawing.Size(91, 22);
            this.Btn_BigLine.TabIndex = 2;
            this.Btn_BigLine.UseVisualStyleBackColor = true;
            this.Btn_BigLine.Click += new System.EventHandler(this.Btn_BigLine_Click);
            // 
            // Btn_MediumLine
            // 
            this.Btn_MediumLine.Image = global::TNT_Paint.Properties.Resources.MediumLine;
            this.Btn_MediumLine.Location = new System.Drawing.Point(0, 30);
            this.Btn_MediumLine.Name = "Btn_MediumLine";
            this.Btn_MediumLine.Size = new System.Drawing.Size(91, 22);
            this.Btn_MediumLine.TabIndex = 1;
            this.Btn_MediumLine.UseVisualStyleBackColor = true;
            this.Btn_MediumLine.Click += new System.EventHandler(this.Btn_MediumLine_Click);
            // 
            // btn_SmallLine
            // 
            this.btn_SmallLine.Image = global::TNT_Paint.Properties.Resources.Small_line;
            this.btn_SmallLine.Location = new System.Drawing.Point(0, 5);
            this.btn_SmallLine.Name = "btn_SmallLine";
            this.btn_SmallLine.Size = new System.Drawing.Size(91, 22);
            this.btn_SmallLine.TabIndex = 0;
            this.btn_SmallLine.UseVisualStyleBackColor = true;
            this.btn_SmallLine.Click += new System.EventHandler(this.btn_SmallLine_Click);
            // 
            // Btn_ColorDialog
            // 
            this.Btn_ColorDialog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_ColorDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ColorDialog.Image = global::TNT_Paint.Properties.Resources.ColorPanel;
            this.Btn_ColorDialog.Location = new System.Drawing.Point(191, 15);
            this.Btn_ColorDialog.Name = "Btn_ColorDialog";
            this.Btn_ColorDialog.Size = new System.Drawing.Size(70, 69);
            this.Btn_ColorDialog.TabIndex = 5;
            this.Btn_ColorDialog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_ColorDialog, "Color Panel");
            this.Btn_ColorDialog.UseVisualStyleBackColor = true;
            this.Btn_ColorDialog.Click += new System.EventHandler(this.Btn_ColorDialog_Click);
            // 
            // Btn_Fill
            // 
            this.Btn_Fill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_Fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Fill.Image = global::TNT_Paint.Properties.Resources.Fill;
            this.Btn_Fill.Location = new System.Drawing.Point(69, 54);
            this.Btn_Fill.Name = "Btn_Fill";
            this.Btn_Fill.Size = new System.Drawing.Size(39, 36);
            this.Btn_Fill.TabIndex = 4;
            this.Btn_Fill.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_Fill, "Fill With Color");
            this.Btn_Fill.UseVisualStyleBackColor = true;
            this.Btn_Fill.Click += new System.EventHandler(this.Btn_Fill_Click);
            // 
            // pb_currentColor
            // 
            this.pb_currentColor.BackColor = System.Drawing.Color.Black;
            this.pb_currentColor.Location = new System.Drawing.Point(126, 29);
            this.pb_currentColor.Name = "pb_currentColor";
            this.pb_currentColor.Size = new System.Drawing.Size(50, 42);
            this.pb_currentColor.TabIndex = 3;
            this.pb_currentColor.TabStop = false;
            this.toolTip1.SetToolTip(this.pb_currentColor, "Current Color");
            // 
            // Btn_ColorPicker
            // 
            this.Btn_ColorPicker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.Btn_ColorPicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ColorPicker.Image = global::TNT_Paint.Properties.Resources.colorPicker;
            this.Btn_ColorPicker.Location = new System.Drawing.Point(69, 12);
            this.Btn_ColorPicker.Name = "Btn_ColorPicker";
            this.Btn_ColorPicker.Size = new System.Drawing.Size(39, 36);
            this.Btn_ColorPicker.TabIndex = 2;
            this.Btn_ColorPicker.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.Btn_ColorPicker, "Color Picker");
            this.Btn_ColorPicker.UseVisualStyleBackColor = true;
            this.Btn_ColorPicker.Click += new System.EventHandler(this.Btn_ColorPicker_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 595);
            this.Controls.Add(this.pb_mainScreen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TNT Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Panel_size.ResumeLayout(false);
            this.Panel_size.PerformLayout();
            this.gb_Shape.ResumeLayout(false);
            this.gb_Shape.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_mainScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_currentColor)).EndInit();
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zomeOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridlinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button Btn_ColorPicker;
        private System.Windows.Forms.Button Btn_Fill;
        private System.Windows.Forms.PictureBox pb_currentColor;
        private System.Windows.Forms.Button Btn_ColorDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Btn_Clear;
        private System.Windows.Forms.Panel Panel_size;
        private System.Windows.Forms.Button btn_SmallLine;
        private System.Windows.Forms.Button Btn_MediumLine;
        private System.Windows.Forms.Button Btn_BigLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_Shape;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

