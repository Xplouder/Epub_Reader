namespace ePubIntegrator.Views {
    partial class NewUserForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUserForm));
            this.metroTextBoxUsername = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxEmail = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPasswordConfirm = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonRegister = new MetroFramework.Controls.MetroButton();
            this.metroLinkCancel = new MetroFramework.Controls.MetroLink();
            this.metroDateTime = new MetroFramework.Controls.MetroDateTime();
            this.pictureBoxDateTime = new System.Windows.Forms.PictureBox();
            this.pictureBoxPassword = new System.Windows.Forms.PictureBox();
            this.pictureBoxEmail = new System.Windows.Forms.PictureBox();
            this.pictureBoxUsername = new System.Windows.Forms.PictureBox();
            this.pictureBoxPasswordConfirm = new System.Windows.Forms.PictureBox();
            this.errorNotificationTimer = new System.Windows.Forms.Timer(this.components);
            this.metroLabelErrorNotification = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTextBoxUsername
            // 
            this.metroTextBoxUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxUsername.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxUsername, "metroTextBoxUsername");
            this.metroTextBoxUsername.MaxLength = 32767;
            this.metroTextBoxUsername.Name = "metroTextBoxUsername";
            this.metroTextBoxUsername.PasswordChar = '\0';
            this.metroTextBoxUsername.PromptText = "Username";
            this.metroTextBoxUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxUsername.SelectedText = "";
            this.metroTextBoxUsername.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextBoxUsername.UseSelectable = true;
            this.metroTextBoxUsername.TextChanged += new System.EventHandler(this.metroTextBoxUsername_TextChanged);
            // 
            // metroTextBoxEmail
            // 
            this.metroTextBoxEmail.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxEmail.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxEmail, "metroTextBoxEmail");
            this.metroTextBoxEmail.MaxLength = 32767;
            this.metroTextBoxEmail.Name = "metroTextBoxEmail";
            this.metroTextBoxEmail.PasswordChar = '\0';
            this.metroTextBoxEmail.PromptText = "Email";
            this.metroTextBoxEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxEmail.SelectedText = "";
            this.metroTextBoxEmail.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextBoxEmail.UseSelectable = true;
            this.metroTextBoxEmail.TextChanged += new System.EventHandler(this.metroTextBoxEmail_TextChanged);
            // 
            // metroTextBoxPassword
            // 
            this.metroTextBoxPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxPassword.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxPassword, "metroTextBoxPassword");
            this.metroTextBoxPassword.MaxLength = 32767;
            this.metroTextBoxPassword.Name = "metroTextBoxPassword";
            this.metroTextBoxPassword.PasswordChar = '*';
            this.metroTextBoxPassword.PromptText = "Password";
            this.metroTextBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPassword.SelectedText = "";
            this.metroTextBoxPassword.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextBoxPassword.UseSelectable = true;
            this.metroTextBoxPassword.TextChanged += new System.EventHandler(this.metroTextBoxPassword_TextChanged);
            // 
            // metroTextBoxPasswordConfirm
            // 
            this.metroTextBoxPasswordConfirm.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxPasswordConfirm.Lines = new string[0];
            resources.ApplyResources(this.metroTextBoxPasswordConfirm, "metroTextBoxPasswordConfirm");
            this.metroTextBoxPasswordConfirm.MaxLength = 32767;
            this.metroTextBoxPasswordConfirm.Name = "metroTextBoxPasswordConfirm";
            this.metroTextBoxPasswordConfirm.PasswordChar = '*';
            this.metroTextBoxPasswordConfirm.PromptText = "Confirm Password";
            this.metroTextBoxPasswordConfirm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxPasswordConfirm.SelectedText = "";
            this.metroTextBoxPasswordConfirm.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextBoxPasswordConfirm.UseSelectable = true;
            this.metroTextBoxPasswordConfirm.TextChanged += new System.EventHandler(this.metroTextBoxPasswordConfirm_TextChanged);
            // 
            // metroButtonRegister
            // 
            resources.ApplyResources(this.metroButtonRegister, "metroButtonRegister");
            this.metroButtonRegister.Name = "metroButtonRegister";
            this.metroButtonRegister.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonRegister.UseSelectable = true;
            this.metroButtonRegister.Click += new System.EventHandler(this.metroButtonRegister_Click);
            // 
            // metroLinkCancel
            // 
            resources.ApplyResources(this.metroLinkCancel, "metroLinkCancel");
            this.metroLinkCancel.Name = "metroLinkCancel";
            this.metroLinkCancel.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLinkCancel.UseSelectable = true;
            this.metroLinkCancel.Click += new System.EventHandler(this.metroLinkCancel_Click);
            // 
            // metroDateTime
            // 
            resources.ApplyResources(this.metroDateTime, "metroDateTime");
            this.metroDateTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.metroDateTime.Name = "metroDateTime";
            this.metroDateTime.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroDateTime.TextChanged += new System.EventHandler(this.metroDateTime_TextChanged);
            // 
            // pictureBoxDateTime
            // 
            this.pictureBoxDateTime.Image = global::ePubIntegrator.Properties.Resources.Close;
            resources.ApplyResources(this.pictureBoxDateTime, "pictureBoxDateTime");
            this.pictureBoxDateTime.Name = "pictureBoxDateTime";
            this.pictureBoxDateTime.TabStop = false;
            // 
            // pictureBoxPassword
            // 
            this.pictureBoxPassword.Image = global::ePubIntegrator.Properties.Resources.Close;
            resources.ApplyResources(this.pictureBoxPassword, "pictureBoxPassword");
            this.pictureBoxPassword.Name = "pictureBoxPassword";
            this.pictureBoxPassword.TabStop = false;
            // 
            // pictureBoxEmail
            // 
            this.pictureBoxEmail.Image = global::ePubIntegrator.Properties.Resources.Close;
            resources.ApplyResources(this.pictureBoxEmail, "pictureBoxEmail");
            this.pictureBoxEmail.Name = "pictureBoxEmail";
            this.pictureBoxEmail.TabStop = false;
            // 
            // pictureBoxUsername
            // 
            this.pictureBoxUsername.Image = global::ePubIntegrator.Properties.Resources.Close;
            resources.ApplyResources(this.pictureBoxUsername, "pictureBoxUsername");
            this.pictureBoxUsername.Name = "pictureBoxUsername";
            this.pictureBoxUsername.TabStop = false;
            // 
            // pictureBoxPasswordConfirm
            // 
            this.pictureBoxPasswordConfirm.Image = global::ePubIntegrator.Properties.Resources.Close;
            resources.ApplyResources(this.pictureBoxPasswordConfirm, "pictureBoxPasswordConfirm");
            this.pictureBoxPasswordConfirm.Name = "pictureBoxPasswordConfirm";
            this.pictureBoxPasswordConfirm.TabStop = false;
            // 
            // errorNotificationTimer
            // 
            this.errorNotificationTimer.Interval = 10000;
            this.errorNotificationTimer.Tick += new System.EventHandler(this.onTimerEvent);
            // 
            // metroLabelErrorNotification
            // 
            resources.ApplyResources(this.metroLabelErrorNotification, "metroLabelErrorNotification");
            this.metroLabelErrorNotification.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelErrorNotification.ForeColor = System.Drawing.Color.Red;
            this.metroLabelErrorNotification.Name = "metroLabelErrorNotification";
            this.metroLabelErrorNotification.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabelErrorNotification.UseCustomForeColor = true;
            // 
            // NewUserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabelErrorNotification);
            this.Controls.Add(this.pictureBoxPasswordConfirm);
            this.Controls.Add(this.pictureBoxDateTime);
            this.Controls.Add(this.pictureBoxPassword);
            this.Controls.Add(this.pictureBoxEmail);
            this.Controls.Add(this.pictureBoxUsername);
            this.Controls.Add(this.metroDateTime);
            this.Controls.Add(this.metroLinkCancel);
            this.Controls.Add(this.metroButtonRegister);
            this.Controls.Add(this.metroTextBoxPasswordConfirm);
            this.Controls.Add(this.metroTextBoxPassword);
            this.Controls.Add(this.metroTextBoxEmail);
            this.Controls.Add(this.metroTextBoxUsername);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUserForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPasswordConfirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBoxUsername;
        private MetroFramework.Controls.MetroTextBox metroTextBoxEmail;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPassword;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPasswordConfirm;
        private MetroFramework.Controls.MetroButton metroButtonRegister;
        private MetroFramework.Controls.MetroLink metroLinkCancel;
		private MetroFramework.Controls.MetroDateTime metroDateTime;
		private System.Windows.Forms.PictureBox pictureBoxUsername;
		private System.Windows.Forms.PictureBox pictureBoxEmail;
		private System.Windows.Forms.PictureBox pictureBoxPassword;
		private System.Windows.Forms.PictureBox pictureBoxDateTime;
		private System.Windows.Forms.PictureBox pictureBoxPasswordConfirm;
		private System.Windows.Forms.Timer errorNotificationTimer;
		private MetroFramework.Controls.MetroLabel metroLabelErrorNotification;
    }
}