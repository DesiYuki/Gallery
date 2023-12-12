using Gallery.Models;
using LiteDB;
using System.Collections.Generic;

namespace Gallery.Classes
{
    /// <summary>
    /// Класс с константами и статическими переменными 
    /// </summary>
    public class Global
    {
        /// <summary>
        /// Имя файла для DB
        /// </summary>
        public static DBControl DBControl = new DBControl("ImageData");
        static IniFiles ini = new IniFiles("setting.ini");

        /// <summary>
        /// Возвращает значение из ini-файла 
        /// </summary>
        public static string GetIniParameter(string section, string parameter, string default_ = "")
        {
            return ini.KeyExists(section, parameter) ? ini.ReadINI(section, parameter) : default_;
        }

        /// <summary>
        /// Записывает значение в ini-файл
        /// </summary>
        public static void SetIniParameter(string section, string parameter, string val)
        {
            ini.WriteINI(section, parameter, val);
        }
    }
}
