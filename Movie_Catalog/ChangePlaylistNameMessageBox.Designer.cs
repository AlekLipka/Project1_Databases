namespace Movie_Catalog
{
    partial class ChangePlaylistNameMessageBox
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
            this.Accept_Button = new MonoFlat.MonoFlat_Button();
            this.Cancel_Button = new MonoFlat.MonoFlat_Button();
            this.monoFlat_TextBox1 = new MonoFlat.MonoFlat_TextBox();
            this.monoFlat_Label1 = new MonoFlat.MonoFlat_Label();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.Accept_Button);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Cancel_Button);
            this.monoFlat_ThemeContainer1.Controls.Add(this.monoFlat_TextBox1);
            this.monoFlat_ThemeContainer1.Controls.Add(this.monoFlat_Label1);
            this.monoFlat_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlat_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.monoFlat_ThemeContainer1.Name = "monoFlat_ThemeContainer1";
            this.monoFlat_ThemeContainer1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlat_ThemeContainer1.RoundCorners = true;
            this.monoFlat_ThemeContainer1.Sizable = false;
            this.monoFlat_ThemeContainer1.Size = new System.Drawing.Size(284, 234);
            this.monoFlat_ThemeContainer1.SmartBounds = true;
            this.monoFlat_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.monoFlat_ThemeContainer1.TabIndex = 0;
            this.monoFlat_ThemeContainer1.Text = "    Change the Playlist Name";
            // 
            // Accept_Button
            // 
            this.Accept_Button.BackColor = System.Drawing.Color.Transparent;
            this.Accept_Button.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Accept_Button.Image = null;
            this.Accept_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Accept_Button.Location = new System.Drawing.Point(68, 197);
            this.Accept_Button.Name = "Accept_Button";
            this.Accept_Button.Size = new System.Drawing.Size(99, 25);
            this.Accept_Button.TabIndex = 3;
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
            this.Cancel_Button.Location = new System.Drawing.Point(173, 197);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(99, 25);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.TextAlignment = System.Drawing.StringAlignment.Center;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // monoFlat_TextBox1
            // 
            this.monoFlat_TextBox1.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_TextBox1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.monoFlat_TextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.monoFlat_TextBox1.Image = null;
            this.monoFlat_TextBox1.Location = new System.Drawing.Point(12, 119);
            this.monoFlat_TextBox1.MaxLength = 32767;
            this.monoFlat_TextBox1.Multiline = false;
            this.monoFlat_TextBox1.Name = "monoFlat_TextBox1";
            this.monoFlat_TextBox1.ReadOnly = false;
            this.monoFlat_TextBox1.Size = new System.Drawing.Size(258, 41);
            this.monoFlat_TextBox1.TabIndex = 1;
            this.monoFlat_TextBox1.Text = "New Playlist Name";
            this.monoFlat_TextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.monoFlat_TextBox1.UseSystemPasswordChar = false;
            // 
            // monoFlat_Label1
            // 
            this.monoFlat_Label1.AutoSize = true;
            this.monoFlat_Label1.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_Label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.monoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.monoFlat_Label1.Location = new System.Drawing.Point(33, 80);
            this.monoFlat_Label1.Name = "monoFlat_Label1";
            this.monoFlat_Label1.Size = new System.Drawing.Size(217, 21);
            this.monoFlat_Label1.TabIndex = 0;
            this.monoFlat_Label1.Text = "Give the new name of playlist:";
            // 
            // ChangePlaylistNameMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 234);
            this.ControlBox = false;
            this.Controls.Add(this.monoFlat_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePlaylistNameMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "    Change the Playlist Name";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoFlat_ThemeContainer1.ResumeLayout(false);
            this.monoFlat_ThemeContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        private MonoFlat.MonoFlat_Button Accept_Button;
        private MonoFlat.MonoFlat_Button Cancel_Button;
        private MonoFlat.MonoFlat_TextBox monoFlat_TextBox1;
        private MonoFlat.MonoFlat_Label monoFlat_Label1;
    }
}