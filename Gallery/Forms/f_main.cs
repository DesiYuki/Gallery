using DevExpress.Utils.Behaviors.Common;
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
            flowLayoutPanel1.Controls.Clear();
        }

        private async Task LoadImagesAsync()
        {
            while (I < imgFiles.Count)
            {
                //if (I > 100)
                //    break;
                PictureBox pb = new PictureBox();
                pb.Image = await Task.Run(() => ResizeImage(imgFiles[I]));
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 100;
                pb.Height = 100;
                pb.Tag = I;
                pb.MouseClick += PBMouseClick;

                flowLayoutPanel1.Invoke((MethodInvoker)delegate
                {
                    flowLayoutPanel1.Controls.Add(pb);
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
            try
            {
                using (Image im = Image.FromFile(path))
                {
                    int minSize = 150;
                    Image resizedImage = im.GetThumbnailImage(minSize, (minSize * im.Height) / im.Width, null, IntPtr.Zero);
                    return resizedImage;
                }
            }
            catch (Exception)
            {
                return null;
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
            if (pbView.Visible)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (imgShow - 1 != -1)
                    {
                        int tagimg = (int)flowLayoutPanel1.Controls[imgShow - 1].Tag;                    
                        pbView.Image = GetCopyImage(imgFiles[tagimg]);
                        imgShow = tagimg;
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if ((imgShow + 1) < flowLayoutPanel1.Controls.Count)
                    {
                        int tagimg = (int)flowLayoutPanel1.Controls[imgShow + 1].Tag;
                        pbView.Image = GetCopyImage(imgFiles[tagimg]);
                        imgShow = tagimg;
                    }
                }
            }
        }
    }
}
