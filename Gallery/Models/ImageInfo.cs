namespace Gallery.Models
{
    /// <summary>
    /// Класс таблицы ImageInfo
    /// </summary>
    public class ImageInfo
    {
        /// <summary>
        /// Индекс записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Путь к изображению
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Путь к миниатюре изображения
        /// </summary>
        public string MinImgPath { get; set; }
    }
}
