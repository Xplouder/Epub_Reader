using System.Drawing;

namespace ePubIntegrator.Views {
    partial class LoginForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.metroTextBoxEmail = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroButtonSignIn = new MetroFramework.Controls.MetroButton();
            this.metroButtonSignUp = new MetroFramework.Controls.MetroButton();
            this.MetroLinkOfflineMode = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // metroTextBoxEmail
            // 
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
            // 
            // metroTextBoxPassword
            // 
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
            this.metroTextBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            // 
            // metroButtonSignIn
            // 
            resources.ApplyResources(this.metroButtonSignIn, "metroButtonSignIn");
            this.metroButtonSignIn.Name = "metroButtonSignIn";
            this.metroButtonSignIn.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonSignIn.UseSelectable = true;
            this.metroButtonSignIn.Click += new System.EventHandler(this.metroButtonSignIn_Click);
            // 
            // metroButtonSignUp
            // 
            resources.ApplyResources(this.metroButtonSignUp, "metroButtonSignUp");
            this.metroButtonSignUp.Name = "metroButtonSignUp";
            this.metroButtonSignUp.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonSignUp.UseSelectable = true;
            this.metroButtonSignUp.Click += new System.EventHandler(this.metroButtonSignUp_Click);
            // 
            // MetroLinkOfflineMode
            // 
            resources.ApplyResources(this.MetroLinkOfflineMode, "MetroLinkOfflineMode");
            this.MetroLinkOfflineMode.Name = "MetroLinkOfflineMode";
            this.MetroLinkOfflineMode.UseSelectable = true;
            this.MetroLinkOfflineMode.Click += new System.EventHandler(this.MetroLinkOfflineMode_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.MetroLinkOfflineMode);
            this.Controls.Add(this.metroButtonSignUp);
            this.Controls.Add(this.metroButtonSignIn);
            this.Controls.Add(this.metroTextBoxPassword);
            this.Controls.Add(this.metroTextBoxEmail);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBoxEmail;
        private MetroFramework.Controls.MetroTextBox metroTextBoxPassword;
        private MetroFramework.Controls.MetroButton metroButtonSignIn;
        private MetroFramework.Controls.MetroButton metroButtonSignUp;
        private MetroFramework.Controls.MetroLink MetroLinkOfflineMode;

    }
}

