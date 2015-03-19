namespace ePubIntegrator.Views {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.metroButtonSave = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxEpubReaderFolderPath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.pictureBoxEdit);
            this.metroPanel1.Controls.Add(this.metroButtonSave);
            this.metroPanel1.Controls.Add(this.metroTextBoxEpubReaderFolderPath);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(24, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(253, 96);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Location = new System.Drawing.Point(227, 27);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(22, 23);
            this.pictureBoxEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEdit.TabIndex = 6;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            // 
            // metroButtonSave
            // 
            this.metroButtonSave.Location = new System.Drawing.Point(175, 70);
            this.metroButtonSave.Name = "metroButtonSave";
            this.metroButtonSave.Size = new System.Drawing.Size(75, 23);
            this.metroButtonSave.TabIndex = 5;
            this.metroButtonSave.Text = "Save";
            this.metroButtonSave.UseSelectable = true;
            this.metroButtonSave.Click += new System.EventHandler(this.metroButtonSave_Click);
            // 
            // metroTextBoxEpubReaderFolderPath
            // 
            this.metroTextBoxEpubReaderFolderPath.Enabled = false;
            this.metroTextBoxEpubReaderFolderPath.Lines = new string[0];
            this.metroTextBoxEpubReaderFolderPath.Location = new System.Drawing.Point(4, 27);
            this.metroTextBoxEpubReaderFolderPath.MaxLength = 32767;
            this.metroTextBoxEpubReaderFolderPath.Name = "metroTextBoxEpubReaderFolderPath";
            this.metroTextBoxEpubReaderFolderPath.PasswordChar = '\0';
            this.metroTextBoxEpubReaderFolderPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxEpubReaderFolderPath.SelectedText = "";
            this.metroTextBoxEpubReaderFolderPath.Size = new System.Drawing.Size(217, 23);
            this.metroTextBoxEpubReaderFolderPath.TabIndex = 3;
            this.metroTextBoxEpubReaderFolderPath.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(166, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Epub Reader\'s Folder Path:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 182);
            this.Controls.Add(this.metroPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "SettingsForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Settings";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private MetroFramework.Controls.MetroButton metroButtonSave;
        private MetroFramework.Controls.MetroTextBox metroTextBoxEpubReaderFolderPath;
        private MetroFramework.Controls.MetroLabel metroLabel1;

    }
}