using MonoFlat;
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
    public partial class PlaylistsManagement : Form
    {
        public PlaylistsManagement()
        {
            InitializeComponent();
        }

        private Movies currentMovie;



        /// <summary>
        /// Create checkbox in PlaylistsManagement form
        /// </summary>
        /// <param name="i">Number of user's playlists</param>
        /// <param name="movie">Movie that we want to add to playlists</param>
        public void createPlaylistCheckbox(int i, Movies movie)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var userID = MainApplicationWindow.getCurrentUserID();

            var pl =
            (from playlist in db.List_Of_Playlists
             where playlist.UserID == userID && playlist.ID == i + 1
             select playlist).FirstOrDefault();

            if (pl != null)
            {
                if (Add_Movie_To_Playlist_Panel.Controls.Count == 0)
                {
                    MonoFlat_CheckBox checkBox = new MonoFlat_CheckBox();
                    checkBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                    checkBox.Width = Add_Movie_To_Playlist_Panel.Width - 30;
                    checkBox.Height = 20;
                    checkBox.Text = pl.Playlist_Name;
                    checkBox.Location = new Point(0, 0);
                    int tag = i + 1;
                    checkBox.Tag = tag;
                    Add_Movie_To_Playlist_Panel.Controls.Add(checkBox);
                }
                else
                {
                    int maxi = 0;
                    foreach (MonoFlat_CheckBox chb in Add_Movie_To_Playlist_Panel.Controls)
                    {
                        if (Int32.Parse(chb.Tag.ToString()) > maxi)
                        {
                            maxi = Int32.Parse(chb.Tag.ToString());
                        }
                    }

                    foreach (MonoFlat_CheckBox item in Add_Movie_To_Playlist_Panel.Controls)
                    {
                        if (item.Tag.Equals(maxi))
                        {
                            MonoFlat_CheckBox prevCheckBox = item;

                            MonoFlat_CheckBox checkBox = new MonoFlat_CheckBox();
                            checkBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                            checkBox.Width = Add_Movie_To_Playlist_Panel.Width - 30;
                            checkBox.Height = 20;
                            checkBox.Text = pl.Playlist_Name;
                            checkBox.Location = new Point(0, prevCheckBox.Bounds.Bottom + 6);
                            int tag = i + 1;
                            checkBox.Tag = tag;
                            Add_Movie_To_Playlist_Panel.Controls.Add(checkBox);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds all checkboxes to Add_Movie_To_Playlist_Panel for each playlist
        /// </summary>
        public void AddAllPlaylistCheckBoxes(Movies movie)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var UserID = MainApplicationWindow.getCurrentUserID();

            currentMovie = movie;

            var numberOfPlaylists =
                (from user in db.Users
                 where user.UserID == UserID
                 select user.Number_Of_Playlists).FirstOrDefault();

            for (int i = 0; i < numberOfPlaylists; i++)
            {
                createPlaylistCheckbox(i, movie);
            }

            foreach (MonoFlat_CheckBox checkBox in Add_Movie_To_Playlist_Panel.Controls)
            {
                foreach (Playlist playlist in db.Playlists)
                    if (playlist.FilmID == movie.MovieID && playlist.UserID == UserID && playlist.PlaylistID == (int)checkBox.Tag)
                        checkBox.Checked = true;
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Accept_Button_Click(object sender, EventArgs e)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var userID = MainApplicationWindow.getCurrentUserID();
            var usr = db.Users.SingleOrDefault(o => o.UserID == userID);


            foreach(MonoFlat_CheckBox checkbox in Add_Movie_To_Playlist_Panel.Controls)
            {
                if(checkbox.Checked)
                {
                    var playlist = db.Playlists.SingleOrDefault(o => o.UserID == userID && o.FilmID == currentMovie.MovieID && o.PlaylistID == (int)checkbox.Tag);
                    
                    if(playlist == null)
                        Methods.AddToPlaylist((int)checkbox.Tag, usr.Username, currentMovie.File_Name);

                }
                else
                {
                    Methods.RemoveFromPlaylist(currentMovie, (int)checkbox.Tag);
                }


            }
            this.Close();
        }

    }
}
