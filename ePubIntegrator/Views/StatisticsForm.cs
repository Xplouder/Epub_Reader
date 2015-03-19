using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ePubIntegrator.Controllers;
using ePubIntegrator.Models;
using ePubIntegrator.ServiceReference_ePubCloud;
using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ePubIntegrator.Views {
    public partial class StatisticsForm : MetroForm {
        private User user;
        private ServiceePubLibraryClient ws = new ServiceePubLibraryClient();
        private KeyValuePair<string, string> globalMostActiveDay;
        private KeyValuePair<string, string> globalMostActiveMonth;
        private KeyValuePair<string, string> globalMostActiveYear;
        private KeyValuePair<string, string> globalTop1EbooksFav;
        private KeyValuePair<string, string> globalTop2EbooksFav;
        private KeyValuePair<string, string> globalTop3EbooksFav;
        private KeyValuePair<string, string> globalTop4EbooksFav;
        private KeyValuePair<string, string> globalTop5EbooksFav;

        private KeyValuePair<string, string> userMostActiveDay;
        private KeyValuePair<string, string> userMostActiveMonth;
        private KeyValuePair<string, string> userMostActiveYear;
        private KeyValuePair<string, string> userTop1EbooksFav;
        private KeyValuePair<string, string> userTop2EbooksFav;
        private KeyValuePair<string, string> userTop3EbooksFav;
        private KeyValuePair<string, string> userTop4EbooksFav;
        private KeyValuePair<string, string> userTop5EbooksFav;

        public StatisticsForm (User user) {
            InitializeComponent();
            this.user = user;
            loadStatistics();
            ws.Close();
        }

        private void loadStatistics () {
            loadUserStatistics();
            loadGlobalStatistics();
        }

        private void loadUserStatistics () {
            loadUserMostActiveDay();
            loadUserMostActiveMonth();
            loadUserMostActiveYear();
            loadUserMonthChart();
            loadUserTop5EbooksFav();
        }

        private void loadGlobalStatistics () {
            loadGlobalMostActiveDay();
            loadGlobalMostActiveMonth();
            loadGlobalMostActiveYear();
            loadGlobalMonthChart();
            loadGlobalTop5EbooksFav();
        }

        private void loadUserTop5EbooksFav () {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Id.ToString();
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(ws.GetTop5EpubFavByUser(doc.OuterXml));

                if (XMLController.validaXml(xml, "activeAll")) {
                    XmlNodeList months = xml.SelectNodes("/activeAll/month");
                    var date = "";
                    var counter = "";
                    for (int i = 0; i < months.Count; i++) {
                        for (int j = 0; j < months[i].ChildNodes.Count; j++) {
                            if (months[i].ChildNodes[j].Name.Equals("date")) {
                                date = months[i].ChildNodes[j].InnerText;
                                if (i == 0) {
                                    metroLabelUserTop5EpubFav1.Text = @"1) " + date;
                                }
                                if (i == 1) {
                                    metroLabelUserTop5EpubFav2.Text = @"2) " + date;
                                }
                                if (i == 2) {
                                    metroLabelUserTop5EpubFav3.Text = @"3) " + date;
                                }
                                if (i == 3) {
                                    metroLabelUserTop5EpubFav4.Text = @"4) " + date;
                                }
                                if (i == 4) {
                                    metroLabelUserTop5EpubFav5.Text = @"5) " + date;
                                }
                            }
                            if (months[i].ChildNodes[j].Name.Equals("counter")) {
                                counter = months[i].ChildNodes[j].InnerText;
                            }

                        }
                        if (i == 0) {
                            userTop1EbooksFav = new KeyValuePair<string, string>(date, counter);
                        }
                        if (i == 1) {
                            userTop2EbooksFav = new KeyValuePair<string, string>(date, counter);
                        }
                        if (i == 2) {
                            userTop3EbooksFav = new KeyValuePair<string, string>(date, counter);
                        }
                        if (i == 3) {
                            userTop4EbooksFav = new KeyValuePair<string, string>(date, counter);
                        }
                        if (i == 4) {
                            userTop5EbooksFav = new KeyValuePair<string, string>(date, counter);
                        }
                        date = "";
                        counter = "";
                    }
                }
            }
        }

        private void loadGlobalTop5EbooksFav () {

            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetTop5EpubFav());

            if (XMLController.validaXml(xml, "activeAll")) {
                XmlNodeList months = xml.SelectNodes("/activeAll/month");
                var date = "";
                var counter = "";
                for (int i = 0; i < months.Count; i++) {
                    for (int j = 0; j < months[i].ChildNodes.Count; j++) {
                        if (months[i].ChildNodes[j].Name.Equals("date")) {
                            date = months[i].ChildNodes[j].InnerText;
                            if (i == 0) {
                                metroLabelGlobalTop5EpubFav1.Text = @"1) " + date;
                            }
                            if (i == 1) {
                                metroLabelGlobalTop5EpubFav2.Text = @"2) " + date;
                            }
                            if (i == 2) {
                                metroLabelGlobalTop5EpubFav3.Text = @"3) " + date;
                            }
                            if (i == 3) {
                                metroLabelGlobalTop5EpubFav4.Text = @"4) " + date;
                            }
                            if (i == 4) {
                                metroLabelGlobalTop5EpubFav5.Text = @"5) " + date;
                            }
                        }
                        if (months[i].ChildNodes[j].Name.Equals("counter")) {
                            counter = months[i].ChildNodes[j].InnerText;
                        }

                    }
                    if (i == 0) {
                        globalTop1EbooksFav = new KeyValuePair<string, string>(date, counter);
                    }
                    if (i == 1) {
                        globalTop2EbooksFav = new KeyValuePair<string, string>(date, counter);
                    }
                    if (i == 2) {
                        globalTop3EbooksFav = new KeyValuePair<string, string>(date, counter);
                    }
                    if (i == 3) {
                        globalTop4EbooksFav = new KeyValuePair<string, string>(date, counter);
                    }
                    if (i == 4) {
                        globalTop5EbooksFav = new KeyValuePair<string, string>(date, counter);
                    }
                    date = "";
                    counter = "";
                }
            }

        }

        private void loadUserMonthChart () {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Id.ToString();
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(ws.GetAllMonthsByUser(doc.OuterXml));

                if (XMLController.validaXml(xml, "activeAll")) {
                    XmlNodeList months = xml.SelectNodes("/activeAll/month");
                    var date = "";
                    var counter = "";
                    foreach (XmlNode node in months) {
                        foreach (XmlNode childNode in node.ChildNodes) {
                            if (childNode.Name.Equals("date")) {
                                date = childNode.InnerText;
                            }
                            if (childNode.Name.Equals("counter")) {
                                counter = childNode.InnerText;
                            }
                        }
                        chartUserMonth.Series["DailyUsage"].Points.AddXY(parseMonth(date), counter);
                        date = "";
                        counter = "";
                    }
                }
            }
        }

        private void loadUserMostActiveYear () {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Id.ToString();
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(ws.GetMostActiveYearByUser(doc.OuterXml));

                if (XMLController.validaXml(xml, "mostActive")) {
                    XmlNode date = xml.SelectSingleNode("/mostActive/date");
                    metroLabelUserYear.Text = date.InnerText;
                    XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                    userMostActiveYear = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
                }
            }
        }

        private void loadUserMostActiveMonth () {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Id.ToString();
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(ws.GetMostActiveMonthByUser(doc.OuterXml));

                if (XMLController.validaXml(xml, "mostActive")) {
                    XmlNode date = xml.SelectSingleNode("/mostActive/date");
                    metroLabelUserMonth.Text = parseMonth(date.InnerText);
                    XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                    userMostActiveMonth = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
                }
            }
        }

        private void loadUserMostActiveDay () {

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement str = doc.CreateElement("string");
            str.InnerText = user.Id.ToString();
            doc.AppendChild(str);

            if (XMLController.validaXml(doc, "string")) {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(ws.GetMostActiveDayByUser(doc.OuterXml));

                if (XMLController.validaXml(xml, "mostActive")) {
                    XmlNode date = xml.SelectSingleNode("/mostActive/date");
                    metroLabelUserDay.Text = date.InnerText;
                    XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                    userMostActiveDay = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
                }
            }

        }

        private void loadGlobalMonthChart () {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetAllMonths());

            if (XMLController.validaXml(xml, "activeAll")) {
                XmlNodeList months = xml.SelectNodes("/activeAll/month");
                var date = "";
                var counter = "";
                foreach (XmlNode node in months) {
                    foreach (XmlNode childNode in node.ChildNodes) {
                        if (childNode.Name.Equals("date")) {
                            date = childNode.InnerText;
                        }
                        if (childNode.Name.Equals("counter")) {
                            counter = childNode.InnerText;
                        }
                    }
                    chartGlobalMonth.Series["DailyUsage"].Points.AddXY(parseMonth(date), counter);
                    date = "";
                    counter = "";
                }
            }

        }

        private void loadGlobalMostActiveDay () {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetMostActiveDay());

            if (XMLController.validaXml(xml, "mostActive")) {
                XmlNode date = xml.SelectSingleNode("/mostActive/date");
                metroLabelGlobalDay.Text = date.InnerText;
                XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                globalMostActiveDay = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
            }
        }

        private void loadGlobalMostActiveYear () {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetMostActiveYear());

            if (XMLController.validaXml(xml, "mostActive")) {
                XmlNode date = xml.SelectSingleNode("/mostActive/date");
                metroLabelGlobalYear.Text = date.InnerText;
                XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                globalMostActiveYear = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
            }
        }

        private void loadGlobalMostActiveMonth () {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetMostActiveMonth());

            if (XMLController.validaXml(xml, "mostActive")) {
                XmlNode date = xml.SelectSingleNode("/mostActive/date");
                metroLabelGlobalMonth.Text = parseMonth(date.InnerText);
                XmlNode counter = xml.SelectSingleNode("/mostActive/counter");
                globalMostActiveMonth = new KeyValuePair<string, string>(date.InnerText, counter.InnerText);
            }
        }

        private string parseMonth (string date) {

            switch (date) {
                case "1":
                    return @"January";
                case "2":
                    return @"February";
                case "3":
                    return @"March";
                case "4":
                    return @"April";
                case "5":
                    return @"May";
                case "6":
                    return @"June";
                case "7":
                    return @"July";
                case "8":
                    return @"August";
                case "9":
                    return @"September";
                case "10":
                    return @"October";
                case "11":
                    return @"November";
                case "12":
                    return @"December";
                default:
                    return @"";
            }
        }

        private void metroButtonExportExcel_Click (object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK) {
                exportStatsToExcelFile(fbd.SelectedPath);
                MetroMessageBox.Show(this, "Excel file successfully exported", "Seccess", MessageBoxButtons.OK);
            }

        }

        private void exportStatsToExcelFile (string path) {
            var excelApplication = new Application();
            excelApplication.Visible = false;

            Workbook excelWorkbook = excelApplication.Workbooks.Add();
            if (File.Exists(path + @"\EpubReaderStatistics.xlsx")) {
                File.Delete(path + @"\EpubReaderStatistics.xlsx");
            }

            excelWorkbook.SaveAs(path + @"\EpubReaderStatistics.xlsx", AccessMode: XlSaveAsAccessMode.xlNoChange);

            //Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Worksheet excelworkWorksheet = excelWorkbook.ActiveSheet;

            //User Stats
            excelworkWorksheet.Cells[1, 1].Value = "User Statistics";
            excelworkWorksheet.Cells[2, 1].Value = "Most Active Day";
            excelworkWorksheet.Cells[2, 2].Value = userMostActiveDay.Key;
            excelworkWorksheet.Cells[2, 3].Value = userMostActiveDay.Value;
            excelworkWorksheet.Cells[3, 1].Value = "Most Active Month";
            excelworkWorksheet.Cells[3, 2].Value = parseMonth(userMostActiveMonth.Key);
            excelworkWorksheet.Cells[3, 3].Value = userMostActiveMonth.Value;
            excelworkWorksheet.Cells[4, 1].Value = "Most Active Year";
            excelworkWorksheet.Cells[4, 2].Value = userMostActiveYear.Key;
            excelworkWorksheet.Cells[4, 3].Value = userMostActiveYear.Value;
            excelworkWorksheet.Cells[5, 1].Value = "";
            excelworkWorksheet.Cells[5, 2].Value = "";
            excelworkWorksheet.Cells[5, 3].Value = "";

            //Global Stats
            excelworkWorksheet.Cells[1, 4].Value = "Global Statistics";
            excelworkWorksheet.Cells[2, 4].Value = "Most Active Day";
            excelworkWorksheet.Cells[2, 5].Value = globalMostActiveDay.Key;
            excelworkWorksheet.Cells[2, 6].Value = globalMostActiveDay.Value;
            excelworkWorksheet.Cells[3, 4].Value = "Most Active Month";
            excelworkWorksheet.Cells[3, 5].Value = parseMonth(globalMostActiveMonth.Key);
            excelworkWorksheet.Cells[3, 6].Value = globalMostActiveMonth.Value;
            excelworkWorksheet.Cells[4, 4].Value = "Most Active Year";
            excelworkWorksheet.Cells[4, 5].Value = globalMostActiveYear.Key;
            excelworkWorksheet.Cells[4, 6].Value = globalMostActiveYear.Value;
            excelworkWorksheet.Cells[5, 4].Value = "";
            excelworkWorksheet.Cells[5, 5].Value = "";
            excelworkWorksheet.Cells[5, 6].Value = "";

            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelworkWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApplication);
            GC.Collect();


        }
    }
}
