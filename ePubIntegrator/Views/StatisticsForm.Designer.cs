namespace ePubIntegrator.Views {
    partial class StatisticsForm {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.metroButtonExportExcel = new MetroFramework.Controls.MetroButton();
            this.metroTabPageGlobalStat = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabelGlobalYear = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalMonth = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalDay = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.chartGlobalMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroTabPageUserStat = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.chartUserMonth = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabelUserYear = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserMonth = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserDay = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalTop5EpubFav1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalTop5EpubFav2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalTop5EpubFav3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalTop5EpubFav4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelGlobalTop5EpubFav5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserTop5EpubFav5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserTop5EpubFav4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserTop5EpubFav3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserTop5EpubFav2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelUserTop5EpubFav1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPageGlobalStat.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGlobalMonth)).BeginInit();
            this.metroTabPageUserStat.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUserMonth)).BeginInit();
            this.metroPanel3.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButtonExportExcel
            // 
            this.metroButtonExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButtonExportExcel.BackgroundImage = global::ePubIntegrator.Properties.Resources.appbar_page_excel;
            this.metroButtonExportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButtonExportExcel.Location = new System.Drawing.Point(595, 24);
            this.metroButtonExportExcel.Name = "metroButtonExportExcel";
            this.metroButtonExportExcel.Size = new System.Drawing.Size(30, 30);
            this.metroButtonExportExcel.TabIndex = 1;
            this.metroButtonExportExcel.UseSelectable = true;
            this.metroButtonExportExcel.Click += new System.EventHandler(this.metroButtonExportExcel_Click);
            // 
            // metroTabPageGlobalStat
            // 
            this.metroTabPageGlobalStat.Controls.Add(this.metroPanel2);
            this.metroTabPageGlobalStat.Controls.Add(this.metroPanel1);
            this.metroTabPageGlobalStat.HorizontalScrollbarBarColor = true;
            this.metroTabPageGlobalStat.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageGlobalStat.HorizontalScrollbarSize = 10;
            this.metroTabPageGlobalStat.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageGlobalStat.Name = "metroTabPageGlobalStat";
            this.metroTabPageGlobalStat.Size = new System.Drawing.Size(601, 289);
            this.metroTabPageGlobalStat.TabIndex = 1;
            this.metroTabPageGlobalStat.Text = "Global Statistics";
            this.metroTabPageGlobalStat.VerticalScrollbarBarColor = true;
            this.metroTabPageGlobalStat.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageGlobalStat.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel2.Controls.Add(this.metroLabelGlobalTop5EpubFav5);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalTop5EpubFav4);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalTop5EpubFav3);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalTop5EpubFav2);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalTop5EpubFav1);
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalYear);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalMonth);
            this.metroPanel2.Controls.Add(this.metroLabelGlobalDay);
            this.metroPanel2.Controls.Add(this.metroLabel3);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(200, 283);
            this.metroPanel2.TabIndex = 3;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabelGlobalYear
            // 
            this.metroLabelGlobalYear.AutoSize = true;
            this.metroLabelGlobalYear.Location = new System.Drawing.Point(119, 73);
            this.metroLabelGlobalYear.Name = "metroLabelGlobalYear";
            this.metroLabelGlobalYear.Size = new System.Drawing.Size(35, 19);
            this.metroLabelGlobalYear.TabIndex = 7;
            this.metroLabelGlobalYear.Text = "2010";
            // 
            // metroLabelGlobalMonth
            // 
            this.metroLabelGlobalMonth.AutoSize = true;
            this.metroLabelGlobalMonth.Location = new System.Drawing.Point(131, 42);
            this.metroLabelGlobalMonth.Name = "metroLabelGlobalMonth";
            this.metroLabelGlobalMonth.Size = new System.Drawing.Size(34, 19);
            this.metroLabelGlobalMonth.TabIndex = 6;
            this.metroLabelGlobalMonth.Text = "May";
            // 
            // metroLabelGlobalDay
            // 
            this.metroLabelGlobalDay.AutoSize = true;
            this.metroLabelGlobalDay.Location = new System.Drawing.Point(113, 9);
            this.metroLabelGlobalDay.Name = "metroLabelGlobalDay";
            this.metroLabelGlobalDay.Size = new System.Drawing.Size(71, 19);
            this.metroLabelGlobalDay.TabIndex = 5;
            this.metroLabelGlobalDay.Text = "10/10/2000";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 73);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Most Active Year:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 42);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Most Active Month:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(106, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Most Active Day:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.Controls.Add(this.chartGlobalMonth);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(206, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(395, 289);
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // chartGlobalMonth
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGlobalMonth.ChartAreas.Add(chartArea1);
            this.chartGlobalMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGlobalMonth.Location = new System.Drawing.Point(0, 0);
            this.chartGlobalMonth.Name = "chartGlobalMonth";
            series1.ChartArea = "ChartArea1";
            series1.Name = "DailyUsage";
            this.chartGlobalMonth.Series.Add(series1);
            this.chartGlobalMonth.Size = new System.Drawing.Size(395, 289);
            this.chartGlobalMonth.TabIndex = 2;
            this.chartGlobalMonth.Text = "chart1";
            // 
            // metroTabPageUserStat
            // 
            this.metroTabPageUserStat.Controls.Add(this.metroPanel4);
            this.metroTabPageUserStat.Controls.Add(this.metroPanel3);
            this.metroTabPageUserStat.HorizontalScrollbarBarColor = true;
            this.metroTabPageUserStat.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPageUserStat.HorizontalScrollbarSize = 10;
            this.metroTabPageUserStat.Location = new System.Drawing.Point(4, 38);
            this.metroTabPageUserStat.Name = "metroTabPageUserStat";
            this.metroTabPageUserStat.Size = new System.Drawing.Size(601, 289);
            this.metroTabPageUserStat.TabIndex = 0;
            this.metroTabPageUserStat.Text = "User Statistics";
            this.metroTabPageUserStat.VerticalScrollbarBarColor = true;
            this.metroTabPageUserStat.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPageUserStat.VerticalScrollbarSize = 10;
            // 
            // metroPanel4
            // 
            this.metroPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel4.Controls.Add(this.chartUserMonth);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(206, 3);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(392, 286);
            this.metroPanel4.TabIndex = 3;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // chartUserMonth
            // 
            chartArea2.Name = "ChartArea1";
            this.chartUserMonth.ChartAreas.Add(chartArea2);
            this.chartUserMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartUserMonth.Location = new System.Drawing.Point(0, 0);
            this.chartUserMonth.Name = "chartUserMonth";
            series2.ChartArea = "ChartArea1";
            series2.Name = "DailyUsage";
            this.chartUserMonth.Series.Add(series2);
            this.chartUserMonth.Size = new System.Drawing.Size(392, 286);
            this.chartUserMonth.TabIndex = 2;
            this.chartUserMonth.Text = "chart1";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel3.Controls.Add(this.metroLabelUserTop5EpubFav5);
            this.metroPanel3.Controls.Add(this.metroLabelUserTop5EpubFav4);
            this.metroPanel3.Controls.Add(this.metroLabelUserTop5EpubFav3);
            this.metroPanel3.Controls.Add(this.metroLabelUserTop5EpubFav2);
            this.metroPanel3.Controls.Add(this.metroLabelUserTop5EpubFav1);
            this.metroPanel3.Controls.Add(this.metroLabel5);
            this.metroPanel3.Controls.Add(this.metroLabelUserYear);
            this.metroPanel3.Controls.Add(this.metroLabelUserMonth);
            this.metroPanel3.Controls.Add(this.metroLabelUserDay);
            this.metroPanel3.Controls.Add(this.metroLabel7);
            this.metroPanel3.Controls.Add(this.metroLabel8);
            this.metroPanel3.Controls.Add(this.metroLabel9);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 3);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(200, 283);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabelUserYear
            // 
            this.metroLabelUserYear.AutoSize = true;
            this.metroLabelUserYear.Location = new System.Drawing.Point(119, 73);
            this.metroLabelUserYear.Name = "metroLabelUserYear";
            this.metroLabelUserYear.Size = new System.Drawing.Size(35, 19);
            this.metroLabelUserYear.TabIndex = 13;
            this.metroLabelUserYear.Text = "2010";
            // 
            // metroLabelUserMonth
            // 
            this.metroLabelUserMonth.AutoSize = true;
            this.metroLabelUserMonth.Location = new System.Drawing.Point(131, 42);
            this.metroLabelUserMonth.Name = "metroLabelUserMonth";
            this.metroLabelUserMonth.Size = new System.Drawing.Size(34, 19);
            this.metroLabelUserMonth.TabIndex = 12;
            this.metroLabelUserMonth.Text = "May";
            // 
            // metroLabelUserDay
            // 
            this.metroLabelUserDay.AutoSize = true;
            this.metroLabelUserDay.Location = new System.Drawing.Point(113, 9);
            this.metroLabelUserDay.Name = "metroLabelUserDay";
            this.metroLabelUserDay.Size = new System.Drawing.Size(71, 19);
            this.metroLabelUserDay.TabIndex = 11;
            this.metroLabelUserDay.Text = "10/10/2000";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 73);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(110, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Most Active Year:";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 42);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(122, 19);
            this.metroLabel8.TabIndex = 9;
            this.metroLabel8.Text = "Most Active Month:";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(3, 9);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(106, 19);
            this.metroLabel9.TabIndex = 8;
            this.metroLabel9.Text = "Most Active Day:";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPageUserStat);
            this.metroTabControl1.Controls.Add(this.metroTabPageGlobalStat);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(609, 331);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 109);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(145, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Top 5 Epubs Favourites:";
            // 
            // metroLabelGlobalTop5EpubFav1
            // 
            this.metroLabelGlobalTop5EpubFav1.AutoSize = true;
            this.metroLabelGlobalTop5EpubFav1.Location = new System.Drawing.Point(3, 128);
            this.metroLabelGlobalTop5EpubFav1.Name = "metroLabelGlobalTop5EpubFav1";
            this.metroLabelGlobalTop5EpubFav1.Size = new System.Drawing.Size(57, 19);
            this.metroLabelGlobalTop5EpubFav1.TabIndex = 9;
            this.metroLabelGlobalTop5EpubFav1.Text = "            ";
            // 
            // metroLabelGlobalTop5EpubFav2
            // 
            this.metroLabelGlobalTop5EpubFav2.AutoSize = true;
            this.metroLabelGlobalTop5EpubFav2.Location = new System.Drawing.Point(3, 147);
            this.metroLabelGlobalTop5EpubFav2.Name = "metroLabelGlobalTop5EpubFav2";
            this.metroLabelGlobalTop5EpubFav2.Size = new System.Drawing.Size(33, 19);
            this.metroLabelGlobalTop5EpubFav2.TabIndex = 10;
            this.metroLabelGlobalTop5EpubFav2.Text = "      ";
            // 
            // metroLabelGlobalTop5EpubFav3
            // 
            this.metroLabelGlobalTop5EpubFav3.AutoSize = true;
            this.metroLabelGlobalTop5EpubFav3.Location = new System.Drawing.Point(3, 166);
            this.metroLabelGlobalTop5EpubFav3.Name = "metroLabelGlobalTop5EpubFav3";
            this.metroLabelGlobalTop5EpubFav3.Size = new System.Drawing.Size(13, 19);
            this.metroLabelGlobalTop5EpubFav3.TabIndex = 11;
            this.metroLabelGlobalTop5EpubFav3.Text = " ";
            // 
            // metroLabelGlobalTop5EpubFav4
            // 
            this.metroLabelGlobalTop5EpubFav4.AutoSize = true;
            this.metroLabelGlobalTop5EpubFav4.Location = new System.Drawing.Point(5, 185);
            this.metroLabelGlobalTop5EpubFav4.Name = "metroLabelGlobalTop5EpubFav4";
            this.metroLabelGlobalTop5EpubFav4.Size = new System.Drawing.Size(21, 19);
            this.metroLabelGlobalTop5EpubFav4.TabIndex = 12;
            this.metroLabelGlobalTop5EpubFav4.Text = "   ";
            // 
            // metroLabelGlobalTop5EpubFav5
            // 
            this.metroLabelGlobalTop5EpubFav5.AutoSize = true;
            this.metroLabelGlobalTop5EpubFav5.Location = new System.Drawing.Point(5, 204);
            this.metroLabelGlobalTop5EpubFav5.Name = "metroLabelGlobalTop5EpubFav5";
            this.metroLabelGlobalTop5EpubFav5.Size = new System.Drawing.Size(25, 19);
            this.metroLabelGlobalTop5EpubFav5.TabIndex = 13;
            this.metroLabelGlobalTop5EpubFav5.Text = "    ";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(3, 109);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(145, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "Top 5 Epubs Favourites:";
            // 
            // metroLabelUserTop5EpubFav5
            // 
            this.metroLabelUserTop5EpubFav5.AutoSize = true;
            this.metroLabelUserTop5EpubFav5.Location = new System.Drawing.Point(5, 204);
            this.metroLabelUserTop5EpubFav5.Name = "metroLabelUserTop5EpubFav5";
            this.metroLabelUserTop5EpubFav5.Size = new System.Drawing.Size(25, 19);
            this.metroLabelUserTop5EpubFav5.TabIndex = 19;
            this.metroLabelUserTop5EpubFav5.Text = "    ";
            // 
            // metroLabelUserTop5EpubFav4
            // 
            this.metroLabelUserTop5EpubFav4.AutoSize = true;
            this.metroLabelUserTop5EpubFav4.Location = new System.Drawing.Point(5, 185);
            this.metroLabelUserTop5EpubFav4.Name = "metroLabelUserTop5EpubFav4";
            this.metroLabelUserTop5EpubFav4.Size = new System.Drawing.Size(21, 19);
            this.metroLabelUserTop5EpubFav4.TabIndex = 18;
            this.metroLabelUserTop5EpubFav4.Text = "   ";
            // 
            // metroLabelUserTop5EpubFav3
            // 
            this.metroLabelUserTop5EpubFav3.AutoSize = true;
            this.metroLabelUserTop5EpubFav3.Location = new System.Drawing.Point(3, 166);
            this.metroLabelUserTop5EpubFav3.Name = "metroLabelUserTop5EpubFav3";
            this.metroLabelUserTop5EpubFav3.Size = new System.Drawing.Size(13, 19);
            this.metroLabelUserTop5EpubFav3.TabIndex = 17;
            this.metroLabelUserTop5EpubFav3.Text = " ";
            // 
            // metroLabelUserTop5EpubFav2
            // 
            this.metroLabelUserTop5EpubFav2.AutoSize = true;
            this.metroLabelUserTop5EpubFav2.Location = new System.Drawing.Point(3, 147);
            this.metroLabelUserTop5EpubFav2.Name = "metroLabelUserTop5EpubFav2";
            this.metroLabelUserTop5EpubFav2.Size = new System.Drawing.Size(33, 19);
            this.metroLabelUserTop5EpubFav2.TabIndex = 16;
            this.metroLabelUserTop5EpubFav2.Text = "      ";
            // 
            // metroLabelUserTop5EpubFav1
            // 
            this.metroLabelUserTop5EpubFav1.AutoSize = true;
            this.metroLabelUserTop5EpubFav1.Location = new System.Drawing.Point(3, 128);
            this.metroLabelUserTop5EpubFav1.Name = "metroLabelUserTop5EpubFav1";
            this.metroLabelUserTop5EpubFav1.Size = new System.Drawing.Size(57, 19);
            this.metroLabelUserTop5EpubFav1.TabIndex = 15;
            this.metroLabelUserTop5EpubFav1.Text = "            ";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 411);
            this.Controls.Add(this.metroButtonExportExcel);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Statistics";
            this.metroTabPageGlobalStat.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGlobalMonth)).EndInit();
            this.metroTabPageUserStat.ResumeLayout(false);
            this.metroPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartUserMonth)).EndInit();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButtonExportExcel;
        private MetroFramework.Controls.MetroTabPage metroTabPageGlobalStat;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalYear;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalMonth;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalDay;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGlobalMonth;
        private MetroFramework.Controls.MetroTabPage metroTabPageUserStat;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUserMonth;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel metroLabelUserYear;
        private MetroFramework.Controls.MetroLabel metroLabelUserMonth;
        private MetroFramework.Controls.MetroLabel metroLabelUserDay;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalTop5EpubFav5;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalTop5EpubFav4;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalTop5EpubFav3;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalTop5EpubFav2;
        private MetroFramework.Controls.MetroLabel metroLabelGlobalTop5EpubFav1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabelUserTop5EpubFav5;
        private MetroFramework.Controls.MetroLabel metroLabelUserTop5EpubFav4;
        private MetroFramework.Controls.MetroLabel metroLabelUserTop5EpubFav3;
        private MetroFramework.Controls.MetroLabel metroLabelUserTop5EpubFav2;
        private MetroFramework.Controls.MetroLabel metroLabelUserTop5EpubFav1;
    }
}