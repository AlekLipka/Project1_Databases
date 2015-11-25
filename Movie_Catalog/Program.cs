using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Catalog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            if (!db.Database.Exists())
                Application.Run(new AddDatabaseSplashScreen());
            Application.Run(new MainApplicationWindow());
        }
    }
}
