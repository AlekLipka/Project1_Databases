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

namespace Movie_Catalog
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
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
                string name;
                foreach (var element in NewMoviesFromDirecotry)
                {
                    name = System.IO.Path.GetFileNameWithoutExtension(element);
                    Methods.AddMovie(name);
                }
                RefreshGrid();
            }
            Cursor.Current = Cursors.Default;
        }
        
        /// <summary>
        /// Function that does completely nothing useful
        /// </summary>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TROLL BUTTON");
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

                welcome.Text = ("Welcome " + login);
                welcome.Location = new System.Drawing.Point(this.Width - welcome.Width - monoFlat_LinkLabel2.Width - welcome.Margin.Left
                                                            - welcome.Margin.Right - monoFlat_LinkLabel2.Margin.Left
                                                            - monoFlat_LinkLabel2.Margin.Right, 113);
                welcome.Visible = true;

                monoFlat_TextBox2.Text = "*****";
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

        #endregion

        #region Logout
        /// <summary>
        /// Opens Sign In window
        /// </summary>
        private void monoFlat_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPrompt login = new LoginPrompt();
            LoginPromptDispose();
            login.Show();
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
        /// Refreshes the dataGridView from database
        /// </summary>
        private void RefreshGrid()
        {
            List<Movies> movieList = new List<Movies>();

            movieList = Methods.AddItemToList();

            dataGridView1.DataSource = movieList;

            //dataGridView1.Columns[0].Name = "ID";
            //dataGridView1.Columns[1].Name = "Movie Name";
            //dataGridView1.Columns[2].Name = "File Name";
            //dataGridView1.Columns[3].Name = "Good(1) or Not(0)";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[2].ReadOnly = true;
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

        #region favourite
        Point pt = new Point();
        /// <summary>
        /// Opens Context Menu Strip while clicked in the dataGridView in column third and handles the clicks in it
        /// </summary>
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0 && currentMouseOverColumn >= 0)
                    dataGridView1.CurrentCell = dataGridView1[currentMouseOverColumn, currentMouseOverRow];
                if (ContextMenuAvailable)
                {
                    ContextMenuStrip m = new ContextMenuStrip();
                    m.Items.Add("Add to Favourite").Name = "Add to Favourite";
                    m.Items.Add("Add to Hated").Name = "Add to Hated";
                    m.Items.Add("Reset to Normal Status").Name = "Reset to Normal Status";


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
            }
            RefreshGrid();
        }
        #endregion

    }
}
