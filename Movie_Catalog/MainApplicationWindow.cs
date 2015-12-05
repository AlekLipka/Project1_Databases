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
using System.Diagnostics;
using System.IO;
using System.Data.Entity.Validation;
using MonoFlat;

namespace Movie_Catalog
{
    public partial class MainApplicationWindow : Form
    {

        /// <summary>
        /// Constructor of the main Form of our apllication
        /// </summary>
        public MainApplicationWindow()
        {
            InitializeComponent();
            this.CenterToScreen();
            Methods.ProgramStart();
        }

        #region  WindowResize
        /// <summary>
        /// Keeps the ratio of the Form while it is resizing
        /// </summary>
        /// <param name="m"> Message from Handler that informs us if the window is being resized</param>
        protected override void WndProc(ref Message m)
        {   //Function that keeps the ratio of the form while it is being resized (13:9)
            if (m.Msg == 0x216 || m.Msg == 0x214)
            {
                int rectangledifference = (this.Width - this.Height);
                // Keep the window ratio
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                int w = rc.Right - rc.Left;
                int h = rc.Bottom - rc.Top;
                int z = w > h ? w : h;
                rc.Bottom = rc.Top + z - rectangledifference;
                rc.Right = rc.Left + z;
                Marshal.StructureToPtr(rc, m.LParam, false);
                m.Result = (IntPtr)1;
                int wwx = dataGridView1.Height;
                int wwy = dataGridView1.Width;
                dataGridView1.Width = w - dataGridView1.Margin.Left - dataGridView1.Margin.Right - 13;
                dataGridView1.Height = z - rectangledifference - dataGridView1.Location.Y - 10;
                Playlists_Panel.Size = new System.Drawing.Size(monoFlat_ThemeContainer1.Size.Width - 249, 39);
                Add_Playlist_Button.Location = new System.Drawing.Point(this.Width - Add_Playlist_Button.Width - Add_Playlist_Button.Margin.Left
                                                            - Add_Playlist_Button.Margin.Right, 124);
                //new Point(welcome.Location.X, 124);
                return;
            }
            base.WndProc(ref m);
        }
        /// <summary>
        /// Structure of RECT 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        #endregion

        #region Menu
        /// <summary>
        /// Event Handler for our Exit Menu Button.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Method for all the exit buttons
            Methods.Exit();
        }

