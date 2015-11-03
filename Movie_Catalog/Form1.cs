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
        protected override void WndProc(ref Message m)
        {   //Function that keeps the ratio of the form while it is being resized (13:9)
            if (m.Msg == 0x216 || m.Msg == 0x214)
            {
                // Keep the window ratio
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                int w = rc.Right - rc.Left;
                int h = rc.Bottom - rc.Top;
                int z = w > h ? w : h;
                rc.Bottom = rc.Top + z - 400;
                rc.Right = rc.Left + z;
                Marshal.StructureToPtr(rc, m.LParam, false);
                m.Result = (IntPtr)1;
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
            monoFlat_NotificationBox1.Text = "\n\n\n\t\tMovie Catalog 1.0     \n\n\t\tCreated by:\n \t\tAleksander Lipka\n \t\tPiotr Lutyk";
            monoFlat_ThemeContainer1.Controls.Add(monoFlat_NotificationBox1);
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Single movie loading function
            Methods.LoadFile();
        }
        #endregion

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


                var welcome = new MonoFlat.MonoFlat_Label();
                welcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                welcome.AutoSize = true;
                welcome.BackColor = System.Drawing.Color.Transparent;
                welcome.Font = new System.Drawing.Font("Segoe UI", 9F);
                welcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
                welcome.Location = new System.Drawing.Point(this.Width - welcome.Width*2, 113);
                welcome.Name = "monoFlat_Label1";
                welcome.TabIndex = 5;
                welcome.Text = ("Welcome " + login);
                monoFlat_ThemeContainer1.Controls.Add(welcome);
            }
        }
    }
}
