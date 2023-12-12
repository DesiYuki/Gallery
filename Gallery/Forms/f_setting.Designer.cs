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
            this.TabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tp_folder = new DevExpress.XtraTab.XtraTabPage();
            this.b_addPath = new DevExpress.XtraEditors.SimpleButton();
            this.b_delPath = new DevExpress.XtraEditors.SimpleButton();
            this.tl_path = new DevExpress.XtraTreeList.TreeList();
            this.tl_p_id = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tl_p_path = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl1)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.tp_folder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tl_path)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.TabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedTabPage = this.tp_folder;
            this.TabControl1.Size = new System.Drawing.Size(800, 450);
            this.TabControl1.TabIndex = 0;
            this.TabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tp_folder});
            // 
            // tp_folder
            // 
            this.tp_folder.Controls.Add(this.b_addPath);
            this.tp_folder.Controls.Add(this.b_delPath);
            this.tp_folder.Controls.Add(this.tl_path);
            this.tp_folder.Name = "tp_folder";
            this.tp_folder.Size = new System.Drawing.Size(698, 448);
            this.tp_folder.Text = "Пути для поиска";
            // 
            // b_addPath
            // 
            this.b_addPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b_addPath.ImageOptions.SvgImage")));
            this.b_addPath.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.b_addPath.Location = new System.Drawing.Point(13, 11);
            this.b_addPath.Name = "b_addPath";
            this.b_addPath.Size = new System.Drawing.Size(100, 25);
            this.b_addPath.TabIndex = 2;
            this.b_addPath.Text = "Добавить";
            this.b_addPath.Click += new System.EventHandler(this.b_addPath_Click);
            // 
            // b_delPath
            // 
            this.b_delPath.Enabled = false;
            this.b_delPath.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("b_delPath.ImageOptions.SvgImage")));
            this.b_delPath.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.b_delPath.Location = new System.Drawing.Point(13, 42);
            this.b_delPath.Name = "b_delPath";
            this.b_delPath.Size = new System.Drawing.Size(100, 25);
            this.b_delPath.TabIndex = 1;
            this.b_delPath.Text = "Удалить";
            this.b_delPath.Click += new System.EventHandler(this.b_delPath_Click);
            // 
            // tl_path
            // 
            this.tl_path.ActiveFilterEnabled = false;
            this.tl_path.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tl_p_id,
            this.tl_p_path});
            this.tl_path.Location = new System.Drawing.Point(119, 3);
            this.tl_path.Name = "tl_path";
            this.tl_path.OptionsBehavior.Editable = false;
            this.tl_path.OptionsView.ShowIndicator = false;
            this.tl_path.OptionsView.ShowRoot = false;
            this.tl_path.Size = new System.Drawing.Size(576, 442);
            this.tl_path.TabIndex = 0;
            // 
            // tl_p_id
            // 
            this.tl_p_id.Caption = "treeListColumn1";
            this.tl_p_id.FieldName = "treeListColumn1";
            this.tl_p_id.Name = "tl_p_id";
            this.tl_p_id.Visible = true;
            this.tl_p_id.VisibleIndex = 0;
            this.tl_p_id.Width = 49;
            // 
            // tl_p_path
            // 
            this.tl_p_path.Caption = "treeListColumn2";
            this.tl_p_path.FieldName = "treeListColumn2";
            this.tl_p_path.Name = "tl_p_path";
            this.tl_p_path.Visible = true;
            this.tl_p_path.VisibleIndex = 1;
            this.tl_p_path.Width = 525;
            // 
            // f_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_setting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.TabControl1)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.tp_folder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tl_path)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl TabControl1;
        private DevExpress.XtraTab.XtraTabPage tp_folder;
        private DevExpress.XtraTreeList.TreeList tl_path;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tl_p_id;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tl_p_path;
        private DevExpress.XtraEditors.SimpleButton b_addPath;
        private DevExpress.XtraEditors.SimpleButton b_delPath;
    }
}