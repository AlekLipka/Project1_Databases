namespace Movie_Catalog
{
    partial class Form2
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
            this.Change_Path_Btn = new System.Windows.Forms.Button();
            this.Remove_From_DB_Btn = new System.Windows.Forms.Button();
            this.MessageBox_Label1 = new System.Windows.Forms.Label();
            this.MessageBox_File_Name = new System.Windows.Forms.Label();
            this.MessageBox_Label2 = new System.Windows.Forms.Label();
            this.MessageBox_File_Path = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Change_Path_Btn
            // 
            this.Change_Path_Btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Change_Path_Btn.Location = new System.Drawing.Point(95, 143);
            this.Change_Path_Btn.Name = "Change_Path_Btn";
            this.Change_Path_Btn.Size = new System.Drawing.Size(128, 23);
            this.Change_Path_Btn.TabIndex = 0;
            this.Change_Path_Btn.Text = "Give new location";
            this.Change_Path_Btn.UseVisualStyleBackColor = true;
            // 
            // Remove_From_DB_Btn
            // 
            this.Remove_From_DB_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Remove_From_DB_Btn.Location = new System.Drawing.Point(229, 143);
            this.Remove_From_DB_Btn.Name = "Remove_From_DB_Btn";
            this.Remove_From_DB_Btn.Size = new System.Drawing.Size(128, 23);
            this.Remove_From_DB_Btn.TabIndex = 1;
            this.Remove_From_DB_Btn.Text = "Remove from database";
            this.Remove_From_DB_Btn.UseVisualStyleBackColor = true;
            // 
            // MessageBox_Label1
            // 
            this.MessageBox_Label1.Location = new System.Drawing.Point(3, 9);
            this.MessageBox_Label1.Name = "MessageBox_Label1";
            this.MessageBox_Label1.Size = new System.Drawing.Size(366, 13);
            this.MessageBox_Label1.TabIndex = 2;
            this.MessageBox_Label1.Text = "The file:";
            this.MessageBox_Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_File_Name
            // 
            this.MessageBox_File_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageBox_File_Name.Location = new System.Drawing.Point(0, 22);
            this.MessageBox_File_Name.Name = "MessageBox_File_Name";
            this.MessageBox_File_Name.Size = new System.Drawing.Size(369, 43);
            this.MessageBox_File_Name.TabIndex = 3;
            this.MessageBox_File_Name.Text = "<filename>";
            this.MessageBox_File_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_Label2
            // 
            this.MessageBox_Label2.Location = new System.Drawing.Point(0, 65);
            this.MessageBox_Label2.Name = "MessageBox_Label2";
            this.MessageBox_Label2.Size = new System.Drawing.Size(369, 21);
            this.MessageBox_Label2.TabIndex = 4;
            this.MessageBox_Label2.Text = "is not in the directory: ";
            this.MessageBox_Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBox_File_Path
            // 
            this.MessageBox_File_Path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessageBox_File_Path.Location = new System.Drawing.Point(0, 86);
            this.MessageBox_File_Path.Name = "MessageBox_File_Path";
            this.MessageBox_File_Path.Size = new System.Drawing.Size(369, 54);
            this.MessageBox_File_Path.TabIndex = 5;
            this.MessageBox_File_Path.Text = "<filepath>";
            this.MessageBox_File_Path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AcceptButton = this.Change_Path_Btn;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Remove_From_DB_Btn;
            this.ClientSize = new System.Drawing.Size(369, 178);
            this.Controls.Add(this.MessageBox_File_Path);
            this.Controls.Add(this.MessageBox_Label2);
            this.Controls.Add(this.MessageBox_File_Name);
            this.Controls.Add(this.MessageBox_Label1);
            this.Controls.Add(this.Remove_From_DB_Btn);
            this.Controls.Add(this.Change_Path_Btn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No such file in directory!";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Change_Path_Btn;
        private System.Windows.Forms.Button Remove_From_DB_Btn;
        private System.Windows.Forms.Label MessageBox_Label1;
        public System.Windows.Forms.Label MessageBox_File_Name;
        private System.Windows.Forms.Label MessageBox_Label2;
        public System.Windows.Forms.Label MessageBox_File_Path;
    }
}