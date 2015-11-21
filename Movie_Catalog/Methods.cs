using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity.Validation;

namespace Movie_Catalog
{
    public static class Methods
    {

        #region Exit
        /// <summary>
        /// When called, closes application
        /// </summary>
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
        /// <summary>
        /// Function that takes a file from the OpenFileDialog, then  
        /// opens AddMovie() function with a filename parameter
        /// </summary>
        public static void LoadFile()
        { //Function that takes a file, then file name and add then call a function AddMovie
            Stream myStream = null;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Movie file (*.mkv, *.mov, *.avi, *.mp4, *.divx, *.mpeg, *.mpg)|*.mkv;*mov;*.avi;*.mp4;*.divx;*.mpeg;*.mpg";
            //open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (Properties.Settings.Default.FolderPath != null)
            {
                open.InitialDirectory = Properties.Settings.Default.FolderFilePath;
            }

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
                                Properties.Settings.Default.FolderFilePath = fs.Name;
                                Properties.Settings.Default.Save();
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
        /// <summary>
        /// Opens Folder Browser and returns the path of selected folder
        /// </summary>
        /// <returns>Path to the directory or null</returns>
        public static string LoadFromDirecotory()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (Properties.Settings.Default.FolderPath != null)
                fbd.SelectedPath = Properties.Settings.Default.FolderPath;

            if (fbd.ShowDialog() == DialogResult.OK){
                Properties.Settings.Default.FolderPath = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                return fbd.SelectedPath;
            }
            else
                return null;
        }
        /// <summary>
        /// Add all selected films from given directory and split them into the list
        /// </summary>
        /// <param name="directory">A directory from which we take films</param>
        /// <returns>Returns the list of movies from given directory</returns>
        public static List<String> GetAllFilesToList(String directory)
        {
            return Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories).Where(
            s => s.EndsWith(".mkv") | s.EndsWith(".mov") | s.EndsWith(".avi") | s.EndsWith(".mp4") | s.EndsWith(".divx") | s.EndsWith(".mpeg") |
                s.EndsWith(".mpg")).ToList();
        }

        /// <summary>
        /// Adds a movie to database taking into consideration all possible exceptions
        /// </summary>
        /// <param name="FileName">Name of the movie filename</param>
        public static void AddMovie(string FileName)
        { //Adds a movie id and movie name to database
            try
            {
                //Properties.Settings.Default.MovieNo = 7;
                //Properties.Settings.Default.Save();
                MovieDatabaseEntities db = new MovieDatabaseEntities();
                MainMovieList objMovie = new MainMovieList();

                if (db.MainMovieLists.Any(o => o.File_Name == FileName))
                {
                    Console.WriteLine(FileName + " is already in the MainMovieList table");
                }
                else
                {
                    objMovie.File_Name = FileName;

                    db.MainMovieLists.Add(objMovie);
                    db.SaveChanges();
                }

                int usrId = Form1.getCurrentUserID();
                Console.WriteLine("Current username: " + usrId + "\n");

                    if (db.Favourite_Hated.Any(o => o.FilmID == objMovie.ID && o.UserID == usrId))
                    {
                        Console.WriteLine(FileName + " is already in the Favourite_Hated table");
                    }
                    else
                    {
                        Console.WriteLine("Adding " + FileName + " to the Favourite_Hated table for user with id: " + usrId);
                        User usr = new User();
                        var searchs = db.Users.SingleOrDefault(o => o.UserID == usrId);
                        AddFavouriteOrHated(-1, searchs.Username, FileName);
                    }
                //Jezeli nie dasz sobie rady ze stworzeniem query: stworz funckje foreach i sprawdz czy dany film ma konkretny usrname i filmid

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

        #region LogIn
        /// <summary>
        /// Validate if a user exists in the database and if the password is correct
        /// </summary>
        /// <param name="login">User name given in the textbox</param>
        /// <param name="pass">Password of user given in the textbox</param>
        /// <returns>True if succeded, false if failed</returns>
        public static bool LoginFunction(String login, String pass)
        {
            bool validation = false;

            // Code for validation from database
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            foreach (var user in db.Users) {
                if (user.Username == login && user.Password == pass)
                {
                    validation = true;
                }
            }
            return validation;
        }

        #endregion

        #region dataGridView functions

        /// <summary>
        /// Set information to be displayed in dataGridView1
        /// </summary>
        /// <returns>Return list of movies to add to dataGridView1</returns>
        public static List<Movies> AddItemToList()
        {
            int UserID = Form1.getCurrentUserID();

            MovieDatabaseEntities db = new MovieDatabaseEntities();

            var movieQuery = from mml in db.MainMovieLists
                             join fh in db.Favourite_Hated on new { ID = mml.ID } equals new { ID = fh.FilmID } into fh_join
                             from fh in fh_join.DefaultIfEmpty()
                             where
                               fh.UserID == UserID
                             select new Movies
                             {
                                 MovieID = mml.ID,
                                 Movie_Name = mml.Movie_Name,
                                 File_Name = mml.File_Name,
                                 LikeOrDislike = fh.LikeOrDislike == 1 ? "Favourite" : (fh.LikeOrDislike == 0 ? "Hated" : "")
                             };

            List<Movies> movieList = movieQuery.ToList();

            return movieList;
        }

        /// <summary>
        /// Allows to change name of film if we click on proper column in dataGridView1
        /// </summary>
        /// <param name="moviename">Movie name we want to check for.</param>
        /// <param name="filename">File name of the file we want to change</param>
        public static void MovieNameChange(string moviename, string filename){
            try{
            MovieDatabaseEntities db = new MovieDatabaseEntities();

            var result = db.MainMovieLists.SingleOrDefault(o => o.File_Name == filename);
            if (result.Movie_Name != moviename)
            {
                result.Movie_Name = moviename;
                db.SaveChanges();
            }
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

        /// <summary>
        /// Adds information if movie is added to favourites, hated or none of them
        /// </summary>
        /// <param name="whichcase">Determines if movie is added to favourites or hated</param>
        /// <param name="UserName">The name of the user that we are login in</param>
        /// <param name="film">The name of file that we want to set</param>
        public static void AddFavouriteOrHated(int whichcase, string UserName, string film)
        {
            try
            {
                MovieDatabaseEntities db = new MovieDatabaseEntities();

                var result = db.MainMovieLists.SingleOrDefault(o => o.File_Name == film);

                var usr = db.Users.SingleOrDefault(o => o.Username == UserName);

                int ID = usr.UserID;

                var search = db.Favourite_Hated.SingleOrDefault(o => o.FilmID == result.ID && o.UserID == ID);

                if (search == null)
                {
                    Favourite_Hated favourite = new Favourite_Hated();

                    favourite.FilmID = result.ID;
                    favourite.UserID = usr.UserID;
                    favourite.LikeOrDislike = whichcase;

                    db.Favourite_Hated.Add(favourite);
                    db.SaveChanges();
                }
                else if (search.LikeOrDislike != whichcase)
                {
                    search.LikeOrDislike = whichcase;
                    db.SaveChanges();
                }
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
    }
}
