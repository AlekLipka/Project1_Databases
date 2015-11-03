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
using System.Data.Entity.Validation;

namespace Movie_Catalog
{
    public static class Methods
    {

        #region Exit

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

        #endregion


        #region FileLoadingToDatabase
        public static void LoadFile()
        { //Function that takes a file, then file name and add then call a function AddMovie
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
                            string Name;
                            FileStream fs = myStream as FileStream;
                            
                            if (fs != null)
                            {
                                Name = System.IO.Path.GetFileNameWithoutExtension(fs.Name);
                                AddMovie(Name);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not find file. Error: " + ex.Message);
                }
            }
        }

        public static string LoadFromDirecotory()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        public static List<String> GetAllFilesToList(String directory)
        {
            return Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(
            s => s.EndsWith(".mkv") | s.EndsWith(".mov") | s.EndsWith(".avi") | s.EndsWith(".mp4") | s.EndsWith(".divx") | s.EndsWith(".mpeg") |
                s.EndsWith(".mpg")).ToList();
        }


        public static void AddMovie(string FileName)
        { //Adds a movie id and movie name to database
            try
            {
                Properties.Settings.Default.MovieNo += 1;
                Properties.Settings.Default.Save();
                MovieDatabaseEntities db = new MovieDatabaseEntities();

                MainMovieList objMovie = new MainMovieList();
                objMovie.ID = Properties.Settings.Default.MovieNo;
                objMovie.File_Name = FileName;

                db.MainMovieLists.Add(objMovie);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            { //In case of error while adding stuff to database
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        #endregion

        public static bool LoginFunction(String login, String pass)
        {
            bool validation = true;
            MessageBox.Show(login + " " + pass);
            return validation;
        }

        /*
        public static List<MainMovieList> AddItemToListView()
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();

            var movieQuery = from mov in db.MainMovieLists select mov;

            List<MainMovieList> movieList = movieQuery.ToList();

            return movieList;
        }*/
    }
}
