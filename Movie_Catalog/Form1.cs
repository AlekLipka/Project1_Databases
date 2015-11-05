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
        public static MonoFlat.MonoFlat_NotificationBox loginError = new MonoFlat.MonoFlat_NotificationBox();
        public static System.Timers.Timer promptDispose = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            RefreshGrid();
        }

        #region  WindowResize
        protected override void WndProc(ref Message m)
        {   //Function that keeps the ratio of the form while it is being resized (13:9)
            if (m.Msg == 0x216 || m.Msg == 0x214)
            {
                // Keep the window ratio
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                int w = rc.Right - rc.Left;
                int h = rc.Bottom - rc.Top;
                int z = w > h ? w : h;
                rc.Bottom = rc.Top + z - 429;
                rc.Right = rc.Left + z;
                Marshal.StructureToPtr(rc, m.LParam, false);
                m.Result = (IntPtr)1;
                int wwx = dataGridView1.Height;
                int wwy = dataGridView1.Width;
                if (this.Width >= 1200)
                {
                    dataGridView1.Width = w - dataGridView1.Margin.Left - dataGridView1.Margin.Right - 13;
                    dataGridView1.Height = z - 429 - dataGridView1.Location.Y - 10;
                }
                return;
            }
            base.WndProc(ref m);
        }
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Method for all the exit buttons
            Methods.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Method for the About section in the menu
            var monoFlat_NotificationBox1 = new MonoFlat.MonoFlat_NotificationBox();
            monoFlat_NotificationBox1.BorderCurve = 8;
            monoFlat_NotificationBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            monoFlat_NotificationBox1.Image = null;
            monoFlat_NotificationBox1.Location = new System.Drawing.Point(this.Width / 2-200, this.Height / 2-125);
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

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {  //Single movie loading function
            Cursor.Current = Cursors.WaitCursor;
            Methods.LoadFile();
            RefreshGrid();
            Cursor.Current = Cursors.Default;
        }

        private void RefreshGrid()
        {
            List<MainMovieList> movieList = new List<MainMovieList>();

            movieList = Methods.AddItemToListView();

            dataGridView1.DataSource = movieList;
            DataGridViewColumn column = dataGridView1.Columns[0];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            column.Width = 60;
        }


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
        #endregion

        #region Login
        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            string login = monoFlat_TextBox1.Text;
            bool validation = Methods.LoginFunction(monoFlat_TextBox1.Text, monoFlat_TextBox2.Text);
            if (validation)
            {
                monoFlat_TextBox1.Visible = false;
                monoFlat_TextBox1.Text = null;
                monoFlat_TextBox2.Visible = false;
                monoFlat_TextBox2.Text = null;
                monoFlat_Label1.Visible = false;
                monoFlat_Label2.Visible = false;
                monoFlat_Button1.Visible = false;
                monoFlat_Panel1.Visible = false;
                monoFlat_LinkLabel2.Visible = true;

                welcome.Text = ("Welcome " + login);
                welcome.Location = new System.Drawing.Point(this.Width - welcome.Width- monoFlat_LinkLabel2.Width - welcome.Margin.Left
                                                            - welcome.Margin.Right - monoFlat_LinkLabel2.Margin.Left 
                                                            - monoFlat_LinkLabel2.Margin.Right, 113);
                welcome.Visible = true;

                monoFlat_TextBox2.Text = "*****";
                monoFlat_TextBox2.Enter -= TextBoxEnter;

                monoFlat_LinkLabel2.Location = new Point(welcome.Location.X + welcome.Width , welcome.Location.Y);
            }
            else
            {
                loginError.BorderCurve = 8;
                loginError.Font = new System.Drawing.Font("Tahoma", 9F);
                loginError.Image = null;
                loginError.Location = new System.Drawing.Point(this.Width / 2 + 420, this.Height / 2 - 350);
                loginError.MinimumSize = new System.Drawing.Size(100, 40);
                loginError.Name = "monoFlat_NotificationBox1";
                loginError.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
                loginError.RoundCorners = true;
                loginError.ShowCloseButton = true;
                loginError.Size = new System.Drawing.Size(200, 85);
                loginError.TabIndex = 9;
                loginError.Text = "Log In Error:\nYour password or user is incorrenct.";
                monoFlat_ThemeContainer1.Controls.Add(loginError);
                loginError.BringToFront();
                //promptDispose.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
                //promptDispose.Interval = 1000;
                //promptDispose.Enabled = true;
            }
        }
        public static int time = 0;
        private static void OnTimerEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            time++;
            if (time == 5)
            {
                time = 0;
                promptDispose.Enabled = false;
                loginError.Dispose();
            }
        }
        #endregion

        private void monoFlat_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPrompt login = new LoginPrompt();
            login.Show();
        }

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

        }

        void TextBoxEnter(object sender, System.EventArgs e)
        {
            MonoFlat.MonoFlat_TextBox TextBox = sender as MonoFlat.MonoFlat_TextBox;
            TextBox.Text = null;
            TextBox.Enter -= TextBoxEnter;
        }
    }
}
