using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_Catalog
{
    public partial class ChangePlaylistNameMessageBox : Form
    {
        public ChangePlaylistNameMessageBox()
        {
            InitializeComponent();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accept_Button_Click(object sender, EventArgs e)
        {
            MainApplicationWindow.changeNameOfPlaylist(monoFlat_TextBox1.Text);
            this.Close();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {

        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
