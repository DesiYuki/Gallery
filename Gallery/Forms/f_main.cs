using DevExpress.Utils.Behaviors.Common;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallery.Forms
{
    public partial class f_main : XtraForm
    {
        #region Vars

        List<string> imgFiles = new List<string>();
        static int imgShow = -1;
        static int I;

        #endregion

        public f_main()
        {
            InitializeComponent();
            I = 0;
        }

        private void b_addPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            FillingFileList(folderBrowserDialog1.SelectedPath);

            b_addPath.Enabled = false;
            b_clear.Enabled = false;
            p_loading.Visible = true;
            
            label1.Text = "0/" + imgFiles.Count;
            progressBarControl1.Properties.Maximum = imgFiles.Count;
            
            LoadImagesAsync();
        }

        private void b_clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            I = 0;
            imgFiles.Clear();
            galleryControl1.Gallery.Groups[0].Items.Clear();
        }

        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            imgShow = (int)(sender as GalleryItem).Tag;
            pbView.Image = GetCopyImage(imgFiles[imgShow]);
            pbView.Visible = true;
        }

        private async Task LoadImagesAsync()
        {
            while (I < imgFiles.Count)
            {
                GalleryItem galleryItem = new GalleryItem();
                galleryItem.Tag = I;
                galleryItem.ItemClick += Gallery_ItemClick;
                galleryItem.ImageOptions.Image = await Task.Run(() => ResizeImage(imgFiles[I]));

                galleryControl1.Invoke((MethodInvoker)delegate
                { 
                    galleryControl1.Gallery.Groups[0].Items.Add(galleryItem); 
                });

                progressBarControl1.Position = I;
                I++;

                label1.Invoke((MethodInvoker)delegate
                {
                    label1.Text = I + "/" + imgFiles.Count;
                });
            }

            p_loading.Invoke((MethodInvoker)delegate
            {
                p_loading.Visible = false;
                b_addPath.Enabled = true;
                b_clear.Enabled = true;
            });
        }

        private void FillingFileList(string url)
        {
            string[] files = Directory.GetFileSystemEntries(url, "*", SearchOption.AllDirectories);
            foreach (string f in files)
                if (Global.fileExtension.Contains(Path.GetExtension(f).ToLower()) && !imgFiles.Contains(f))
                    imgFiles.Add(f);
        }

        private Image ResizeImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                int minSize = 100;
                Image resizedImage = im.GetThumbnailImage(minSize, (minSize * im.Height) / im.Width, null, IntPtr.Zero);
                return resizedImage;
            }
        }

        private Image GetCopyImage(string path)
        {
            try
            {
                using (Image im = Image.FromFile(path))
                {
                    Bitmap bm = new Bitmap(im);
                    return bm;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void PBMouseClick(object sender, MouseEventArgs e)
        {
            imgShow = (int)(sender as PictureBox).Tag;
            pbView.Image = GetCopyImage(imgFiles[imgShow]);
            pbView.Visible = true;
        }

        private void pbView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pbView.Visible = false;
                imgShow = -1;
            }
        }

        private void f_main_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
