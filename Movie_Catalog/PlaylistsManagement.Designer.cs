namespace Movie_Catalog
{
    partial class PlaylistsManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monoFlat_ThemeContainer1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.Add_Movie_To_Playlist_Panel = new System.Windows.Forms.Panel();
            this.Accept_Button = new MonoFlat.MonoFlat_Button();
            this.Cancel_Button = new MonoFlat.MonoFlat_Button();
            this.monoFlat_Label1 = new MonoFlat.MonoFlat_Label();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.Add_Movie_To_Playlist_Panel);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Accept_Button);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Cancel_Button);
            this.monoFlat_ThemeContainer1.Controls.Add(this.monoFlat_Label1);
            this.monoFlat_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlat_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.monoFlat_ThemeContainer1.Name = "monoFlat_ThemeContainer1";
            this.monoFlat_ThemeContainer1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlat_ThemeContainer1.RoundCorners = true;
            this.monoFlat_ThemeContainer1.Sizable = true;
            this.monoFlat_ThemeContainer1.Size = new System.Drawing.Size(223, 262);
            this.monoFlat_ThemeContainer1.SmartBounds = true;
            this.monoFlat_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.monoFlat_ThemeContainer1.TabIndex = 0;
            this.monoFlat_ThemeContainer1.Text = "Playlists managements";
            // 
            // Add_Movie_To_Playlist_Panel
            // 
            this.Add_Movie_To_Playlist_Panel.AutoScroll = true;
            this.Add_Movie_To_Playlist_Panel.Location = new System.Drawing.Point(16, 106);
            this.Add_Movie_To_Playlist_Panel.Name = "Add_Movie_To_Playlist_Panel";
            this.Add_Movie_To_Playlist_Panel.Size = new System.Drawing.Size(195, 114);
            this.Add_Movie_To_Playlist_Panel.TabIndex = 3;
            // 
            // Accept_Button
            // 
            this.Accept_Button.BackColor = System.Drawing.Color.Transparent;
            this.Accept_Button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Accept_Button.Image = null;
            this.Accept_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Accept_Button.Location = new System.Drawing.Point(52, 226);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(76, 24);
            this.Accept_Button.TabIndex = 2;
            this.Accept_Button.Text = "Accept";
            this.Accept_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Accept_Button.Click += new System.EventHandler(this.Accept_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.BackColor = System.Drawing.Color.Transparent;
            this.Cancel_Button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Cancel_Button.Image = null;
            this.Cancel_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel_Button.Location = new System.Drawing.Point(134, 226);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(76, 24);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // monoFlat_Label1
            // 
            this.monoFlat_Label1.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_Label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.monoFlat_Label1.Location = new System.Drawing.Point(12, 63);
            this.monoFlat_Label1.Name = "monoFlat_Label1";
            this.monoFlat_Label1.Size = new System.Drawing.Size(199, 40);
            this.monoFlat_Label1.TabIndex = 0;
            this.monoFlat_Label1.Text = "Check playlists that should contain this movie:";
            this.monoFlat_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlaylistsManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 262);
            this.ControlBox = false;
            this.Controls.Add(this.monoFlat_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaylistsManagement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Playlists managements";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoFlat_ThemeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        public System.Windows.Forms.Panel Add_Movie_To_Playlist_Panel;
        private MonoFlat.MonoFlat_Button Accept_Button;
        private MonoFlat.MonoFlat_Button Cancel_Button;
        private MonoFlat.MonoFlat_Label monoFlat_Label1;

    }
}