        /// <summary>
        /// Event Handler for About Menu Button. Shows us a notification box with the programs informations.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Method for the About section in the menu
            var monoFlat_NotificationBox1 = new MonoFlat.MonoFlat_NotificationBox();
            monoFlat_NotificationBox1.BorderCurve = 8;
            monoFlat_NotificationBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            monoFlat_NotificationBox1.Image = null;
            monoFlat_NotificationBox1.Location = new System.Drawing.Point(this.Width / 2 - 200, this.Height / 2 - 125);
            monoFlat_NotificationBox1.MinimumSize = new System.Drawing.Size(100, 40);
            monoFlat_NotificationBox1.Name = "monoFlat_NotificationBox1";
            monoFlat_NotificationBox1.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Notice;
            monoFlat_NotificationBox1.RoundCorners = true;
            monoFlat_NotificationBox1.ShowCloseButton = true;
            monoFlat_NotificationBox1.Size = new System.Drawing.Size(400, 250);
            monoFlat_NotificationBox1.TabIndex = 2;
            monoFlat_NotificationBox1.Text = "\n\n\n\t\tMovie Catalog 1.0     \n\n\t\tCreated by:\n \t\tAleksander Lipka\n \t\tPiotr Lustyk";
            monoFlat_ThemeContainer1.Controls.Add(monoFlat_NotificationBox1);
            monoFlat_NotificationBox1.BringToFront();
        }

        /// <summary>
        /// Loads a single movie selected by user.
        /// </summary>
        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {  //Single movie loading function
            Cursor.Current = Cursors.WaitCursor;
            Methods.LoadFile();
            RefreshGrid();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Loads movies from a given directory selected by user.
        /// </summary>
        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {  //Direcory movie loading function
            Cursor.Current = Cursors.WaitCursor;
            string directory;
            directory = Methods.LoadFromDirecotory();
            if (directory != null)
            {
                List<String> NewMoviesFromDirecotry = new List<String>();
                NewMoviesFromDirecotry = Methods.GetAllFilesToList(directory);
                string path;
                foreach (var element in NewMoviesFromDirecotry)
                {
                    path = System.IO.Path.GetFullPath(element);
                    Methods.AddMovie(path);
                }
                RefreshGrid();
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Function that shows splash screen with database configuration string
        /// </summary>
        private void configureDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDatabaseSplashScreen splash = new AddDatabaseSplashScreen();
            splash.ShowDialog();
        }
        #endregion

        #region Login
        /// <summary>
        /// Array of all possible notification boxes
        /// </summary>
        MonoFlat.MonoFlat_NotificationBox[] loginError = new MonoFlat.MonoFlat_NotificationBox[1000000];
        int loginErrorcounter = 0;

        bool ContextMenuAvailable = false;
        static string UserName = null;

        /// <summary>
        /// Log In function, checks if the users input is in the database and if it is, it log's in user's personal datagridview
        /// </summary>
        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string login = monoFlat_TextBox1.Text;
            bool validation = Methods.LoginFunction(monoFlat_TextBox1.Text, monoFlat_TextBox2.Text);
            if (validation)
            {
                UserName = login;
                monoFlat_TextBox1.Visible = false;
                monoFlat_TextBox1.Text = null;
                monoFlat_TextBox2.Visible = false;
                monoFlat_TextBox2.Text = null;
                monoFlat_Label1.Visible = false;
                monoFlat_Label2.Visible = false;
                monoFlat_Button1.Visible = false;
                monoFlat_Panel1.Visible = false;
                monoFlat_LinkLabel2.Visible = true;
                ContextMenuAvailable = true;
                Add_Playlist_Button.Visible = true;
                AddAllPlaylistButtons();
                Playlist_Button.Visible = true;
                HomeList_Button.Visible = true;

                welcome.Text = ("Welcome " + login);
                welcome.Location = new System.Drawing.Point(this.Width - welcome.Width - monoFlat_LinkLabel2.Width - welcome.Margin.Left
                                                            - welcome.Margin.Right - monoFlat_LinkLabel2.Margin.Left
                                                            - monoFlat_LinkLabel2.Margin.Right, 101);
                welcome.Visible = true;

                monoFlat_TextBox2.Text = "Password";
                monoFlat_TextBox2.Enter -= TextBoxEnter;

                monoFlat_LinkLabel2.Location = new Point(welcome.Location.X + welcome.Width, welcome.Location.Y);

                LoginPromptDispose();
                RefreshGrid();
                folderToolStripMenuItem.Enabled = true;
                fileToolStripMenuItem1.Enabled = true;
                monoFlat_TextBox1.Text = null;
                monoFlat_TextBox2.Text = null;
            }
            else
            {
                loginError[loginErrorcounter] = new MonoFlat.MonoFlat_NotificationBox();
                loginError[loginErrorcounter].BorderCurve = 8;
                loginError[loginErrorcounter].Font = new System.Drawing.Font("Tahoma", 9F);
                loginError[loginErrorcounter].Image = null;
                loginError[loginErrorcounter].Location = new System.Drawing.Point(monoFlat_Button1.Location.X - 200, monoFlat_Button1.Location.Y + 50);
                loginError[loginErrorcounter].MinimumSize = new System.Drawing.Size(100, 40);
                loginError[loginErrorcounter].Name = "monoFlat_NotificationBox1";
                loginError[loginErrorcounter].NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
                loginError[loginErrorcounter].RoundCorners = true;
                loginError[loginErrorcounter].ShowCloseButton = false;
                loginError[loginErrorcounter].Size = new System.Drawing.Size(200, 85);
                loginError[loginErrorcounter].TabIndex = 9;
                loginError[loginErrorcounter].Text = "Log In Error:\nYour password or user is incorrenct.";
                loginError[loginErrorcounter].MouseHover += new EventHandler(LoginError_MouseHover);
                monoFlat_ThemeContainer1.Controls.Add(loginError[loginErrorcounter]);
                loginError[loginErrorcounter].BringToFront();
                loginErrorcounter++;
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Disposing of all existing error prompts
        /// </summary>
        private void LoginPromptDispose()
        {
            for (int j = 0; j <= loginErrorcounter; j++)
            {
                if (loginError[j] != null)
                {
                    loginError[j].Dispose();
                }
            }
        }
        /// <summary>
        /// Dispose of a prompt if it is hoovered.
        /// </summary>
        private void LoginError_MouseHover(object sender, EventArgs e)
        {
            MonoFlat.MonoFlat_NotificationBox prompt = sender as MonoFlat.MonoFlat_NotificationBox;
            prompt.Dispose();
        }

        /// <summary>
        /// Retruns current user's ID
        /// </summary>
        /// <returns>Current User ID</returns>
        public static int getCurrentUserID()
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();

            var usr = db.Users.SingleOrDefault(o => o.Username == UserName);

            return usr.UserID;
        }
        /// <summary>
        /// Enter click after entering the password and login
        /// </summary>
        /// <param name="msg">Message msg entered by default</param>
        /// <param name="keyData">The Key that was clicked</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && monoFlat_TextBox2.Text != null && monoFlat_TextBox2.Text != "Password" && monoFlat_TextBox2.Text != "")
            {
                var sender = monoFlat_TextBox2;
                var e = new System.EventArgs();
                monoFlat_Button1_Click(sender, e);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Logout
        /// <summary>
        /// Opens Sign In window
        /// </summary>
        private void monoFlat_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPrompt login = new LoginPrompt();
            LoginPromptDispose();
            login.ShowDialog();
            monoFlat_TextBox1.Text = null;
            monoFlat_TextBox2.Text = "******";
        }

        /// <summary>
        /// Log Out of the user
        /// </summary>
        private void monoFlat_LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            monoFlat_TextBox1.Visible = true;
            monoFlat_TextBox2.Visible = true;
            monoFlat_Label1.Visible = true;
            monoFlat_Label2.Visible = true;
            monoFlat_Button1.Visible = true;
            monoFlat_Panel1.Visible = true;
            monoFlat_LinkLabel2.Visible = false;
            Add_Playlist_Button.Visible = false;
            Playlist_Button.Visible = false;
            HomeList_Button.Visible = false;
            removeAllPlaylistButtons();

            welcome.Text = null;
            welcome.Visible = false;
            UserName = null;
            folderToolStripMenuItem.Enabled = false;
            fileToolStripMenuItem1.Enabled = false;
            dataGridView1.DataSource = null;
            monoFlat_TextBox1.Text = null;
        }

        /// <summary>
        /// Cleans the textbox inside when it is clicked for the first time
        /// </summary>
        void TextBoxEnter(object sender, System.EventArgs e)
        {
            MonoFlat.MonoFlat_TextBox TextBox = sender as MonoFlat.MonoFlat_TextBox;
            TextBox.Text = null;
            TextBox.Enter -= TextBoxEnter;
        }

        #endregion

        #region Playlist and Home List
        bool playlistButtonPressed = false;
        bool homelistButtonPressed = true;
        int actualButtonPressed = 0;
        private void Playlist_Button_Click(object sender, EventArgs e)
        {
            MonoFlat_Button button = sender as MonoFlat_Button;
            int i = (int)button.Tag;
            actualButtonPressed = i;
            RefreshPlaylistGrid(i);
            playlistButtonPressed = true;
            homelistButtonPressed = false;
        }

        private void HomeList_Button_Click(object sender, EventArgs e)
        {
            RefreshGrid();
            playlistButtonPressed = false;
            homelistButtonPressed = true;
        }
        #endregion

        #region DataGridView

        /// <summary>
        /// Editing of a Movie Name in the dataGridView, it saves the input in database
        /// </summary>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() =>
                {
                    string filename = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "Movie_Name" && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                    {
                        string moviename = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                        Console.Write("Movie name was changed for: " + filename + "with the following: " + moviename);
                        Methods.MovieNameChange(moviename, filename);
                    }
                    else
                    {
                        Methods.MovieNameChange(null, filename);
                    }
                }));
        }

        /// <summary>
        /// Refreshes the dataGridView from database that are in Home list
        /// </summary>
        private void RefreshGrid()
        {
            List<Movies> movieList = new List<Movies>();

            movieList = Methods.AddItemToList();

            dataGridView1.DataSource = movieList;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (count % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    //row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }

                count++;
            }
        }

        /// <summary>
        /// Refreshes dataGridView with films that are added to Playlist
        /// </summary>
        private void RefreshPlaylistGrid(int tag)
        {
            List<Movies> movieList = new List<Movies>();

            movieList = Methods.AddItemToPlaylist(tag);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = movieList;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (count % 2 == 0)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    //row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }

                count++;
            }
        }

        #endregion

        #region Favourite
        Point pt = new Point();
        /// <summary>
        /// Opens Context Menu Strip while clicked in the dataGridView in column third and handles the clicks in it
        /// </summary>
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (e.Button == MouseButtons.Right && currentMouseOverRow >= 0)
            {
                int currentMouseOverColumn = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;
                var film = ((List<Movies>)dataGridView1.DataSource).ElementAt(currentMouseOverRow);
                var userID = getCurrentUserID();
                if (currentMouseOverRow >= 0 && currentMouseOverColumn >= 0)
                    dataGridView1.CurrentCell = dataGridView1[currentMouseOverColumn, currentMouseOverRow];
                if (ContextMenuAvailable)
                {
                    MovieDatabaseEntities db = new MovieDatabaseEntities();
                    ContextMenuStrip m = new ContextMenuStrip();
                    if (film.LikeOrDislike != "Favourite")
                        m.Items.Add("Add to Favourite").Name = "Add to Favourite";
                    if (film.LikeOrDislike != "Hated")
                        m.Items.Add("Add to Hated").Name = "Add to Hated";
                    if (film.LikeOrDislike == "Favourite" || film.LikeOrDislike == "Hated")
                        m.Items.Add("Reset to Normal Status").Name = "Reset to Normal Status";
                    if (db.Playlists.Any(p => p.FilmID == film.MovieID && p.UserID == userID))
                    {
                        m.Items.Add("Remove from playlist").Name = "Remove from playlist";
                    }
                    else
                    {
                        m.Items.Add("Add to playlist").Name = "Add to playlist";
                    }


                    Point pt1 = new Point(currentMouseOverColumn, currentMouseOverRow);
                    pt = pt1;
                    if (currentMouseOverRow >= 0 && currentMouseOverColumn == 2)
                    {
                        //m.Items.Add(string.Format("Coordinates: {0}, {1}", currentMouseOverRow.ToString(), currentMouseOverColumn.ToString()));
                        m.Show(dataGridView1, new Point(e.X, e.Y));
                    }
                    m.ItemClicked += new ToolStripItemClickedEventHandler(m_Item_Clicked);
                }


            }
        }
        /// <summary>
        /// Event Handler for MenuStripItems in the dataGridView1_MouseClick() function
        /// </summary>
        public void m_Item_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var film = ((List<Movies>)dataGridView1.DataSource).ElementAt(pt.Y);
            Console.Write("\n\nThe film is: " + film.File_Name);
            switch (e.ClickedItem.Name.ToString())
            {
                case "Add to Favourite":
                    Methods.AddFavouriteOrHated(1, UserName, film.File_Name);
                    break;
                case "Add to Hated":
                    Methods.AddFavouriteOrHated(0, UserName, film.File_Name);
                    break;
                case "Reset to Normal Status":
                    Methods.AddFavouriteOrHated(-1, UserName, film.File_Name);
                    break;
                case "Add to playlist":
                    Methods.AddToPlaylist(1, UserName, film.File_Name);
                    break;
                case "Remove from playlist":
                    Methods.RemoveFromPlaylist(film);
                    break;

            }
            if (playlistButtonPressed)
            {
                RefreshPlaylistGrid(actualButtonPressed);
            }
            else if (homelistButtonPressed)
                RefreshGrid();
        }
        #endregion

        #region Playing the movies

        /// <summary>
        /// Checks if the file exists in the directory from database and play a movie if it exists 
        /// or calls changeDirectory if it does not.
        /// </summary>
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;

                if (currentMouseOverRow >= 0 && currentMouseOverColumn == 4)
                {
                    dataGridView1.CurrentCell = dataGridView1[currentMouseOverColumn, currentMouseOverRow];

                    var film = ((List<Movies>)dataGridView1.DataSource).ElementAt(currentMouseOverRow);
                    var path = film.Path;
                    var file_name = film.File_Name;
                    if (File.Exists(path))
                    {
                        try
                        {
                            Process.Start(path);
                        }
                        catch { }
                    }
                    else
                    {
                        ChangeDirectory(file_name, path);
                        RefreshGrid();
                    }
                }
            }
        }

        /// <summary>
        /// Add new path to the file whose directory was changed, to database 
        /// </summary>
        /// <param name="newPath">a path that is inserted instead of previous one</param>
        /// <param name="file_name">a name of file that will be updated</param>
        public void AddNewPathToDatabase(string newPath, string file_name)
        {
            try
            {
                MovieDatabaseEntities db = new MovieDatabaseEntities();
                var result = db.MainMovieLists.SingleOrDefault(o => o.File_Name == file_name);

                result.File_Path = newPath;
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

        /// <summary>
        /// Removes the movie from database if its directory was changed and user does not want to give a new one
        /// </summary>
        /// <param name="file_name">The name of file to be deleted</param>
        public void DeleteOldRowFromDatabase(string file_name)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var FilmID =
            (from mov in db.MainMovieLists
             where mov.File_Name == file_name
             select mov.ID).FirstOrDefault();

            var DeletedFromFavourite_Hated =
                from fav in db.Favourite_Hated
                where fav.FilmID == FilmID
                select fav;

            var DeletedFromPlaylist =
                from pl in db.Playlists
                where pl.FilmID == FilmID
                select pl;

            var DeletedFromMainMovieLists =
                from mov in db.MainMovieLists
                where mov.ID == FilmID
                select mov;

            foreach (var pair in DeletedFromFavourite_Hated)
            {
                db.Favourite_Hated.Remove(pair);
            }

            foreach (var playlist in DeletedFromPlaylist)
            {
                db.Playlists.Remove(playlist);
            }

            foreach (var mov in DeletedFromMainMovieLists)
            {
                db.MainMovieLists.Remove(mov);
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        }

        /// <summary>
        /// Function that uses DeleteOldRowFromDatabase and AddNewPathToDatabase functions to update the path of the file 
        /// or to remove movie from database
        /// </summary>
        /// <param name="file_name">A name of movie file that will be updated/removed</param>
        /// <param name="path">An old path to the file. It is needed to MessageBox information</param>
        public void ChangeDirectory(string file_name, string path)
        {
            var i = 0;

            while (i == 0)
            {

                FilePathChangeMessageBox MyMessageBox = new FilePathChangeMessageBox();
                MyMessageBox.MessageBox_File_Name.Text = "'" + file_name + "'";
                MyMessageBox.MessageBox_File_Path.Text = "'" + path + "'";



                if (MyMessageBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    Stream myStream = null;
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Movie file (*.mkv, *.mov, *.avi, *.mp4, *.divx, *.mpeg, *.mpg)|*.mkv;*mov;*.avi;*.mp4;*.divx;*.mpeg;*.mpg";

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
                                using (myStream)
                                {
                                    //string Name;
                                    FileStream fs = myStream as FileStream;

                                    if (fs != null)
                                    {
                                        Properties.Settings.Default.FolderFilePath = fs.Name;
                                        Properties.Settings.Default.Save();
                                        Name = System.IO.Path.GetFileNameWithoutExtension(fs.Name);
                                        if (Name == file_name)
                                        {
                                            i = 1;
                                            AddNewPathToDatabase(fs.Name, Name);
                                        }
                                        else
                                        {
                                            MessageBox.Show("You chose wrong file! \n \n Try again!");
                                            i = 0;
                                        }
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
                else
                {
                    i = 1;
                    DeleteOldRowFromDatabase(file_name);
                }
            }
        }

        #endregion

        /// <summary>
        /// calls AddPlaylistToDataBase() which add playlist to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Playlist_Button_Click(object sender, EventArgs e)
        {
            AddPlaylistToDataBase();
        }

        /// <summary>
        /// Add Playlist button in Playlist_Panel
        /// </summary>
        /// <param name="i">number of user's playlists</param>
        public void createPlaylistButton(int i)
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var userID = getCurrentUserID();

            var pl =
            (from playlist in db.List_Of_Playlists
             where playlist.UserID == userID && playlist.ID == i + 1
             select playlist).FirstOrDefault();//.Playlist_Name).FirstOrDefault();
            if (pl != null)
            {
                if (Playlists_Panel.Controls.Count == 0)
                {
                    MonoFlat_Button button = new MonoFlat_Button();
                    button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                    button.Width = 89;
                    button.Height = 19;
                    button.Text = pl.Playlist_Name;
                    button.Location = new Point(0, 0);
                    button.Click += new EventHandler(Playlist_Button_Click);
                    int tag = i + 1;
                    button.Tag = tag;
                    Playlists_Panel.Controls.Add(button);
                }
                else
                {
                    int maxi = 0;
                    foreach (MonoFlat_Button but in Playlists_Panel.Controls)
                    {
                        if (Int32.Parse(but.Tag.ToString()) > maxi)
                        {
                            maxi = Int32.Parse(but.Tag.ToString());
                        }
                    }

                    foreach (MonoFlat_Button item in Playlists_Panel.Controls)
                    {
                        if (item.Tag.Equals(maxi))
                        {
                            MonoFlat_Button prevButton = item;

                            MonoFlat_Button button = new MonoFlat_Button();
                            button.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
                            button.Width = 89;
                            button.Height = 19;
                            button.Text = pl.Playlist_Name;
                            button.Location = new Point(prevButton.Bounds.Right + 6, 0);
                            button.Click += new EventHandler(Playlist_Button_Click);
                            int tag = i + 1;
                            button.Tag = tag;
                            Playlists_Panel.Controls.Add(button);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds all playlist buttons to Playlists_Panel after log in
        /// </summary>
        public void AddAllPlaylistButtons()
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var UserID = getCurrentUserID();

            var numberOfPlaylists =
                (from user in db.Users
                 where user.UserID == UserID
                 select user.Number_Of_Playlists).FirstOrDefault();

            for (int i = 0; i < numberOfPlaylists; i++)
            {
                createPlaylistButton(i);
            }
        }

        public bool PlaylistButtonActive = true;
        /// <summary>
        /// Add playlist to List_Of_Playlists in database
        /// </summary>
        public void AddPlaylistToDataBase()
        {
            if (PlaylistButtonActive)
            {
                PlaylistButtonActive = false;
                MovieDatabaseEntities db = new MovieDatabaseEntities();
                var UserID = getCurrentUserID();

                var i =
                (from user in db.Users
                 where user.UserID == UserID
                 select user.Number_Of_Playlists).FirstOrDefault();

                var usr = db.Users.SingleOrDefault(o => o.UserID == UserID);
                usr.Number_Of_Playlists++; // Increase Number_Of_Playlists for the Current user

                List_Of_Playlists playlist = new List_Of_Playlists();

                playlist.ID = i + 1;
                playlist.UserID = UserID;
                playlist.Playlist_Name = "Playlist" + playlist.ID;

                db.List_Of_Playlists.Add(playlist);
                db.SaveChanges();

                createPlaylistButton(i);
                PlaylistButtonActive = true;
            }
        }

        /// <summary>
        /// Removes all playlist buttons from Playlist_Panel
        /// </summary>
        public void removeAllPlaylistButtons()
        {
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            var UserID = getCurrentUserID();

            var numberOfPlaylists =
                (from user in db.Users
                 where user.UserID == UserID
                 select user.Number_Of_Playlists).FirstOrDefault();

            for(int i=0; i<numberOfPlaylists; i++)
            {
                deletePlaylistButton(i + 1);
            }
        }

        /// <summary>
        /// Remove playlist button from Playlist_Panel
        /// </summary>
        /// <param name="tag">tag of button that will be removed</param>
        public void deletePlaylistButton(int tag)
        {
            foreach (MonoFlat_Button button in Playlists_Panel.Controls)
            {
                if(button.Tag.Equals(tag))
                {
                    Playlists_Panel.Controls.Remove(button);
                }
            }
        }

        /// <summary>
        /// Playlist Button click event
        /// </summary>
        private void ButtonClickOneEvent(object sender, EventArgs e)
        {
            ///////Use Playlist_Button_Click() its defined on the top


            MonoFlat_Button button = sender as MonoFlat_Button;
            int i = (int)button.Tag;

            MessageBox.Show("You clicked Playlist" + i + " button.");
        }
    }
}
