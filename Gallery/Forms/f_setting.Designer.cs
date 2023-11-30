namespace Gallery.Forms
{
    partial class f_setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_setting));
            this.l_path = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.b_delPath = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.b_addPath = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.b_save = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.l_path)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_path
            // 
            this.l_path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_path.Location = new System.Drawing.Point(2, 57);
            this.l_path.Name = "l_path";
            this.l_path.Size = new System.Drawing.Size(796, 391);
            this.l_path.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.l_path);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(800, 450);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Пути для поиска файлов";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.b_delPath);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.b_addPath);
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(796, 34);
            this.panelControl2.TabIndex = 7;
            // 
            // b_delPath
            // 
            this.b_delPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_delPath.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.b_delPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b_delPath.ImageOptions.SvgImage")));
            this.b_delPath.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.b_delPath.Location = new System.Drawing.Point(142, 2);
            this.b_delPath.Name = "b_delPath";
            this.b_delPath.Size = new System.Drawing.Size(100, 30);
            this.b_delPath.TabIndex = 6;
            this.b_delPath.Text = "Удалить";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(122, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(20, 30);
            this.panelControl3.TabIndex = 7;
            // 
            // b_addPath
            // 
            this.b_addPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_addPath.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.b_addPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b_addPath.ImageOptions.SvgImage")));
            this.b_addPath.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.b_addPath.Location = new System.Drawing.Point(22, 2);
            this.b_addPath.Name = "b_addPath";
            this.b_addPath.Size = new System.Drawing.Size(100, 30);
            this.b_addPath.TabIndex = 5;
            this.b_addPath.Text = "Добавить";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(20, 30);
            this.panelControl4.TabIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.b_save);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 411);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 39);
            this.panelControl1.TabIndex = 6;
            // 
            // b_save
            // 
            this.b_save.Dock = System.Windows.Forms.DockStyle.Right;
            this.b_save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b_save.ImageOptions.SvgImage")));
            this.b_save.Location = new System.Drawing.Point(698, 2);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(100, 35);
            this.b_save.TabIndex = 6;
            this.b_save.Text = "Сохранить";
            // 
            // f_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_setting";
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.l_path)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl l_path;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton b_delPath;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton b_addPath;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton b_save;
    }
}