using MetroFramework.Forms;
using System;
using System.Collections;

namespace ePubIntegrator.Views {
    public partial class EpubInformationForm : MetroForm {

        public EpubInformationForm (string title, ArrayList epubInformationList) {
            InitializeComponent();
            loadEpubInfo(title, epubInformationList);
        }

        private void loadEpubInfo (string epubTitle, ArrayList epubInformationList) {
            title.Text = epubTitle != null ? epubTitle : "";
            creator.Text = epubInformationList[0] != null ? (String) epubInformationList[0] : "";
            subject.Text = epubInformationList[1] != null ? (String) epubInformationList[1] : "";
            description.Text = epubInformationList[2] != null ? (String) epubInformationList[2] : "";
            publisher.Text = epubInformationList[3] != null ? (String) epubInformationList[3] : "";
            contributor.Text = epubInformationList[4] != null ? (String) epubInformationList[4] : "";
            date.Text = epubInformationList[5] != null ? (String) epubInformationList[5] : "";
            type.Text = epubInformationList[6] != null ? (String) epubInformationList[6] : "";
            format.Text = epubInformationList[7] != null ? (String) epubInformationList[7] : "";
            identifier.Text = epubInformationList[8] != null ? (String) epubInformationList[8] : "";
            source.Text = epubInformationList[9] != null ? (String) epubInformationList[9] : "";
            language.Text = epubInformationList[10] != null ? (String) epubInformationList[10] : "";
            relation.Text = epubInformationList[11] != null ? (String) epubInformationList[11] : "";
            coverage.Text = epubInformationList[12] != null ? (String) epubInformationList[12] : "";
            rights.Text = epubInformationList[13] != null ? (String) epubInformationList[13] : "";
        }
    }
}
