using Gallery.Classes;
using Gallery.Forms;
using Gallery.Models;
using System;
using System.Windows.Forms;

namespace Gallery
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new f_main());
        }
    }
}
