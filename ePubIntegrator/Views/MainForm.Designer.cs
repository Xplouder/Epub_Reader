using System;
using System.Windows.Forms;

namespace ePubIntegrator.Views {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.treeViewDirectory = new System.Windows.Forms.TreeView();
            this.imageListDirectory = new System.Windows.Forms.ImageList(this.components);
            this.metroPanelMenu = new MetroFramework.Controls.MetroPanel();
            this.pictureBoxEpubInfo = new System.Windows.Forms.PictureBox();
            this.metroButtonSettings = new MetroFramework.Controls.MetroButton();
            this.pictureBoxEpubBookmark = new System.Windows.Forms.PictureBox();
            this.pictureBoxEpubFavourite = new System.Windows.Forms.PictureBox();
            this.metroLabelEPubTitle = new MetroFramework.Controls.MetroLabel();
            this.metroButtonStatistics = new MetroFramework.Controls.MetroButton();
            this.metroTrackBarZoom = new MetroFramework.Controls.MetroTrackBar();
            this.metroPanelFooter = new MetroFramework.Controls.MetroPanel();
            this.metroLabelHideControl = new MetroFramework.Controls.MetroLabel();
            this.metroButtonZoomIn = new MetroFramework.Controls.MetroButton();
            this.metroButtonZoomOut = new MetroFramework.Controls.MetroButton();
            this.metroToggleHide = new MetroFramework.Controls.MetroToggle();
            this.metroPanelDirectoryTools = new MetroFramework.Controls.MetroPanel();
            this.metroButtonRefreshList = new MetroFramework.Controls.MetroButton();
            this.metroButtonAddFile = new MetroFramework.Controls.MetroButton();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.metroTabContainer = new MetroFramework.Controls.MetroTabControl();
            this.metroTabDirectory = new MetroFramework.Controls.MetroTabPage();
            this.metroTabChapter = new MetroFramework.Controls.MetroTabPage();
            this.metroPanelChapterTools = new MetroFramework.Controls.MetroPanel();
            this.metroButtonChapterFavourite = new MetroFramework.Controls.MetroButton();
            this.metroButtonChapterBookmark = new MetroFramework.Controls.MetroButton();
            this.treeView_Chapters = new System.Windows.Forms.TreeView();
            this.metroPanelCenter = new MetroFramework.Controls.MetroPanel();
            this.splitContainerCenter = new System.Windows.Forms.SplitContainer();
            this.splitter = new System.Windows.Forms.Splitter();
            this.pictureBoxLoadingEpub = new System.Windows.Forms.PictureBox();
            this.metroLblUsername = new MetroFramework.Controls.MetroLabel();
            this.pictureBoxTitle = new System.Windows.Forms.PictureBox();
            this.metroLinkLogout = new MetroFramework.Controls.MetroLink();
            this.metroPanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubFavourite)).BeginInit();
            this.metroPanelFooter.SuspendLayout();
            this.metroPanelDirectoryTools.SuspendLayout();
            this.metroTabContainer.SuspendLayout();
            this.metroTabDirectory.SuspendLayout();
            this.metroTabChapter.SuspendLayout();
            this.metroPanelChapterTools.SuspendLayout();
            this.metroPanelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).BeginInit();
            this.splitContainerCenter.Panel1.SuspendLayout();
            this.splitContainerCenter.Panel2.SuspendLayout();
            this.splitContainerCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingEpub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // treeViewDirectory
            // 
            this.treeViewDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDirectory.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.treeViewDirectory.HideSelection = false;
            this.treeViewDirectory.ImageIndex = 0;
            this.treeViewDirectory.ImageList = this.imageListDirectory;
            this.treeViewDirectory.Location = new System.Drawing.Point(0, 42);
            this.treeViewDirectory.Name = "treeViewDirectory";
            this.treeViewDirectory.SelectedImageIndex = 0;
            this.treeViewDirectory.ShowNodeToolTips = true;
            this.treeViewDirectory.ShowRootLines = false;
            this.treeViewDirectory.Size = new System.Drawing.Size(222, 342);
            this.treeViewDirectory.TabIndex = 0;
            this.treeViewDirectory.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDirectory_NodeMouseDoubleClick);
            // 
            // imageListDirectory
            // 
            this.imageListDirectory.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDirectory.ImageStream")));
            this.imageListDirectory.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDirectory.Images.SetKeyName(0, "Folder.png");
            this.imageListDirectory.Images.SetKeyName(1, "BookOpen.png");
            this.imageListDirectory.Images.SetKeyName(2, "Book.png");
            this.imageListDirectory.Images.SetKeyName(3, "epubLogoTransp.png");
            // 
            // metroPanelMenu
            // 
            this.metroPanelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelMenu.Controls.Add(this.pictureBoxEpubInfo);
            this.metroPanelMenu.Controls.Add(this.metroButtonSettings);
            this.metroPanelMenu.Controls.Add(this.pictureBoxEpubBookmark);
            this.metroPanelMenu.Controls.Add(this.pictureBoxEpubFavourite);
            this.metroPanelMenu.Controls.Add(this.metroLabelEPubTitle);
            this.metroPanelMenu.Controls.Add(this.metroButtonStatistics);
            this.metroPanelMenu.HorizontalScrollbarBarColor = true;
            this.metroPanelMenu.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelMenu.HorizontalScrollbarSize = 10;
            this.metroPanelMenu.Location = new System.Drawing.Point(20, 63);
            this.metroPanelMenu.Name = "metroPanelMenu";
            this.metroPanelMenu.Size = new System.Drawing.Size(860, 66);
            this.metroPanelMenu.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroPanelMenu.TabIndex = 2;
            this.metroPanelMenu.VerticalScrollbarBarColor = true;
            this.metroPanelMenu.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelMenu.VerticalScrollbarSize = 10;
            // 
            // pictureBoxEpubInfo
            // 
            this.pictureBoxEpubInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEpubInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxEpubInfo.Image = global::ePubIntegrator.Properties.Resources.appbar_book_open_information;
            this.pictureBoxEpubInfo.Location = new System.Drawing.Point(725, 12);
            this.pictureBoxEpubInfo.Name = "pictureBoxEpubInfo";
            this.pictureBoxEpubInfo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxEpubInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxEpubInfo.TabIndex = 26;
            this.pictureBoxEpubInfo.TabStop = false;
            this.pictureBoxEpubInfo.Click += new System.EventHandler(this.pictureBoxEpubInfo_Click);
            // 
            // metroButtonSettings
            // 
            this.metroButtonSettings.BackgroundImage = global::ePubIntegrator.Properties.Resources.appbar_settings;
            this.metroButtonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonSettings.Location = new System.Drawing.Point(0, 12);
            this.metroButtonSettings.Name = "metroButtonSettings";
            this.metroButtonSettings.Size = new System.Drawing.Size(40, 40);
            this.metroButtonSettings.TabIndex = 8;
            this.metroButtonSettings.UseSelectable = true;
            this.metroButtonSettings.Click += new System.EventHandler(this.metroButtonSettings_Click);
            // 
            // pictureBoxEpubBookmark
            // 
            this.pictureBoxEpubBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEpubBookmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxEpubBookmark.Image = global::ePubIntegrator.Properties.Resources.bookmarkDesactivated_png;
            this.pictureBoxEpubBookmark.Location = new System.Drawing.Point(771, 12);
            this.pictureBoxEpubBookmark.Name = "pictureBoxEpubBookmark";
            this.pictureBoxEpubBookmark.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxEpubBookmark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEpubBookmark.TabIndex = 24;
            this.pictureBoxEpubBookmark.TabStop = false;
            this.pictureBoxEpubBookmark.Click += new System.EventHandler(this.pictureBoxEpubBookmark_Click);
            // 
            // pictureBoxEpubFavourite
            // 
            this.pictureBoxEpubFavourite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEpubFavourite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxEpubFavourite.Image = global::ePubIntegrator.Properties.Resources.Unfavourite;
            this.pictureBoxEpubFavourite.Location = new System.Drawing.Point(817, 12);
            this.pictureBoxEpubFavourite.Name = "pictureBoxEpubFavourite";
            this.pictureBoxEpubFavourite.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxEpubFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEpubFavourite.TabIndex = 23;
            this.pictureBoxEpubFavourite.TabStop = false;
            this.pictureBoxEpubFavourite.Click += new System.EventHandler(this.pictureBoxEpubFavourite_Click);
            // 
            // metroLabelEPubTitle
            // 
            this.metroLabelEPubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabelEPubTitle.AutoSize = true;
            this.metroLabelEPubTitle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabelEPubTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabelEPubTitle.Location = new System.Drawing.Point(249, 33);
            this.metroLabelEPubTitle.Name = "metroLabelEPubTitle";
            this.metroLabelEPubTitle.Size = new System.Drawing.Size(0, 0);
            this.metroLabelEPubTitle.TabIndex = 22;
            // 
            // metroButtonStatistics
            // 
            this.metroButtonStatistics.BackgroundImage = global::ePubIntegrator.Properties.Resources.appbar_graph_line;
            this.metroButtonStatistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonStatistics.Location = new System.Drawing.Point(47, 12);
            this.metroButtonStatistics.Name = "metroButtonStatistics";
            this.metroButtonStatistics.Size = new System.Drawing.Size(40, 40);
            this.metroButtonStatistics.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonStatistics.TabIndex = 3;
            this.metroButtonStatistics.UseSelectable = true;
            this.metroButtonStatistics.Click += new System.EventHandler(this.metroButtonStatistics_Click);
            // 
            // metroTrackBarZoom
            // 
            this.metroTrackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTrackBarZoom.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBarZoom.LargeChange = 10;
            this.metroTrackBarZoom.Location = new System.Drawing.Point(687, 15);
            this.metroTrackBarZoom.Maximum = 200;
            this.metroTrackBarZoom.Minimum = 50;
            this.metroTrackBarZoom.Name = "metroTrackBarZoom";
            this.metroTrackBarZoom.Size = new System.Drawing.Size(132, 17);
            this.metroTrackBarZoom.SmallChange = 10;
            this.metroTrackBarZoom.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTrackBarZoom.TabIndex = 19;
            this.metroTrackBarZoom.Text = "metroTrackBar";
            this.metroTrackBarZoom.Value = 100;
            this.metroTrackBarZoom.ValueChanged += new System.EventHandler(this.metroTrackBarZoom_ValueChanged);
            this.metroTrackBarZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBarZoom_Scroll);
            // 
            // metroPanelFooter
            // 
            this.metroPanelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelFooter.Controls.Add(this.metroLabelHideControl);
            this.metroPanelFooter.Controls.Add(this.metroButtonZoomIn);
            this.metroPanelFooter.Controls.Add(this.metroButtonZoomOut);
            this.metroPanelFooter.Controls.Add(this.metroToggleHide);
            this.metroPanelFooter.Controls.Add(this.metroTrackBarZoom);
            this.metroPanelFooter.HorizontalScrollbarBarColor = true;
            this.metroPanelFooter.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelFooter.HorizontalScrollbarSize = 10;
            this.metroPanelFooter.Location = new System.Drawing.Point(20, 577);
            this.metroPanelFooter.Name = "metroPanelFooter";
            this.metroPanelFooter.Size = new System.Drawing.Size(860, 49);
            this.metroPanelFooter.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroPanelFooter.TabIndex = 3;
            this.metroPanelFooter.VerticalScrollbarBarColor = true;
            this.metroPanelFooter.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelFooter.VerticalScrollbarSize = 10;
            // 
            // metroLabelHideControl
            // 
            this.metroLabelHideControl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroLabelHideControl.AutoSize = true;
            this.metroLabelHideControl.Location = new System.Drawing.Point(3, 3);
            this.metroLabelHideControl.Name = "metroLabelHideControl";
            this.metroLabelHideControl.Size = new System.Drawing.Size(89, 19);
            this.metroLabelHideControl.TabIndex = 8;
            this.metroLabelHideControl.Text = "Hide Controls";
            // 
            // metroButtonZoomIn
            // 
            this.metroButtonZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.metroButtonZoomIn.BackgroundImage = global::ePubIntegrator.Properties.Resources.Add;
            this.metroButtonZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonZoomIn.Location = new System.Drawing.Point(825, 15);
            this.metroButtonZoomIn.Name = "metroButtonZoomIn";
            this.metroButtonZoomIn.Size = new System.Drawing.Size(17, 17);
            this.metroButtonZoomIn.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonZoomIn.TabIndex = 21;
            this.metroButtonZoomIn.UseSelectable = true;
            this.metroButtonZoomIn.Click += new System.EventHandler(this.metroButtonZoomIn_Click);
            // 
            // metroButtonZoomOut
            // 
            this.metroButtonZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonZoomOut.BackgroundImage = global::ePubIntegrator.Properties.Resources.appbar_minus;
            this.metroButtonZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonZoomOut.Location = new System.Drawing.Point(664, 15);
            this.metroButtonZoomOut.Name = "metroButtonZoomOut";
            this.metroButtonZoomOut.Size = new System.Drawing.Size(17, 17);
            this.metroButtonZoomOut.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonZoomOut.TabIndex = 20;
            this.metroButtonZoomOut.Text = "-";
            this.metroButtonZoomOut.UseSelectable = true;
            this.metroButtonZoomOut.Click += new System.EventHandler(this.metroButtonZoomOut_Click);
            // 
            // metroToggleHide
            // 
            this.metroToggleHide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.metroToggleHide.AutoSize = true;
            this.metroToggleHide.Location = new System.Drawing.Point(7, 25);
            this.metroToggleHide.Name = "metroToggleHide";
            this.metroToggleHide.Size = new System.Drawing.Size(80, 17);
            this.metroToggleHide.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroToggleHide.TabIndex = 7;
            this.metroToggleHide.Text = "Off";
            this.metroToggleHide.UseSelectable = true;
            this.metroToggleHide.CheckedChanged += new System.EventHandler(this.metroToggleHide_CheckedChanged);
            // 
            // metroPanelDirectoryTools
            // 
            this.metroPanelDirectoryTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelDirectoryTools.Controls.Add(this.metroButtonRefreshList);
            this.metroPanelDirectoryTools.Controls.Add(this.metroButtonAddFile);
            this.metroPanelDirectoryTools.HorizontalScrollbarBarColor = true;
            this.metroPanelDirectoryTools.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelDirectoryTools.HorizontalScrollbarSize = 10;
            this.metroPanelDirectoryTools.Location = new System.Drawing.Point(3, 3);
            this.metroPanelDirectoryTools.Name = "metroPanelDirectoryTools";
            this.metroPanelDirectoryTools.Size = new System.Drawing.Size(222, 33);
            this.metroPanelDirectoryTools.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroPanelDirectoryTools.TabIndex = 4;
            this.metroPanelDirectoryTools.VerticalScrollbarBarColor = true;
            this.metroPanelDirectoryTools.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelDirectoryTools.VerticalScrollbarSize = 10;
            // 
            // metroButtonRefreshList
            // 
            this.metroButtonRefreshList.BackgroundImage = global::ePubIntegrator.Properties.Resources.Refresh;
            this.metroButtonRefreshList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonRefreshList.Location = new System.Drawing.Point(36, 3);
            this.metroButtonRefreshList.Name = "metroButtonRefreshList";
            this.metroButtonRefreshList.Size = new System.Drawing.Size(27, 27);
            this.metroButtonRefreshList.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonRefreshList.TabIndex = 7;
            this.metroButtonRefreshList.UseSelectable = true;
            this.metroButtonRefreshList.Click += new System.EventHandler(this.metroButtonRefreshList_Click);
            // 
            // metroButtonAddFile
            // 
            this.metroButtonAddFile.BackgroundImage = global::ePubIntegrator.Properties.Resources.Add;
            this.metroButtonAddFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonAddFile.Location = new System.Drawing.Point(3, 3);
            this.metroButtonAddFile.Name = "metroButtonAddFile";
            this.metroButtonAddFile.Size = new System.Drawing.Size(27, 27);
            this.metroButtonAddFile.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButtonAddFile.TabIndex = 6;
            this.metroButtonAddFile.UseSelectable = true;
            this.metroButtonAddFile.Click += new System.EventHandler(this.metroButtonAddFile_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser.Location = new System.Drawing.Point(6, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(607, 429);
            this.webBrowser.TabIndex = 5;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
            this.webBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.webBrowser_PreviewKeyDown);
            // 
            // metroTabContainer
            // 
            this.metroTabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabContainer.Controls.Add(this.metroTabDirectory);
            this.metroTabContainer.Controls.Add(this.metroTabChapter);
            this.metroTabContainer.Location = new System.Drawing.Point(3, 3);
            this.metroTabContainer.Name = "metroTabContainer";
            this.metroTabContainer.SelectedIndex = 1;
            this.metroTabContainer.Size = new System.Drawing.Size(233, 429);
            this.metroTabContainer.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabContainer.TabIndex = 7;
            this.metroTabContainer.UseSelectable = true;
            // 
            // metroTabDirectory
            // 
            this.metroTabDirectory.Controls.Add(this.treeViewDirectory);
            this.metroTabDirectory.Controls.Add(this.metroPanelDirectoryTools);
            this.metroTabDirectory.HorizontalScrollbarBarColor = true;
            this.metroTabDirectory.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabDirectory.HorizontalScrollbarSize = 10;
            this.metroTabDirectory.Location = new System.Drawing.Point(4, 38);
            this.metroTabDirectory.Name = "metroTabDirectory";
            this.metroTabDirectory.Size = new System.Drawing.Size(225, 387);
            this.metroTabDirectory.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabDirectory.TabIndex = 0;
            this.metroTabDirectory.Tag = "";
            this.metroTabDirectory.Text = "Directory";
            this.metroTabDirectory.VerticalScrollbarBarColor = true;
            this.metroTabDirectory.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabDirectory.VerticalScrollbarSize = 10;
            // 
            // metroTabChapter
            // 
            this.metroTabChapter.Controls.Add(this.metroPanelChapterTools);
            this.metroTabChapter.Controls.Add(this.treeView_Chapters);
            this.metroTabChapter.HorizontalScrollbarBarColor = true;
            this.metroTabChapter.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabChapter.HorizontalScrollbarSize = 10;
            this.metroTabChapter.Location = new System.Drawing.Point(4, 38);
            this.metroTabChapter.Name = "metroTabChapter";
            this.metroTabChapter.Size = new System.Drawing.Size(225, 387);
            this.metroTabChapter.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabChapter.TabIndex = 1;
            this.metroTabChapter.Text = "Chapters";
            this.metroTabChapter.VerticalScrollbarBarColor = true;
            this.metroTabChapter.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabChapter.VerticalScrollbarSize = 10;
            // 
            // metroPanelChapterTools
            // 
            this.metroPanelChapterTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelChapterTools.Controls.Add(this.metroButtonChapterFavourite);
            this.metroPanelChapterTools.Controls.Add(this.metroButtonChapterBookmark);
            this.metroPanelChapterTools.HorizontalScrollbarBarColor = true;
            this.metroPanelChapterTools.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelChapterTools.HorizontalScrollbarSize = 10;
            this.metroPanelChapterTools.Location = new System.Drawing.Point(3, 4);
            this.metroPanelChapterTools.Name = "metroPanelChapterTools";
            this.metroPanelChapterTools.Size = new System.Drawing.Size(219, 33);
            this.metroPanelChapterTools.TabIndex = 3;
            this.metroPanelChapterTools.VerticalScrollbarBarColor = true;
            this.metroPanelChapterTools.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelChapterTools.VerticalScrollbarSize = 10;
            // 
            // metroButtonChapterFavourite
            // 
            this.metroButtonChapterFavourite.BackgroundImage = global::ePubIntegrator.Properties.Resources.Unfavourite;
            this.metroButtonChapterFavourite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonChapterFavourite.Location = new System.Drawing.Point(36, 3);
            this.metroButtonChapterFavourite.Name = "metroButtonChapterFavourite";
            this.metroButtonChapterFavourite.Size = new System.Drawing.Size(27, 27);
            this.metroButtonChapterFavourite.TabIndex = 3;
            this.metroButtonChapterFavourite.UseSelectable = true;
            this.metroButtonChapterFavourite.Click += new System.EventHandler(this.metroButtonChapterFavourite_Click);
            // 
            // metroButtonChapterBookmark
            // 
            this.metroButtonChapterBookmark.BackgroundImage = global::ePubIntegrator.Properties.Resources.ChapterBookmarkDesactivated;
            this.metroButtonChapterBookmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonChapterBookmark.Location = new System.Drawing.Point(3, 3);
            this.metroButtonChapterBookmark.Name = "metroButtonChapterBookmark";
            this.metroButtonChapterBookmark.Size = new System.Drawing.Size(27, 27);
            this.metroButtonChapterBookmark.TabIndex = 2;
            this.metroButtonChapterBookmark.UseSelectable = true;
            this.metroButtonChapterBookmark.Click += new System.EventHandler(this.metroButtonChapterBookmark_Click);
            // 
            // treeView_Chapters
            // 
            this.treeView_Chapters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_Chapters.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.treeView_Chapters.HideSelection = false;
            this.treeView_Chapters.HotTracking = true;
            this.treeView_Chapters.Location = new System.Drawing.Point(0, 42);
            this.treeView_Chapters.Margin = new System.Windows.Forms.Padding(2);
            this.treeView_Chapters.Name = "treeView_Chapters";
            this.treeView_Chapters.Size = new System.Drawing.Size(223, 334);
            this.treeView_Chapters.TabIndex = 2;
            this.treeView_Chapters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView_Chapters.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Chapters_NodeMouseClick);
            // 
            // metroPanelCenter
            // 
            this.metroPanelCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanelCenter.Controls.Add(this.splitContainerCenter);
            this.metroPanelCenter.HorizontalScrollbarBarColor = true;
            this.metroPanelCenter.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanelCenter.HorizontalScrollbarSize = 10;
            this.metroPanelCenter.Location = new System.Drawing.Point(20, 135);
            this.metroPanelCenter.Name = "metroPanelCenter";
            this.metroPanelCenter.Size = new System.Drawing.Size(860, 436);
            this.metroPanelCenter.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroPanelCenter.TabIndex = 8;
            this.metroPanelCenter.VerticalScrollbarBarColor = true;
            this.metroPanelCenter.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanelCenter.VerticalScrollbarSize = 10;
            // 
            // splitContainerCenter
            // 
            this.splitContainerCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerCenter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerCenter.IsSplitterFixed = true;
            this.splitContainerCenter.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCenter.Name = "splitContainerCenter";
            // 
            // splitContainerCenter.Panel1
            // 
            this.splitContainerCenter.Panel1.Controls.Add(this.metroTabContainer);
            this.splitContainerCenter.Panel1.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainerCenter.Panel1MinSize = 200;
            // 
            // splitContainerCenter.Panel2
            // 
            this.splitContainerCenter.Panel2.Controls.Add(this.splitter);
            this.splitContainerCenter.Panel2.Controls.Add(this.pictureBoxLoadingEpub);
            this.splitContainerCenter.Panel2.Controls.Add(this.webBrowser);
            this.splitContainerCenter.Panel2.Margin = new System.Windows.Forms.Padding(3);
            this.splitContainerCenter.Panel2MinSize = 600;
            this.splitContainerCenter.Size = new System.Drawing.Size(860, 436);
            this.splitContainerCenter.SplitterDistance = 239;
            this.splitContainerCenter.TabIndex = 6;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.splitter.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Margin = new System.Windows.Forms.Padding(0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 436);
            this.splitter.TabIndex = 7;
            this.splitter.TabStop = false;
            // 
            // pictureBoxLoadingEpub
            // 
            this.pictureBoxLoadingEpub.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLoadingEpub.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLoadingEpub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLoadingEpub.Image = global::ePubIntegrator.Properties.Resources.Loading;
            this.pictureBoxLoadingEpub.Location = new System.Drawing.Point(284, 128);
            this.pictureBoxLoadingEpub.Name = "pictureBoxLoadingEpub";
            this.pictureBoxLoadingEpub.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxLoadingEpub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxLoadingEpub.TabIndex = 6;
            this.pictureBoxLoadingEpub.TabStop = false;
            this.pictureBoxLoadingEpub.Visible = false;
            // 
            // metroLblUsername
            // 
            this.metroLblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLblUsername.Location = new System.Drawing.Point(548, 31);
            this.metroLblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLblUsername.Name = "metroLblUsername";
            this.metroLblUsername.Size = new System.Drawing.Size(263, 23);
            this.metroLblUsername.TabIndex = 10;
            this.metroLblUsername.Text = "Username";
            this.metroLblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pictureBoxTitle
            // 
            this.pictureBoxTitle.Image = global::ePubIntegrator.Properties.Resources.epubReaderTitle;
            this.pictureBoxTitle.Location = new System.Drawing.Point(20, 21);
            this.pictureBoxTitle.Name = "pictureBoxTitle";
            this.pictureBoxTitle.Size = new System.Drawing.Size(300, 33);
            this.pictureBoxTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTitle.TabIndex = 9;
            this.pictureBoxTitle.TabStop = false;
            // 
            // metroLinkLogout
            // 
            this.metroLinkLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLinkLogout.Location = new System.Drawing.Point(816, 31);
            this.metroLinkLogout.Name = "metroLinkLogout";
            this.metroLinkLogout.Size = new System.Drawing.Size(61, 23);
            this.metroLinkLogout.TabIndex = 11;
            this.metroLinkLogout.Text = "(Logout)";
            this.metroLinkLogout.UseSelectable = true;
            this.metroLinkLogout.Click += new System.EventHandler(this.metroLinkLogout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 627);
            this.Controls.Add(this.metroLinkLogout);
            this.Controls.Add(this.metroLblUsername);
            this.Controls.Add(this.pictureBoxTitle);
            this.Controls.Add(this.metroPanelMenu);
            this.Controls.Add(this.metroPanelCenter);
            this.Controls.Add(this.metroPanelFooter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 598);
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "ePub Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_Closing);
            this.metroPanelMenu.ResumeLayout(false);
            this.metroPanelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpubFavourite)).EndInit();
            this.metroPanelFooter.ResumeLayout(false);
            this.metroPanelFooter.PerformLayout();
            this.metroPanelDirectoryTools.ResumeLayout(false);
            this.metroTabContainer.ResumeLayout(false);
            this.metroTabDirectory.ResumeLayout(false);
            this.metroTabChapter.ResumeLayout(false);
            this.metroPanelChapterTools.ResumeLayout(false);
            this.metroPanelCenter.ResumeLayout(false);
            this.splitContainerCenter.Panel1.ResumeLayout(false);
            this.splitContainerCenter.Panel2.ResumeLayout(false);
            this.splitContainerCenter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCenter)).EndInit();
            this.splitContainerCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingEpub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewDirectory;
        private MetroFramework.Controls.MetroPanel metroPanelMenu;
        private MetroFramework.Controls.MetroPanel metroPanelFooter;
        private MetroFramework.Controls.MetroButton metroButtonStatistics;
        private MetroFramework.Controls.MetroPanel metroPanelDirectoryTools;
        private MetroFramework.Controls.MetroButton metroButtonRefreshList;
        private MetroFramework.Controls.MetroButton metroButtonAddFile;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.PictureBox pictureBoxLoadingEpub;
        private MetroFramework.Controls.MetroTabControl metroTabContainer;
        private MetroFramework.Controls.MetroTabPage metroTabDirectory;
        private MetroFramework.Controls.MetroTabPage metroTabChapter;
        private ImageList imageListDirectory;
        private MetroFramework.Controls.MetroPanel metroPanelCenter;
        private SplitContainer splitContainerCenter;
        private Splitter splitter;
        private MetroFramework.Controls.MetroToggle metroToggleHide;
        private MetroFramework.Controls.MetroLabel metroLabelHideControl;
        private PictureBox pictureBoxTitle;
        private MetroFramework.Controls.MetroButton metroButtonZoomIn;
        private MetroFramework.Controls.MetroButton metroButtonZoomOut;
        private MetroFramework.Controls.MetroTrackBar metroTrackBarZoom;
        private TreeView treeView_Chapters;
        private MetroFramework.Controls.MetroLabel metroLabelEPubTitle;
        private PictureBox pictureBoxEpubFavourite;
        private PictureBox pictureBoxEpubBookmark;
        private MetroFramework.Controls.MetroPanel metroPanelChapterTools;
        private MetroFramework.Controls.MetroButton metroButtonSettings;
        private MetroFramework.Controls.MetroButton metroButtonChapterFavourite;
        private MetroFramework.Controls.MetroButton metroButtonChapterBookmark;
        private MetroFramework.Controls.MetroLabel metroLblUsername;
        private PictureBox pictureBoxEpubInfo;
        private MetroFramework.Controls.MetroLink metroLinkLogout;

    }
}