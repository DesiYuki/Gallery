using System;
using System.Drawing;

namespace Gallery.Classes
{
    static class ImageControl
    {
        static public string[] fileExtension = { ".png", ".jpeg", ".jpg", ".bmp" };

        /// <summary>
        /// Создает миниатюру изображения
        /// </summary>
        static public Image ResizeImage(string path, int minSize, string nameSave)
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
        static public Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }
    }
}
