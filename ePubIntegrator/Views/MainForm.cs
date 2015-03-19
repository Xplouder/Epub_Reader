using ePubIntegrator.Controllers;
using ePubIntegrator.Models;
using ePubIntegrator.Properties;
using ePubIntegrator.ServiceReference_ePubCloud;
using EpubReader3;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ePubIntegrator.Views {
    public partial class MainForm : MetroForm {
        private const string _configFile = @"\epubConfigurations.xml";
        private const string _userEpubInfo = @"\userEpubInfo.xml";
        private string activeePubPath;
        private BackgroundWorker bw;
        private int currentZoom = 100;
        private EPubReader3 ePub;
        private string ePubDirectoryPath;
        private string homeDirectoryPath;
        private string configDirectoryPath;
        private bool isEpubFavourite;
        private bool isEpubBookmark;
        private readonly LoginForm loginForm;
        private List<MutableKeyValuePair<string, bool>> chaptersBookmarks = new List<MutableKeyValuePair<string, bool>>();
        private List<MutableKeyValuePair<string, bool>> chaptersFavourites = new List<MutableKeyValuePair<string, bool>>();
        private string oldTitle;
        private User user;

        public MainForm (LoginForm loginForm) {
            InitializeComponent();
            //Load Epub's Directory Home
            directoryLoad();
            initializeBackgroundWorker();

            this.loginForm = loginForm;
            metroLblUsername.Text = @"Offline Mode";
        }

        public MainForm (LoginForm loginForm, String email) {
            InitializeComponent();
            //Load Epub's Directory Home
            directoryLoad();
            initializeBackgroundWorker();

            this.loginForm = loginForm;

            if (!File.Exists(configDirectoryPath + _configFile)) {
                configUser(email);
            } else {
                XmlDocument doc = new XmlDocument();
                doc.Load(configDirectoryPath + _configFile);
                if (XMLController.validaXml(doc, "config") && XMLController.IsFileUser(configDirectoryPath + _configFile, email)) {
                    user = XMLController.GetUserFromFile(configDirectoryPath + _configFile);
                    ePubDirectoryPath = XMLController.GetEpubPathFromFile(configDirectoryPath + _configFile);
                } else {
                    configUser(email);
                }
            }

            getUserInfoFromWebService();

            metroLblUsername.Text = user.Username;
            refreshEpubList();
        }

        static Predicate<MutableKeyValuePair<string, bool>> ByKey (string nodeName) {
            return element => element.Key == nodeName;
        }

        private void configUser (string email) {
            try {
                user = getUser(email);
                XMLController.guardarConfigXml(user, ePubDirectoryPath, _configFile);
            } catch (Exception) {
                MetroMessageBox.Show(this, "An unexpected error has occurred.", "", MessageBoxButtons.OK);
            }
        }

        private void getUserInfoFromWebService () {
            var ws = new ServiceePubLibraryClient();
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Email;
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument userEpubInfo = new XmlDocument();
                userEpubInfo.LoadXml(ws.GetUserInfo(doc.OuterXml));

                //If any file exists any file with user epub info it will be replaced for the new one
                if (File.Exists(configDirectoryPath + _userEpubInfo)) {
                    File.Delete(configDirectoryPath + _userEpubInfo);
                }

                userEpubInfo.Save(configDirectoryPath + _userEpubInfo);
            }

            ws.Close();
        }

        private User getUser (String email) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("string");
            root.InnerText = email;
            doc.AppendChild(root);

            ServiceePubLibraryClient ws = new ServiceePubLibraryClient();

            User u;

            if (XMLController.validaXml(doc, "string")) {
                UserContract userContract = ws.GetUser(doc.OuterXml);
                u = new User(userContract, ePubDirectoryPath);
            } else {
                throw new Exception();
            }

            ws.Close();

            return u;
        }

        #region MainForm's Functional Methods
        /// <summary>
        ///     BackgroundWorker Thread Initializer
        /// </summary>
        private void initializeBackgroundWorker () {
            // Will be responsible for open and read the epub on a different thread
            bw = new BackgroundWorker {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        /// <summary>
        ///     Load the ePubReader Folder at HomeDirectory
        /// </summary>
        private void directoryLoad () {
            var drive = Environment.GetEnvironmentVariable("HOMEDRIVE");
            var home = Environment.GetEnvironmentVariable("HOMEPATH");
            homeDirectoryPath = drive + home;
            ePubDirectoryPath = homeDirectoryPath + @"\ePubReader";
            configDirectoryPath = ePubDirectoryPath + @"\config";

            if (!Directory.Exists(ePubDirectoryPath)) {
                //Create the directory
                Directory.CreateDirectory(ePubDirectoryPath);
            }

            if (!Directory.Exists(configDirectoryPath)) {
                //Create the directory
                Directory.CreateDirectory(configDirectoryPath);
            }

            //Load the directory into listViewDirectory
            refreshEpubList();
        }

        /// <summary>
        ///     Creates a Directory Node with/without ".epub" files from expecific folder
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        private TreeNode createDirectoryNode (DirectoryInfo directoryInfo) {
            var directoryNode = new TreeNode(directoryInfo.Name);

            foreach (var directory in directoryInfo.GetDirectories()) {
                var newDirectoryNode = createDirectoryNode(directory);
                newDirectoryNode.ImageIndex = 0;
                directoryNode.Nodes.Add(newDirectoryNode);
            }

            foreach (var file in directoryInfo.GetFiles()) {
                if (file.Extension.Equals(".epub")) {
                    var treeNode = new TreeNode(file.Name) {
                        ImageIndex = 3,
                        SelectedImageIndex = 3
                    };
                    directoryNode.Nodes.Add(treeNode);
                }
            }

            return directoryNode;
        }

        /// <summary>
        ///     Load a TreeView from an expecific Folder Path
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="path"></param>
        private void listDirectory (TreeView tree, string path) {
            tree.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            tree.Nodes.Add(createDirectoryNode(rootDirectoryInfo));
        }

        /// <summary>
        ///     Refresh treeview's list of folders and epub files in ePubDirectoryPath
        /// </summary>
        public void refreshEpubList () {
            listDirectory(treeViewDirectory, ePubDirectoryPath);
            treeViewDirectory.ExpandAll();
            metroTabContainer.SelectTab(0);
        }

        /// <summary>
        ///     Applies the Current Zoom value defined by user on Webbrowser
        /// </summary>
        private void applyCurrentZoom () {
            if (webBrowser.Document != null) {
                if (webBrowser.Document.Body != null) {
                    webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                    metroTrackBarZoom.Value = currentZoom;
                }
            }
        }

        private bool isWebBrowserEmpty (WebBrowser wB) {
            return wB.Document == null;
        }

        public string getEPubDirectoryPath () {
            return ePubDirectoryPath;
        }

        public void setEPubDirectoryPath (string newPath) {
            ePubDirectoryPath = newPath;

            if (user != null) {
                XMLController.SetEpubPath(configDirectoryPath + _configFile, newPath);
            }
        }

        private void sendUserInfoForWebService () {
            try {
                var ws = new ServiceePubLibraryClient();
                XmlDocument doc = new XmlDocument();
                doc.Load(configDirectoryPath + _userEpubInfo);

                if (XMLController.validaXml(doc, "sincronize")) {
                    ws.SetUserInfo(doc.OuterXml);
                }

                ws.Close();
            } catch (Exception) {
                MetroMessageBox.Show(this, "An unexpected error has occurred. Data may have been lost.", "", MessageBoxButtons.OK);
            }
        }

        private void bw_DoWork (object sender, DoWorkEventArgs e) {
            try {
                if (activeePubPath.EndsWith(".epub")) {
                    if (ePub == null) {
                        ePub = new EPubReader3(activeePubPath, treeView_Chapters, webBrowser);
                    } else {
                        ePub.closeEPUBFile();
                        ePub = new EPubReader3(activeePubPath, treeView_Chapters, webBrowser);
                    }
                }
            } catch (Exception) {
                ePub = null;
                MetroMessageBox.Show(this, @"Invalid File", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bw_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e) {
            if (ePub != null) {
                metroTabContainer.SelectTab(1);
            }
            pictureBoxLoadingEpub.Visible = false;
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Verify if was instacied a new Epub File
        /// (Workaround para conseguir monitorizar quando se abre ou não um novo epub
        /// pois só quero fazer o load das prefrencias uma vez por epub)
        /// </summary>
        /// <returns></returns>
        private bool isNewEpub () {
            return !ePub.getTitle().Equals(oldTitle);
        }

        private void loadEpubPreferences () {
            foreach (TreeNode n in treeView_Chapters.Nodes) {
                recursiveNodeFetch(n);
            }
        }

        private void recursiveNodeFetch (TreeNode treeNode) {

            chaptersBookmarks.Add(new MutableKeyValuePair<string, bool>(treeNode.Text, false));
            chaptersFavourites.Add(new MutableKeyValuePair<string, bool>(treeNode.Text, false));

            foreach (TreeNode tn in treeNode.Nodes) {
                recursiveNodeFetch(tn);
            }
        }
        #endregion

        #region MainForm's Events
        private void pictureBoxEpubInfo_Click (object sender, EventArgs e) {
            if (ePub != null) {
                EpubInformationForm epubInformationForm = new EpubInformationForm(ePub.getTitle(), ePub.getEPUB_Information());
                epubInformationForm.ShowDialog();
            }
        }

        private void metroLinkLogout_Click (object sender, EventArgs e) {
            if (MetroMessageBox.Show(this, @"Do you really want to exit?", @"", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {

                if (user != null) {
                    if (ePub != null) {
                        XMLController.addEpub(configDirectoryPath + _userEpubInfo, ePub.getTitle(), ePub.getEPUB_Information()[0], ePub.getEPUB_Information()[1], isEpubFavourite, isEpubBookmark, chaptersFavourites, chaptersBookmarks);
                    }

                    sendUserInfoForWebService();
                }

                Dispose();
                loginForm.clearInputs();
                loginForm.Show();
            }
        }

        private void metroButtonSettings_Click (object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
        }

        private void metroButtonStatistics_Click (object sender, EventArgs e) {
            if (user != null) {
                StatisticsForm statisticsForm = new StatisticsForm(user);
                statisticsForm.ShowDialog();
            } else {
                MetroMessageBox.Show(this, "You should login to access the statistics", "", MessageBoxButtons.OK);
            }
        }

        private void metroButtonRefreshList_Click (object sender, EventArgs e) {
            refreshEpubList();
        }

        private void treeViewDirectory_NodeMouseDoubleClick (object sender, TreeNodeMouseClickEventArgs e) {
            if (!bw.IsBusy && e.Node.FullPath.EndsWith(".epub")) {
                pictureBoxLoadingEpub.Visible = true;
                Cursor = Cursors.WaitCursor;
                if (ePub != null && user != null) {
                    XMLController.addEpub(configDirectoryPath + _userEpubInfo, ePub.getTitle(), ePub.getEPUB_Information()[0], ePub.getEPUB_Information()[1], isEpubFavourite, isEpubBookmark, chaptersFavourites, chaptersBookmarks);
                }

                activeePubPath = ePubDirectoryPath + @"\" + e.Node.Text;

                oldTitle = "";
                chaptersBookmarks = null;
                chaptersFavourites = null;
                bw.RunWorkerAsync();
            }
        }

        private void metroToggleHide_CheckedChanged (object sender, EventArgs e) {
            splitContainerCenter.Panel1Collapsed = !splitContainerCenter.Panel1Collapsed;
            metroLabelHideControl.Text = metroLabelHideControl.Text == @"Hide Controls" ? @"Show Controls" : @"Hide Controls";
        }

        private void metroButtonAddFile_Click (object sender, EventArgs e) {
            // Create an instance of the open file dialog box.
            var openFileDialog = new OpenFileDialog {
                Filter = @"Epub Files (*.epub)|*.epub|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false
            };

            // Process input if the user clicked OK on dialog box.
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                // Get the path of the opened file.
                var selectedFilePath = openFileDialog.InitialDirectory + openFileDialog.FileName;

                var fileProps = new FileInfo(openFileDialog.FileName);

                // Copy the selected file to Epub directory
                File.Copy(selectedFilePath, ePubDirectoryPath + @"\" + fileProps.Name);
                refreshEpubList();
            }
        }

        private void pictureBoxEpubFavourite_Click (object sender, EventArgs e) {
            if (!isWebBrowserEmpty(webBrowser)) {
                if (isEpubFavourite) {
                    pictureBoxEpubFavourite.Image = Resources.Unfavourite;
                    isEpubFavourite = false;
                } else {
                    pictureBoxEpubFavourite.Image = Resources.Favourite;
                    isEpubFavourite = true;
                }
            }
        }

        private void pictureBoxEpubBookmark_Click (object sender, EventArgs e) {
            if (!isWebBrowserEmpty(webBrowser)) {
                if (isEpubBookmark) {
                    pictureBoxEpubBookmark.Image = Resources.bookmarkDesactivated_png;
                    isEpubBookmark = false;
                } else {
                    pictureBoxEpubBookmark.Image = Resources.bookmarkActivated;
                    isEpubBookmark = true;
                }
            }
        }

        private void metroButtonChapterBookmark_Click (object sender, EventArgs e) {
            if (!isWebBrowserEmpty(webBrowser)) {
                if (treeView_Chapters.SelectedNode != null) {
                    if (chaptersBookmarks.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value) {
                        metroButtonChapterBookmark.BackgroundImage = Resources.ChapterBookmarkDesactivated;
                        chaptersBookmarks.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value = false;
                    } else {
                        metroButtonChapterBookmark.BackgroundImage = Resources.ChapterBookmarkActivated;
                        chaptersBookmarks.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value = true;
                    }
                }
            }
        }

        private void metroButtonChapterFavourite_Click (object sender, EventArgs e) {
            if (!isWebBrowserEmpty(webBrowser)) {
                if (treeView_Chapters.SelectedNode != null) {
                    if (chaptersFavourites.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value) {
                        metroButtonChapterFavourite.BackgroundImage = Resources.Unfavourite;
                        chaptersFavourites.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value = false;
                    } else {
                        metroButtonChapterFavourite.BackgroundImage = Resources.Favourite;
                        chaptersFavourites.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value = true;
                    }
                    //treeView_Chapters.SelectedNode = null;
                }
            }
        }

        private void treeView_Chapters_NodeMouseClick (object sender, TreeNodeMouseClickEventArgs e) {
            updateChapterButtons();
        }

        private void metroTrackBarZoom_ValueChanged (object sender, EventArgs e) {
            var bar = (MetroTrackBar) sender;
            if (webBrowser.Document != null) {
                if (webBrowser.Document.Body != null) {
                    if (bar.Value > currentZoom) {
                        currentZoom = bar.Value;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                    } else {
                        currentZoom = bar.Value;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                    }
                }
            }
        }

        private void mainForm_Closing (object sender, FormClosingEventArgs e) {
            if (
                MetroMessageBox.Show(this, @"Do you really want to exit?", @"", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.No) {
                e.Cancel = true;
            } else {
                loginForm.Dispose();
            }
        }

        private void metroButtonZoomOut_Click (object sender, EventArgs e) {
            if (webBrowser.Document != null) {
                if (webBrowser.Document.Body != null) {
                    if (currentZoom > 50 && currentZoom <= 200) {
                        currentZoom = currentZoom - 10;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                        metroTrackBarZoom.Value = currentZoom;
                    }
                }
            }
        }

        private void metroButtonZoomIn_Click (object sender, EventArgs e) {
            if (webBrowser.Document != null) {
                if (webBrowser.Document.Body != null) {
                    if (currentZoom >= 50 && currentZoom < 200) {
                        currentZoom = currentZoom + 10;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                        metroTrackBarZoom.Value = currentZoom;
                    }
                }
            }
        }

        private void metroTrackBarZoom_Scroll (object sender, ScrollEventArgs e) {
            if (webBrowser.Document != null) {
                if (webBrowser.Document.Body != null) {
                    if (e.NewValue > e.OldValue) {
                        currentZoom = e.NewValue;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                    } else {
                        currentZoom = e.NewValue;
                        webBrowser.Document.Body.Style = "zoom:" + currentZoom + "%;";
                    }
                }
            }
        }

        private void webBrowser_Navigated (object sender, WebBrowserNavigatedEventArgs e) {
            ePub.webBrowser_Navigated(sender, e);
        }

        private void webBrowser_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) {
            ePub.webBrowser_PreviewKeyDown(sender, e);
        }

        private void webBrowser_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e) {
            ePub.webBrowser_DocumentCompleted(sender, e);
            applyCurrentZoom();

            oldTitle = metroLabelEPubTitle.Text;
            metroLabelEPubTitle.Text = ePub.getTitle();

            if (isNewEpub()) {
                chaptersBookmarks = new List<MutableKeyValuePair<string, bool>>();
                chaptersFavourites = new List<MutableKeyValuePair<string, bool>>();
                loadEpubPreferences();
                updateChapterButtons();
            }
        }

        private void treeView_AfterSelect (object sender, TreeViewEventArgs e) {
            ePub.treeView_AfterSelect(sender, e);
        }

        #endregion

        //TODO: Falta dar reset às imagens e/ou colocar como está no XML...
        private void updateChapterButtons () {
            if (!isWebBrowserEmpty(webBrowser)) {
                if (treeView_Chapters.SelectedNode != null) {
                    metroButtonChapterBookmark.BackgroundImage = chaptersBookmarks.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value ? Resources.ChapterBookmarkActivated : Resources.ChapterBookmarkDesactivated;
                    metroButtonChapterFavourite.BackgroundImage = chaptersFavourites.Find(ByKey(treeView_Chapters.SelectedNode.Text)).Value ? Resources.Favourite : Resources.Unfavourite;
                }
            }
        }

    }

}
