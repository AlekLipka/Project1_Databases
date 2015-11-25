using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Catalog
{
    public partial class AddDatabaseSplashScreen : Form
    {
        /// <summary>
        /// Splash Screen constructor
        /// </summary>
        public AddDatabaseSplashScreen()
        {
            InitializeComponent();
            this.BringToFront();
        }
        /// <summary>
        /// Event handler for splash screen - reveal the sql script in textbox
        /// </summary>
        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            monoFlat_Button1.Visible = false;
            textBox1.Visible = true;
            monoFlat_HeaderLabel1.Visible = true;
            textBox1.Text = Properties.Resources.MovieDatabase_generate_script.ToString();
        }
        /// <summary>
        /// Exit Button - exits application if the database don't exist or contninue to the program
        /// </summary>
        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            if (!db.Database.Exists())
            {
                Application.Exit();
            }
            this.Dispose();
        }
    }
}
