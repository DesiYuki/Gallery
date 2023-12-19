using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Gallery.Classes;
using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gallery.Forms
{
    public partial class F_main : XtraForm
    {
        Thread LoadImageThread;

        public F_main()
        {
            InitializeComponent();
            ZoomPictureBox1.Dock = DockStyle.Fill;
            _ = LoadImage();
        }

        List<string> Images;

        async Task LoadImage()
        {
            if (!Directory.Exists("MinImg")) Directory.CreateDirectory("MinImg");
            Images = await Task.Run(() => SearchImage());

            progressBarLoad.Properties.Maximum = Images.Count;
            progressBarLoad.Position = 0;

            LoadImageThread = new Thread(LoadIMG);
            LoadImageThread.Start();
        }

        /// <summary>
        /// Получает список всех изображений
        /// </summary>
        List<string> SearchImage()
        {
            List<string> Files = new List<string>();

            foreach (SearchFolders folder in Global.DBControl.SelectAll_SearchFolders())
                if (!Directory.Exists(folder.Path))
                    Global.DBControl.Delete(folder);
                else
                    foreach (string file in Directory.GetFileSystemEntries(folder.Path, "*", SearchOption.AllDirectories))
                        if (ImageControl.fileExtension.Contains(Path.GetExtension(file).ToLower()))//добавить исключение папку с миниатюрами
                        {
                            Files.Add(file);

                            string FoldersName = Directory.GetParent(file).Name;
                            GalleryItemGroup targetGroup = GalleryControlDX.Gallery.Groups.Cast<GalleryItemGroup>().FirstOrDefault(group => group.Caption == FoldersName);
                            if (targetGroup == null)
                            {
                                GalleryItemGroup newGroup = new GalleryItemGroup { Caption = FoldersName };
                                GalleryControlDX.Invoke(new Action(() => {
                                    GalleryControlDX.Gallery.Groups.Add(newGroup);
                                }));
                            }
                        }
            return Files;
        }

        void LoadIMG()
        {
            for (int i = 0; i < Images.Count; i++)
            {
                string img = Images[i];
                string pathMin = "MinImg" + img.Remove(0, 2);

                if (!File.Exists(pathMin)) // проверка миниатюры
                {
                    if (!Directory.Exists(Directory.GetParent(pathMin).FullName)) Directory.CreateDirectory(Directory.GetParent(pathMin).FullName);
                    ImageControl.ResizeImage(img, 100, pathMin);
                    progressBarLoad.Invoke(new Action(() =>
                    {
                        progressBarLoad.Position = i;
                    }));
                    l_count.Invoke(new Action(() =>
                    {
                        l_count.Text = i + 1 + "/" + progressBarLoad.Properties.Maximum.ToString();
                    }));
                }

                GalleryItem galleryItem = new GalleryItem
                {
                    Tag = img
                };
                galleryItem.ImageOptions.Image = ImageControl.GetCopyImage(pathMin);

                string FoldersName = Directory.GetParent(img).Name;
                GalleryItemGroup targetGroup = GalleryControlDX.Gallery.Groups.Cast<GalleryItemGroup>().FirstOrDefault(group => group.Caption == FoldersName);

                GalleryControlDX.Invoke(new Action(() => {
                    targetGroup.Items.Add(galleryItem);
                }));
                if (i % (int)(Images.Count * 0.10) == 0)
                {
                    GalleryControlDX.Invoke(new Action(() =>
                    {
                        GalleryControlDX.Update();
                    }));
                    progressBarLoad.Invoke(new Action(() =>
                    {
                        progressBarLoad.Position = i;
                        progressBarLoad.Update();
                    }));
                    l_count.Invoke(new Action(() =>
                    {
                        l_count.Text = i + 1 + "/" + progressBarLoad.Properties.Maximum.ToString();
                    }));
                }
            }
            l_count.Invoke(new Action(() =>
            {
                l_count.Text = "Изображений: " + Images.Count;
            }));
            progressBarLoad.Invoke(new Action(() =>
            {
                progressBarLoad.Visible = false;
            }));
        }

        GalleryItem SelectImage;

        private void ZoomPictureBox1_FillMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ZoomPictureBox1.Visible = false;
                SelectImage = null;
            }
            else if (e.Location.X <= ZoomPictureBox1.Width / 8 || e.Location.X >= ZoomPictureBox1.Width - ZoomPictureBox1.Width / 8)
            {
                int imageIndex = SelectImage.GalleryGroup.Items.IndexOf(SelectImage);
                int groupIndex = GalleryControlDX.Gallery.Groups.IndexOf(SelectImage.GalleryGroup);

                if (e.Location.X <= ZoomPictureBox1.Width / 8)
                {
                    if (imageIndex == 0)
                    {
                        while (true)
                        {
                            if (groupIndex == 0)
                                groupIndex = GalleryControlDX.Gallery.Groups.Count - 1;
                            else
                                groupIndex--; 
                            if(GalleryControlDX.Gallery.Groups[groupIndex].Items.Count != 0)
                                break;
                        }
                        imageIndex = SelectImage.GalleryGroup.Items.Count - 1;
                    }
                    else
                        imageIndex--;
                    
                }
                else if (e.Location.X >= ZoomPictureBox1.Width - ZoomPictureBox1.Width / 8)
                {
                    if (imageIndex == SelectImage.GalleryGroup.Items.Count - 1)
                    {
                        imageIndex = 0;
                        while (true)
                        {
                            if (groupIndex == GalleryControlDX.Gallery.Groups.Count - 1)
                                groupIndex = 0;
                            else
                                groupIndex++;
                            if (GalleryControlDX.Gallery.Groups[groupIndex].Items.Count != 0)
                                break;
                        }
                    }
                    else
                        imageIndex++;
                }

                SelectImage = GalleryControlDX.Gallery.Groups[groupIndex].Items[imageIndex];
                ZoomPictureBox1.setIMG(SelectImage.Tag.ToString());
            }
        }

        private void b_setting_ItemClick(object sender, ItemClickEventArgs e)
        {
            new f_setting().ShowDialog();
        }

        private void f_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadImageThread.Abort();
        }

        private void GalleryControlDX_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {
            string img = e.Item.Tag.ToString();
            ZoomPictureBox1.setIMG(img);
            ZoomPictureBox1.Visible = true;
            SelectImage = e.Item;
        }
    }
}
