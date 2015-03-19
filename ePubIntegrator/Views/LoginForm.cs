using ePubIntegrator.Controllers;
using ePubIntegrator.Models;
using ePubIntegrator.ServiceReference_ePubCloud;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ePubIntegrator.Views {
    public partial class LoginForm : MetroForm {

        private User user;
        private ServiceePubLibraryClient ws;

        public LoginForm () {
            InitializeComponent();
            metroTextBoxEmail.Focus();
        }

        private void OnKeyDownHandler (object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                tryLogin();
            }
        }

        private void metroButtonSignUp_Click (object sender, System.EventArgs e) {
            var newUserForm = new NewUserForm(this);
            newUserForm.Visible = true;
            Visible = false;
        }

        private void metroButtonSignIn_Click (object sender, System.EventArgs e) {
            tryLogin();
        }

        private void loginGuest_Click (object sender, System.EventArgs e) {
            offlineMode();
        }

        /// <summary>
        /// Check if is possible stabilize a connection with webserice and BD and the input information is correct.
        /// </summary>
        private void tryLogin () {
            ws = new ServiceePubLibraryClient();
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("login");
            doc.AppendChild(root);

            XmlElement emailElement = doc.CreateElement("email");
            emailElement.InnerText = metroTextBoxEmail.Text;

            byte[] passBytes = Encoding.UTF8.GetBytes(metroTextBoxPassword.Text);
            string password = Convert.ToBase64String(sha1.ComputeHash(passBytes));

            XmlElement passwordElement = doc.CreateElement("password");
            passwordElement.InnerText = password;

            root.AppendChild(emailElement);
            root.AppendChild(passwordElement);

            if (XMLController.validaXml(doc, "login")) {
                try {
                    if (ws.Login(doc.OuterXml)) {
                        doc = new XmlDocument();
                        dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                        doc.AppendChild(dec);
                        root = doc.CreateElement("string");
                        root.InnerText = metroTextBoxEmail.Text;
                        doc.AppendChild(root);
                        MetroMessageBox.Show(this, @"You have been successfully logged.", @"Welcome", MessageBoxButtons.OK);
                        loginAccount(metroTextBoxEmail.Text);
                    } else {
                        MetroMessageBox.Show(this, @"Incorrect username or password. Please try again.", @"Invalid Login", MessageBoxButtons.OK);
                        metroTextBoxEmail.Focus();
                    }
                } catch (FaultException fe) {
                    if (MetroMessageBox.Show(this, @"Make sure you have Internet connection. Please try again.", @"Connection Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry) {
                        tryLogin();
                        ws.Close();
                    }
                }
                ws.Close();
            }
        }

        private void loginAccount (String email) {
            var mainForm = new MainForm(this, email);
            mainForm.Visible = true;
            Visible = false;
        }



        /// <summary>
        /// Login into MainForm for Offline Mode
        /// </summary>
        private void offlineMode () {
            var mainForm = new MainForm(this);
            mainForm.Visible = true;
            Visible = false;
        }

        private void MetroLinkOfflineMode_Click (object sender, EventArgs e) {
            offlineMode();
        }

        public void clearInputs () {
            this.metroTextBoxEmail.Clear();
            this.metroTextBoxPassword.Clear();
            this.metroTextBoxEmail.Focus();
        }
    }
}
