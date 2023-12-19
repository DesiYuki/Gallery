namespace Gallery.Forms
{
    partial class F_main
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barTop = new DevExpress.XtraBars.Bar();
            this.b_setting = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GalleryControlDX = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.p_bot = new DevExpress.XtraEditors.PanelControl();
            this.l_count = new System.Windows.Forms.Label();
            this.progressBarLoad = new DevExpress.XtraEditors.ProgressBarControl();
            this.defaultBarAndDockingController1 = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            this.ZoomPictureBox1 = new Gallery.CustomComponents.yZoomPicturBox();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GalleryControlDX)).BeginInit();
            this.GalleryControlDX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_bot)).BeginInit();
            this.p_bot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarLoad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultBarAndDockingController1.Controller)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTop});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.b_setting});
            this.barManager1.MainMenu = this.barTop;
            this.barManager1.MaxItemId = 9;
            // 
            // barTop
            // 
            this.barTop.BarName = "Главное меню";
            this.barTop.DockCol = 0;
            this.barTop.DockRow = 0;
            this.barTop.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.b_setting)});
            this.barTop.OptionsBar.DrawBorder = false;
            this.barTop.OptionsBar.DrawDragBorder = false;
            this.barTop.OptionsBar.UseWholeRow = true;
            this.barTop.Text = "Главное меню";
            // 
            // b_setting
            // 
            this.b_setting.Caption = "Настройки";
            this.b_setting.Id = 2;
            this.b_setting.Name = "b_setting";
            this.b_setting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.b_setting_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(937, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 548);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(937, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 528);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(937, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 528);
            // 
            // GalleryControlDX
            // 
            this.GalleryControlDX.Controls.Add(this.galleryControlClient1);
            this.GalleryControlDX.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.GalleryControlDX.Gallery.AllowFilter = false;
            this.GalleryControlDX.Gallery.ImageSize = new System.Drawing.Size(100, 100);
            this.GalleryControlDX.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            this.GalleryControlDX.Gallery.ItemDoubleClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.GalleryControlDX_ItemDoubleClick);
            this.GalleryControlDX.Location = new System.Drawing.Point(0, 20);
            this.GalleryControlDX.Name = "GalleryControlDX";
            this.GalleryControlDX.Size = new System.Drawing.Size(937, 498);
            this.GalleryControlDX.TabIndex = 6;
            this.GalleryControlDX.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.GalleryControlDX;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(916, 494);
            // 
            // p_bot
            // 
            this.p_bot.Controls.Add(this.l_count);
            this.p_bot.Controls.Add(this.progressBarLoad);
            this.p_bot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_bot.Location = new System.Drawing.Point(0, 518);
            this.p_bot.Name = "p_bot";
            this.p_bot.Size = new System.Drawing.Size(937, 30);
            this.p_bot.TabIndex = 11;
            // 
            // l_count
            // 
            this.l_count.AutoSize = true;
            this.l_count.Location = new System.Drawing.Point(5, 8);
            this.l_count.Name = "l_count";
            this.l_count.Size = new System.Drawing.Size(19, 13);
            this.l_count.TabIndex = 0;
            this.l_count.Text = "---";
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBarLoad.Location = new System.Drawing.Point(2, 2);
            this.progressBarLoad.MenuManager = this.barManager1;
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(933, 26);
            this.progressBarLoad.TabIndex = 1;
            // 
            // defaultBarAndDockingController1
            // 
            // 
            // ZoomPictureBox1
            // 
            this.ZoomPictureBox1.Location = new System.Drawing.Point(0, 20);
            this.ZoomPictureBox1.Name = "ZoomPictureBox1";
            this.ZoomPictureBox1.Size = new System.Drawing.Size(121, 83);
            this.ZoomPictureBox1.TabIndex = 16;
            this.ZoomPictureBox1.Visible = false;
            this.ZoomPictureBox1.FillMouseClick += new System.Windows.Forms.MouseEventHandler(this.ZoomPictureBox1_FillMouseClick);
            // 
            // F_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 548);
            this.Controls.Add(this.ZoomPictureBox1);
            this.Controls.Add(this.GalleryControlDX);
            this.Controls.Add(this.p_bot);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "F_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gallery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GalleryControlDX)).EndInit();
            this.GalleryControlDX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.p_bot)).EndInit();
            this.p_bot.ResumeLayout(false);
            this.p_bot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarLoad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultBarAndDockingController1.Controller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barTop;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private DevExpress.XtraBars.BarButtonItem b_setting;
        private DevExpress.XtraEditors.PanelControl p_bot;
        private System.Windows.Forms.Label l_count;
        private DevExpress.XtraBars.DefaultBarAndDockingController defaultBarAndDockingController1;
        private CustomComponents.yZoomPicturBox ZoomPictureBox1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarLoad;
        private DevExpress.XtraBars.Ribbon.GalleryControl GalleryControlDX;
    }
}