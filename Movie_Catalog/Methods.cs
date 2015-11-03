using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Movie_Catalog
{
    public static class Methods
    {

        public static void Exit()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        public static void LoadFile()
        {
            Stream myStream = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Movie file (*.mkv, *.mov, *.avi, *.mp4, *.divx, *.mpeg, *.mpg)|*.mkv;*mov;*.avi;*.mp4;*.divx;*.mpeg;*.mpg";
            open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = open.OpenFile()) != null)
                    {
                        using(myStream)
                        {
                            // COde for reading stream 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not find file. Error: " + ex.Message);
                }
            }
        }

        public static bool LoginFunction(String login, String pass)
        {
            bool validation = true;
            MessageBox.Show(login + " " + pass);
            return validation;
        }
    }
}
