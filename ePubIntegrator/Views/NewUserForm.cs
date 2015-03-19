using ePubIntegrator.Controllers;
using ePubIntegrator.Exceptions;
using ePubIntegrator.ServiceReference_ePubCloud;
using MetroFramework.Forms;
using System;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace ePubIntegrator.Views {
    public partial class NewUserForm : MetroForm {
        private readonly LoginForm loginForm;
        private readonly RegisterController rc;
        private static bool bvalid;

        public NewUserForm (LoginForm loginForm) {
            InitializeComponent();
            this.loginForm = loginForm;
            rc = new RegisterController();
            bvalid = true;
            ControlBox = false;
        }

        private void metroLinkCancel_Click (object sender, EventArgs e) {
            callLoginForm();
        }

        private void metroButtonRegister_Click (object sender, EventArgs e) {

            try {
                //Variable Assigns
                var username = metroTextBoxUsername.Text.Trim();
                var email = metroTextBoxEmail.Text.Trim();
                var password = metroTextBoxPassword.Text.Trim();
                var passwordConfirm = metroTextBoxPasswordConfirm.Text.Trim();
                metroDateTime.Format = DateTimePickerFormat.Short;
                var dateTime = metroDateTime.Text.Trim();

                //Activate Timer
                errorNotificationTimer.Enabled = true;

                //Check if all values are fine to go
                rc.validateRegisterValues(username, email, password, passwordConfirm, dateTime);

                ServiceePubLibraryClient ws = new ServiceePubLibraryClient();

                //Calc hash value (sha1)
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] passwordBytes = Encoding.UTF8.GetBytes(metroTextBoxPassword.Text);
                string passwordEncrypted = Convert.ToBase64String(sha1.ComputeHash(passwordBytes));

                //Reformating DataTimerPicker's return value
                metroDateTime.Format = DateTimePickerFormat.Custom;
                metroDateTime.CustomFormat = @"yyyy-MM-dd'T'hh':'mm':'ss";

                //Register new User

                //Create xml
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(dec);
                XmlElement root = doc.CreateElement("authentication");
                doc.AppendChild(root);

                XmlElement nicknameElement = doc.CreateElement("nickname");
                nicknameElement.InnerText = metroTextBoxUsername.Text;

                XmlElement emailElement = doc.CreateElement("email");
                emailElement.InnerText = metroTextBoxEmail.Text;

                XmlElement passwordElement = doc.CreateElement("password");
                passwordElement.InnerText = passwordEncrypted;

                XmlElement birthDateElement = doc.CreateElement("birthDate");
                birthDateElement.InnerText = metroDateTime.Text;

                root.AppendChild(nicknameElement);
                root.AppendChild(emailElement);
                root.AppendChild(passwordElement);
                root.AppendChild(birthDateElement);



                if (XMLController.validaXml(doc, "newUser")) {
                    try {
                        ws.RegisterUser(doc.OuterXml);
                        callLoginForm();
                    } catch (FaultException fe) {
                        MessageBox.Show("O email introduzido já está a ser utilizado. Introduza outro.");
                        metroTextBoxEmail.Focus();
                    }
                } else {
                    //nao validou o xml
                }


                ws.Close();
            } catch (InvalidUsernameException) {
                metroTextBoxUsername.Focus();
                metroLabelErrorNotification.Text = @"Please insert a valid Username";
            } catch (InvalidEmailException) {
                metroTextBoxEmail.Focus();
                metroLabelErrorNotification.Text = @"Please insert a valid Email";
            } catch (InvalidPasswordException) {
                resetPasswords();
                metroTextBoxPassword.Focus();
                metroLabelErrorNotification.Text = @"Please insert a valid Password";
            } catch (InvalidPasswordConfirmException) {
                resetPasswords();
                metroTextBoxPassword.Focus();
                metroLabelErrorNotification.Text = @"Wrong Password Confirmation";
            } catch (InvalidDateTimeException) {
                metroDateTime.Focus();
                metroLabelErrorNotification.Text = @"You should be +6 years old";
            } finally {
                metroDateTime.Format = DateTimePickerFormat.Long;
            }



        }

        private void resetPasswords () {
            metroTextBoxPassword.Clear();
            metroTextBoxPasswordConfirm.Clear();
            pictureBoxPassword.Visible = false;
            pictureBoxPasswordConfirm.Visible = false;
        }

        private void callLoginForm () {
            loginForm.Visible = true;
            loginForm.Focus();
            Dispose();
        }

        private void refreshImage (PictureBox pictureBox, bool isValid) {
            if (!pictureBox.Visible) {
                pictureBox.Visible = true;
            }
            pictureBox.Image = isValid ? Properties.Resources.Check : Properties.Resources.Close;
        }

        private void metroTextBoxUsername_TextChanged (object sender, EventArgs e) {
            refreshImage(pictureBoxUsername, rc.isValidUsername(metroTextBoxUsername.Text));
        }

        private void metroTextBoxEmail_TextChanged (object sender, EventArgs e) {
            refreshImage(pictureBoxEmail, rc.isValidEmail(metroTextBoxEmail.Text));
        }

        private void metroTextBoxPassword_TextChanged (object sender, EventArgs e) {
            refreshImage(pictureBoxPassword, rc.isValidPassword(metroTextBoxPassword.Text));
        }

        private void metroTextBoxPasswordConfirm_TextChanged (object sender, EventArgs e) {
            refreshImage(pictureBoxPasswordConfirm, rc.isSamePassword(metroTextBoxPassword.Text, metroTextBoxPasswordConfirm.Text));
        }

        private void metroDateTime_TextChanged (object sender, EventArgs e) {
            refreshImage(pictureBoxDateTime, rc.isValidDateTime(metroDateTime.Text));
        }

        private void onTimerEvent (object sender, EventArgs e) {
            metroLabelErrorNotification.Text = String.Empty;
            errorNotificationTimer.Enabled = false;
        }



    }
}
