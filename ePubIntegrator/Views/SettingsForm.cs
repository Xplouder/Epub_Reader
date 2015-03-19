using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Interfaces;

namespace ePubIntegrator.Views {
    public partial class SettingsForm : MetroForm {
        private MainForm mainForm;
        private string newEPubDirectoryPath;

        public SettingsForm (MainForm mainForm) {
            InitializeComponent();
            this.mainForm = mainForm;
            this.pictureBoxEdit.Image = global::ePubIntegrator.Properties.Resources.edit;

            this.metroTextBoxEpubReaderFolderPath.Text = mainForm.getEPubDirectoryPath();
        }

        private void metroButtonSave_Click (object sender, EventArgs e) {
            MetroMessageBox.Show(mainForm, "Settings Saved Successfully", "", MessageBoxButtons.OK);
            mainForm.setEPubDirectoryPath(newEPubDirectoryPath);
            mainForm.refreshEpubList();
            this.Dispose();
        }

        private void pictureBoxEdit_Click (object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK) {
                newEPubDirectoryPath = fbd.SelectedPath;
                metroTextBoxEpubReaderFolderPath.Text = newEPubDirectoryPath;
            }
        }

    }
}
