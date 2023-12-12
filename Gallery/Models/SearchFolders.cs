using Gallery.Classes;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace Gallery.Models
{
    /// <summary>
    /// Класс таблицы SearchFolders
    /// </summary>
    public class SearchFolders
    {
        /// <summary>
        /// Индекс записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Путь для поиска изображений
        /// </summary>
        public string Path { get; set; }
    }
}
