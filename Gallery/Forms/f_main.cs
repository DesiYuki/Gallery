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
    public partial class f_main : XtraForm
    {
        static string[] fileExtension = { ".png", ".jpeg", ".jpg", ".bmp" };
        Thread LoadImageThread;

        public f_main()
        {
            InitializeComponent();
            LoadImageThread = new Thread(LoadImage);
            LoadImageThread.Start();
        }

        void LoadImage()
        {
            List<string> newImages = searchImage();

            progressBarLoad.Invoke(new Action(() => {
                progressBarLoad.Properties.Maximum = newImages.Count;
                progressBarLoad.Position = 0;
            }));

            if (!Directory.Exists("MinImg")) Directory.CreateDirectory("MinImg");

            int i = 1;
            foreach (string img in newImages)
            {
                List<ImageInfo> SearchImage = Global.DBControl.selectImageInfoByPath(img);
                if (SearchImage.Count == 0)
                {
                    SearchImage.Clear();
                    SearchImage.Add(AddNewImageDB(img));
                }

                GalleryItem galleryItem = new GalleryItem();
                galleryItem.ItemClick += Gallery_ItemClick;
                galleryItem.Tag = img;

                if (!File.Exists(SearchImage[0].MinImgPath))
                {
                    ResizeImage(img, 100, SearchImage[0].MinImgPath);
                }
                galleryItem.ImageOptions.Image = GetCopyImage(SearchImage[0].MinImgPath);

                string FoldersName = Directory.GetParent(img).Name;
                GalleryItemGroup targetGroup = galleryControl1.Gallery.Groups.Cast<GalleryItemGroup>().FirstOrDefault(group => group.Caption == FoldersName);

                galleryControl1.Invoke(new Action(() => {
                    targetGroup.Items.Add(galleryItem);
                }));
                progressBarLoad.Invoke(new Action(() => {
                    progressBarLoad.Position = i;
                    progressBarLoad.Update();
                }));
                l_count.Invoke(new Action(() => {
                    l_count.Text = i + "/" + newImages.Count.ToString();
                }));
                i++;
            }
            progressBarLoad.Invoke(new Action(() =>
            {
                progressBarLoad.Visible = false;
            }));
        }

        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string img = e.Item.Tag.ToString();
            ZoomPicturBox1.setIMG(img);
            ZoomPicturBox1.Visible = true;
            SelectImage = e.Item;
            int index = e.Item.GalleryGroup.Items.IndexOf(e.Item);
        }

        GalleryItem SelectImage;

        private void ZoomPicturBox1_FillMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ZoomPicturBox1.Visible = false;
                SelectImage = null;
            }
            else if (e.Location.X <= ZoomPicturBox1.Width / 10 || e.Location.X >= ZoomPicturBox1.Width - ZoomPicturBox1.Width / 10)
            {
                int imageIndex = SelectImage.GalleryGroup.Items.IndexOf(SelectImage);
                int groupIndex = galleryControl1.Gallery.Groups.IndexOf(SelectImage.GalleryGroup);

                if (e.Location.X <= ZoomPicturBox1.Width / 10)
                {
                    if (imageIndex == 0)
                    {
                        while (true)
                        {
                            if (groupIndex == 0)
                                groupIndex = galleryControl1.Gallery.Groups.Count - 1;
                            else
                                groupIndex--; 
                            if(galleryControl1.Gallery.Groups[groupIndex].Items.Count != 0)
                                break;
                        }
                        imageIndex = SelectImage.GalleryGroup.Items.Count - 1;
                    }
                    else
                        imageIndex--;
                    
                }
                else if (e.Location.X >= ZoomPicturBox1.Width - ZoomPicturBox1.Width / 10)
                {
                    if (imageIndex == SelectImage.GalleryGroup.Items.Count - 1)
                    {
                        imageIndex = 0;
                        while (true)
                        {
                            if (groupIndex == galleryControl1.Gallery.Groups.Count - 1)
                                groupIndex = 0;
                            else
                                groupIndex++;
                            if (galleryControl1.Gallery.Groups[groupIndex].Items.Count != 0)
                                break;
                        }
                    }
                    else
                        imageIndex++;
                }

                SelectImage = galleryControl1.Gallery.Groups[groupIndex].Items[imageIndex];
                ZoomPicturBox1.setIMG(SelectImage.Tag.ToString());
            }
        }

        /// <summary>
        /// Сохраняет данные о изображение в бд
        /// </summary>
        ImageInfo AddNewImageDB(string pathImg)
        {
            int LastName = Convert.ToInt32(Global.GetIniParameter("ImageMin", "LastName", "0"));
            LastName++;

            string MinImgPath = "MinImg\\" + LastName + ".bmp";
            Image ImageMin = ResizeImage(pathImg, 100, MinImgPath);

            ImageInfo NewImg = new ImageInfo { Path = pathImg, MinImgPath = MinImgPath };
            Global.DBControl.Insert(NewImg);

            Global.SetIniParameter("ImageMin", "LastName", LastName.ToString());
            return NewImg;
        }

        /// <summary>
        /// Получает список всех изображений
        /// </summary>
        List<string> searchImage()
        {
            List<string> Files = new List<string>();

            foreach (SearchFolders folder in Global.DBControl.selectAll_SearchFolders())
                if (!Directory.Exists(folder.Path))
                    Global.DBControl.Delete(folder);
                else
                    foreach (string file in Directory.GetFileSystemEntries(folder.Path, "*", SearchOption.AllDirectories))
                        if (fileExtension.Contains(Path.GetExtension(file).ToLower()))
                        {
                            Files.Add(file);
                            // создание всех групп
                            string FoldersName = Directory.GetParent(file).Name;
                            GalleryItemGroup targetGroup = galleryControl1.Gallery.Groups.Cast<GalleryItemGroup>().FirstOrDefault(group => group.Caption == FoldersName);
                            if (targetGroup == null)
                            {
                                GalleryItemGroup newGroup = new GalleryItemGroup { Caption = FoldersName };
                                galleryControl1.Invoke(new Action(() => {
                                    galleryControl1.Gallery.Groups.Add(newGroup);
                                }));
                            }
                            //
                        }
            return Files;
        }

        /// <summary>
        /// Создает миниатюру изображения
        /// </summary>
        Image ResizeImage(string path, int minSize, string nameSave)
        {
            using (Image im = Image.FromFile(path))
            {
                Image resizedImage = im.GetThumbnailImage(minSize, (minSize * im.Height) / im.Width, null, IntPtr.Zero);
                resizedImage.Save(nameSave);
                return resizedImage;
            }
        }

        /// <summary>
        /// возвращает копию изображения
        /// </summary>
        Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
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
    }
}
