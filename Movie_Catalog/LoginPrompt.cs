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
    public partial class LoginPrompt : Form
    {
        public LoginPrompt()
        {
            InitializeComponent();
            this.CenterToParent();
        }
        //public static List<MonoFlat.MonoFlat_NotificationBox> Prompts = new List<MonoFlat.MonoFlat_NotificationBox>();
        MonoFlat.MonoFlat_NotificationBox[] loginError = new MonoFlat.MonoFlat_NotificationBox[1000000];
        int i = 0;
        bool validation = false;
        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            User user = new User();
            MovieDatabaseEntities db = new MovieDatabaseEntities();
            validation = true;
            loginError[i] = new MonoFlat.MonoFlat_NotificationBox();
            loginError[i].BorderCurve = 8;
            loginError[i].Font = new System.Drawing.Font("Tahoma", 9F);
            loginError[i].Image = null;
            loginError[i].Location = new System.Drawing.Point(this.Width / 2 - 100, this.Height - 180);
            loginError[i].MinimumSize = new System.Drawing.Size(100, 40);
            loginError[i].Name = "monoFlat_NotificationBox1";
            loginError[i].NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            loginError[i].RoundCorners = true;
            loginError[i].ShowCloseButton = false;
            loginError[i].Size = new System.Drawing.Size(200, 85);
            loginError[i].TabIndex = 6;
            loginError[i].MouseHover += new EventHandler(LoginError_MouseHover);
            if (monoFlat_TextBox2.Text == monoFlat_TextBox3.Text)
            {
                foreach (var username in db.Users)
                {
                    if (username.Username==monoFlat_TextBox1.Text)
                    {
                        loginError[i].Text = "Username Error:\nThis user name is already occupied.";
                        monoFlat_ThemeContainer1.Controls.Add(loginError[i]);
                        loginError[i].BringToFront();
                        validation = false;
                        monoFlat_TextBox1.Text = null;
                        break;
                    }
                    if (monoFlat_TextBox1.Text.Length < 3)
                    {
                        loginError[i].Text = "Username Error:\nUsername must contatin at least 3 characters.";
                        monoFlat_ThemeContainer1.Controls.Add(loginError[i]);
                        loginError[i].BringToFront();
                        validation = false;
                        monoFlat_TextBox1.Text = null;
                        break;
                    }
                    if (monoFlat_TextBox2.Text.Length < 5)
                    {
                        loginError[i].Text = "Password Error:\nPassword must be of at least 5 characters.";
                        monoFlat_ThemeContainer1.Controls.Add(loginError[i]);
                        loginError[i].BringToFront();
                        validation = false;
                        break;
                    }
                }
            }
            else
            {
                loginError[i].Text = "Password Error:\nPasswords don't match!";
                monoFlat_ThemeContainer1.Controls.Add(loginError[i]);
                loginError[i].BringToFront();
                validation = false;
            }
            if (validation)
            {
                user.Username = monoFlat_TextBox1.Text;
                user.Password = monoFlat_TextBox2.Text;
                db.Users.Add(user);
                db.SaveChanges();
                validation = false;

                var successPrompt = new MonoFlat.MonoFlat_NotificationBox();
                successPrompt.BorderCurve = 8;
                successPrompt.Font = new System.Drawing.Font("Tahoma", 9F);
                successPrompt.Image = null;
                successPrompt.Location = new System.Drawing.Point(this.Width / 2 - 150, this.Height/2 -50);
                successPrompt.Name = "monoFlat_NotificationBox1";
                successPrompt.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
                successPrompt.RoundCorners = true;
                successPrompt.ShowCloseButton = false;
                successPrompt.Size = new System.Drawing.Size(300, 105);
                successPrompt.Text = ("You have succesfully created your account " + monoFlat_TextBox1.Text + 
                                        ".\nGo now and log in.\nThis window will shutdown in a moment");
                monoFlat_ThemeContainer1.Controls.Add(successPrompt);
                successPrompt.BringToFront();
                foreach (Control c in this.Controls)
                    c.Enabled = false;

                System.Threading.Thread.Sleep(5000);

                this.Dispose();
            }
            i++;
            Cursor.Current = Cursors.Default;
        }
        private void LoginError_MouseHover(object sender, EventArgs e)
        {
            MonoFlat.MonoFlat_NotificationBox prompt = sender as MonoFlat.MonoFlat_NotificationBox;
            prompt.Dispose();
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void TextBoxEnter(object sender, System.EventArgs e)
        {
            MonoFlat.MonoFlat_TextBox TextBox = sender as MonoFlat.MonoFlat_TextBox;
            TextBox.Text = null;
            TextBox.Enter -= TextBoxEnter;
        }
    }
}
