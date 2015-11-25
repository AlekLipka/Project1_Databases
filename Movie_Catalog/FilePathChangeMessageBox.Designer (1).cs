namespace Movie_Catalog
{
    partial class FilePathChangeMessageBox
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
            this.MessageBox_File_Path = new System.Windows.Forms.Label();
            this.MessageBox_Label2 = new System.Windows.Forms.Label();
            this.MessageBox_File_Name = new System.Windows.Forms.Label();
            this.MessageBox_Label1 = new System.Windows.Forms.Label();
            this.Remove_From_DB_Btn = new System.Windows.Forms.Button();
            this.Change_Path_Btn = new System.Windows.Forms.Button();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.MessageBox_File_Path);
            this.monoFlat_ThemeContainer1.Controls.Add(this.MessageBox_Label2);
            this.monoFlat_ThemeContainer1.Controls.Add(this.MessageBox_File_Name);
            this.monoFlat_ThemeContainer1.Controls.Add(this.MessageBox_Label1);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Remove_From_DB_Btn);
            this.monoFlat_ThemeContainer1.Controls.Add(this.Change_Path_Btn);
            this.monoFlat_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlat_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.monoFlat_ThemeContainer1.Name = "monoFlat_ThemeContainer1";
            this.monoFlat_ThemeContainer1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlat_ThemeContainer1.RoundCorners = true;
            this.monoFlat_ThemeContainer1.Sizable = false;
            this.monoFlat_ThemeContainer1.Size = new System.Drawing.Size(369, 246);
            this.monoFlat_ThemeContainer1.SmartBounds = true;
            this.monoFlat_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.monoFlat_ThemeContainer1.TabIndex = 0;
            this.monoFlat_ThemeContainer1.Text = "              No such File in Directory!";
            // 
            // MessageBox_File_Path
            // 
            this.MessageBox_File_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageBox_File_Path.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessageBox_File_Path.Location = new System.Drawing.Point(-3, 145);
            this.MessageBox_File_Path.Name = "MessageBox_File_Path";
            this.MessageBox_File_Path.Size = new System.Drawing.Size(369, 54);
            this.MessageBox_File_Path.TabIndex = 11;
            this.MessageBox_File_Path.Text = "<filepath>";
            this.MessageBox_File_Path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_Label2
            // 
            this.MessageBox_Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessageBox_Label2.Location = new System.Drawing.Point(-1, 124);
            this.MessageBox_Label2.Name = "MessageBox_Label2";
            this.MessageBox_Label2.Size = new System.Drawing.Size(369, 21);
            this.MessageBox_Label2.TabIndex = 10;
            this.MessageBox_Label2.Text = "is not in the directory: ";
            this.MessageBox_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_File_Name
            // 
            this.MessageBox_File_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageBox_File_Name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessageBox_File_Name.Location = new System.Drawing.Point(-1, 81);
            this.MessageBox_File_Name.Name = "MessageBox_File_Name";
            this.MessageBox_File_Name.Size = new System.Drawing.Size(369, 43);
            this.MessageBox_File_Name.TabIndex = 9;
            this.MessageBox_File_Name.Text = "<filename>";
            this.MessageBox_File_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_Label1
            // 
            this.MessageBox_Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MessageBox_Label1.Location = new System.Drawing.Point(2, 68);
            this.MessageBox_Label1.Name = "MessageBox_Label1";
            this.MessageBox_Label1.Size = new System.Drawing.Size(366, 13);
            this.MessageBox_Label1.TabIndex = 8;
            this.MessageBox_Label1.Text = "The file:";
            this.MessageBox_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Remove_From_DB_Btn
            // 
            this.Remove_From_DB_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Remove_From_DB_Btn.Location = new System.Drawing.Point(211, 202);
            this.Remove_From_DB_Btn.Name = "Remove_From_DB_Btn";
            this.Remove_From_DB_Btn.Size = new System.Drawing.Size(145, 30);
            this.Remove_From_DB_Btn.TabIndex = 7;
            this.Remove_From_DB_Btn.Text = "Remove from database";
            this.Remove_From_DB_Btn.UseVisualStyleBackColor = true;
            // 
            // Change_Path_Btn
            // 
            this.Change_Path_Btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Change_Path_Btn.Location = new System.Drawing.Point(60, 202);
            this.Change_Path_Btn.Name = "Change_Path_Btn";
            this.Change_Path_Btn.Size = new System.Drawing.Size(145, 30);
            this.Change_Path_Btn.TabIndex = 6;
            this.Change_Path_Btn.Text = "Give new location";
            this.Change_Path_Btn.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 246);
            this.Controls.Add(this.monoFlat_ThemeContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "              No such File in Directory!";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoFlat_ThemeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        public System.Windows.Forms.Label MessageBox_File_Path;
        private System.Windows.Forms.Label MessageBox_Label2;
        public System.Windows.Forms.Label MessageBox_File_Name;
        private System.Windows.Forms.Label MessageBox_Label1;
        private System.Windows.Forms.Button Remove_From_DB_Btn;
        private System.Windows.Forms.Button Change_Path_Btn;

    }
}