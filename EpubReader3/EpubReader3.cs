using Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace EpubReader3 {
    public class EPubReader3 {

        private string EPUB_Filename = "";
        private string EPUB_Title = "";
        private string EPUB_Information = "";
        private ArrayList EPUB_InformationArray = new ArrayList();
        private string Temp_Path = "";
        private string Doc_Anchor = "";
        private List<string> Script_Files = new List<string>();
        private List<string> XHTML_Files = new List<string>();
        private List<string> XHTML_Sources = new List<string>();
        private bool SelectedNode_Flag;
        private bool Navigated_Flag;
        private string Cover_Content = "";
        private string Cover_URL = "";
        private string Encoding_Default = "";
        private string Encoding_URL = "";
        private bool Encoding_Reflesh;
        private TreeView treeView;
        private WebBrowser webBrowser;
        private Thread thread;
        private String filename;

        public EPubReader3 (String filename, TreeView treeView, WebBrowser webBrowser) {

            if (filename != "" && treeView != null && webBrowser != null) {
                this.filename = filename;
                this.treeView = treeView;
                this.webBrowser = webBrowser;
                thread = new Thread(new ThreadStart(this.threadTask));
                thread.IsBackground = true;
                thread.Start();
            }

        }

        private void threadTask () {
            this.webBrowser.Url = new Uri("about:blank");
            openEPUBFile(filename);
        }

        private string GetTempDirectory () {
            string text = Path.GetRandomFileName();
            text = Path.Combine(Path.GetTempPath(), text);
            Directory.CreateDirectory(text);
            return text;
        }

        private void readEpubFile () {
            if (this.EPUB_Filename == "") {
                return;
            }

            string text = this.Temp_Path + "\\META-INF\\container.xml";

            if (!File.Exists(text)) {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = null;
            xmlDocument.Load(text);
            List<string> list = new List<string>();
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("rootfile");

            for (int i = 0; i < elementsByTagName.Count; i++) {
                var xmlAttributeCollection = elementsByTagName[i].Attributes;
                if (xmlAttributeCollection != null) {
                    XmlNode xmlNode = xmlAttributeCollection["full-path"];
                    if (xmlNode != null && xmlNode.Value != "") {
                        string text2 = this.Temp_Path + "\\" + xmlNode.Value.Replace("/", "\\");
                        if (File.Exists(text2)) {
                            list.Add(text2);
                        }
                    }
                }
            }

            if (list.Count == 0 && File.Exists(this.Temp_Path + "\\content.opf")) {
                list.Add(this.Temp_Path + "\\content.opf");
            }
            if (this.treeView.InvokeRequired)
                this.treeView.BeginInvoke((MethodInvoker) delegate {
                    this.treeView.BeginUpdate();
                    try {
                        foreach (string current in list) {
                            this.readContentOPF(current);
                        }
                        if (this.treeView.Nodes.Count > 0) {
                            this.treeView.Nodes[0].Expand();
                            if (this.treeView.Nodes[0].Nodes.Count > 0 && this.treeView.Nodes[0].Nodes[0].Name == this.treeView.Nodes[0].Name) {
                                this.treeView.Nodes[0].Name = "";
                            }
                            if (this.treeView.Nodes[0].Name != "") {
                                this.treeView.SelectedNode = this.treeView.Nodes[0];
                            } else {
                                if (this.treeView.Nodes[0].Nodes.Count > 0 && this.treeView.Nodes[0].Nodes[0].Name != "") {
                                    this.treeView.SelectedNode = this.treeView.Nodes[0].Nodes[0];
                                }
                            }
                        }
                    } finally {
                        this.treeView.EndUpdate();
                    }
                });
        }

        private void readContentOPF (string content) {
            if (!File.Exists(content)) {
                return;
            }
            string directoryName = Path.GetDirectoryName(content);
            XmlDocument xmlDocument = new XmlDocument();
            try {
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(content);
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("dc:title");
                if (elementsByTagName.Count > 0 && elementsByTagName[0].InnerText != "") {
                    this.EPUB_Title = elementsByTagName[0].InnerText;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            try {
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("dc:creator");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Creator: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:subject");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Subject: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:description");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Description: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:publisher");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Publisher: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:contributor");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Contributor: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:date");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Date: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:type");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Type: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:format");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Format: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:identifier");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Identifiere: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:source");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Source: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:language");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Language: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:relation");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Relation: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:coverage");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Coverage: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
                elementsByTagName = xmlDocument.GetElementsByTagName("dc:rights");
                if (elementsByTagName.Count > 0) {
                    this.EPUB_Information = this.EPUB_Information + "Rights: " + elementsByTagName[0].InnerText + "\n";
                    EPUB_InformationArray.Add(elementsByTagName[0].InnerText);
                } else {
                    EPUB_InformationArray.Add("");
                }
            } catch (Exception ex2) {
                MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            string text = "";
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            try {
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("reference");
                for (int i = 0; i < elementsByTagName.Count; i++) {
                    string text2 = "";
                    string text3 = "";
                    string text4 = "";
                    if (elementsByTagName[i].Attributes["href"] != null && elementsByTagName[i].Attributes["href"].Value != "") {
                        text2 = elementsByTagName[i].Attributes["href"].Value;
                    }
                    if (elementsByTagName[i].Attributes["title"] != null && elementsByTagName[i].Attributes["title"].Value != "") {
                        text3 = elementsByTagName[i].Attributes["title"].Value;
                    }
                    if (elementsByTagName[i].Attributes["type"] != null && elementsByTagName[i].Attributes["type"].Value != "") {
                        text4 = elementsByTagName[i].Attributes["type"].Value.ToLower();
                    }
                    if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4) && (text4 == "cover" || text4 == "title-page" || text4 == "toc" || text4 == "index" || text4 == "copyright" || text4 == "copyright-page" || text4 == "text") && File.Exists(directoryName + "\\" + this.getFileName(text2))) {
                        list.Add(text2);
                        list2.Add(text3);
                        list3.Add(text4);
                    }
                    if (text4 == "cover" && !string.IsNullOrEmpty(text2) && File.Exists(directoryName + "\\" + this.getFileName(text2))) {
                        text = this.getFileURL(directoryName, text2);
                    }
                }
            } catch {
            }
            List<string> list4 = new List<string>();
            List<string> list5 = new List<string>();
            try {
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("item");
                for (int j = 0; j < elementsByTagName.Count; j++) {
                    if (elementsByTagName[j].Attributes["id"] != null && elementsByTagName[j].Attributes["href"] != null) {
                        list4.Add(elementsByTagName[j].Attributes["id"].Value);
                        list5.Add(elementsByTagName[j].Attributes["href"].Value);
                        try {
                            if (string.IsNullOrEmpty(text) && elementsByTagName[j].Attributes["id"].Value.ToLower() == "cover" && File.Exists(directoryName + "\\" + elementsByTagName[j].Attributes["href"].Value)) {
                                text = this.getFileURL(directoryName, elementsByTagName[j].Attributes["href"].Value);
                            }
                        } catch {
                        }
                    }
                }
            } catch (Exception ex3) {
                MessageBox.Show(ex3.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            this.formatCoverUrl(text);
            this.treeView.Nodes.Clear();
            TreeNode treeNode = this.treeView.Nodes.Add("", this.EPUB_Title, 0, 0);
            List<string> list6 = new List<string>();
            try {
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("itemref");
                for (int k = 0; k < elementsByTagName.Count; k++) {
                    if (elementsByTagName[k].Attributes["idref"] != null && elementsByTagName[k].Attributes["idref"].Value != "") {
                        for (int l = 0; l < list4.Count; l++) {
                            if (list4[l] == elementsByTagName[k].Attributes["idref"].Value) {
                                list6.Add(list5[l]);
                                break;
                            }
                        }
                    }
                }
            } catch (Exception ex4) {
                MessageBox.Show(ex4.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            string toc = directoryName + "\\toc.ncx";
            int num = list4.FindIndex((string s) => s.Equals("ncx", StringComparison.Ordinal));
            if (num >= 0 && File.Exists(directoryName + "\\" + list5[num])) {
                toc = directoryName + "\\" + list5[num];
            }
            this.readTocNCX(treeNode, directoryName, toc);
            try {
                if (list.Count > 0) {
                    for (int m = 0; m < list.Count; m++) {
                        bool flag = false;
                        string fileURL = this.getFileURL(directoryName, list[m]);
                        for (int n = 0; n < treeNode.Nodes.Count; n++) {
                            if (this.equalsFileURL(treeNode.Nodes[n].Name, fileURL)) {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag && !string.IsNullOrEmpty(fileURL) && !this.equalsFileURL(fileURL, text)) {
                            string text5 = list2[m];
                            if (string.IsNullOrEmpty(text5)) {
                                text5 = "[untitled]";
                            }
                            treeNode.Nodes.Insert(0, fileURL, text5, 1, 1);
                        }
                    }
                }
            } catch {
            }

            try {
                if (!string.IsNullOrEmpty(text) && !this.equalsFileURL(treeNode.Name, text)) {
                    bool flag2 = false;
                    for (int num2 = 0; num2 < treeNode.Nodes.Count; num2++) {
                        if (this.equalsFileURL(treeNode.Nodes[num2].Name, text)) {
                            flag2 = true;
                            break;
                        }
                    }
                    if (!flag2) {
                        treeNode.Name = text;
                    }
                }
            } catch {
            }
            for (int num3 = 0; num3 < list6.Count; num3++) {
                bool flag3 = false;
                string fileURL2 = this.getFileURL(directoryName, list6[num3]);
                for (int num4 = 0; num4 < treeNode.Nodes.Count; num4++) {
                    if (this.equalsFileURL(treeNode.Nodes[num4].Name, fileURL2)) {
                        flag3 = true;
                        break;
                    }
                }
                if (!flag3 && !string.IsNullOrEmpty(fileURL2) && !this.equalsFileURL(text, fileURL2)) {
                    string text6 = list6[num3];
                    text6 = Path.GetFileNameWithoutExtension(text6);
                    if (string.IsNullOrEmpty(text6)) {
                        text6 = "[untitled]";
                    }
                    treeNode.Nodes.Add(fileURL2, text6, 1, 1);
                }
            }
            this.EPUB_Information = "Title: " + this.EPUB_Title + "\n" + this.EPUB_Information;
        }

        private void readTocNCX (TreeNode content_Node, string contant_Path, string toc) {
            if (!File.Exists(toc)) {
                return;
            }
            XmlDocument xmlDocument = new XmlDocument();
            XmlNodeList elementsByTagName;
            try {
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(toc);
                elementsByTagName = xmlDocument.GetElementsByTagName("docTitle");
                if (elementsByTagName.Count > 0) {
                    XmlNode xmlNode = elementsByTagName[0]["text"];
                    if (xmlNode != null && xmlNode.InnerText != "" && this.EPUB_Title != xmlNode.InnerText) {
                        this.EPUB_Title = xmlNode.InnerText;
                        if (this.treeView.Nodes.Count > 0) {
                            content_Node.Text = this.EPUB_Title;
                        }
                    }
                }
            } catch {
                MessageBox.Show("This book seem be locked by DRM. The file toc.ncx (table of contents navigation and control) cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            elementsByTagName = xmlDocument.GetElementsByTagName("navPoint");
            for (int i = 0; i < elementsByTagName.Count; i++) {
                XmlNode xmlNode2 = elementsByTagName[i]["navLabel"]["text"];
                XmlNode xmlNode3 = elementsByTagName[i]["content"];
                if (xmlNode2 != null && xmlNode3 != null) {
                    string fileURL = this.getFileURL(contant_Path, xmlNode3.Attributes["src"].Value);
                    string text = xmlNode2.InnerText;
                    if (!string.IsNullOrEmpty(fileURL)) {
                        if (string.IsNullOrEmpty(text)) {
                            text = "[untitled]";
                        }
                        content_Node.Nodes.Add(fileURL, text, 1, 1);
                    }
                }
            }
        }

        private bool extractEPUBFile (string filename) {
            //this.showWaitMessage("Opening...");
            bool result;
            try {
                this.Temp_Path = this.GetTempDirectory();
                ZipFile zipFile = ZipFile.Read(filename);
                try {
                    zipFile.ExtractAll(this.Temp_Path);
                    result = true;
                } catch {
                    result = false;
                }
            } catch {
                result = false;
            } finally {
                //this.showWaitMessage("");
            }
            return result;
        }

        private void openEPUBFile (string filename) {
            if (!this.extractEPUBFile(filename)) {
                MessageBox.Show("Cannot open file \"" + filename + "\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            this.EPUB_Filename = filename;
            this.EPUB_Title = Path.GetFileNameWithoutExtension(filename);
            this.readEpubFile();
            if (this.treeView.InvokeRequired)
                this.treeView.BeginInvoke((MethodInvoker) delegate {
                    if (this.treeView.Nodes.Count == 0) {
                        MessageBox.Show("No book information in file \"" + filename + "\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                });
        }

        private bool readyEPUBFile () {
            if (this.EPUB_Filename == "") {
                MessageBox.Show("Please open a EPUB file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        public void closeEPUBFile () {
            this.EPUB_Filename = "";
            this.EPUB_Title = "";
            this.EPUB_Information = "";
            this.Doc_Anchor = "";
            this.Script_Files.Clear();
            this.XHTML_Files.Clear();
            this.XHTML_Sources.Clear();
            this.SelectedNode_Flag = false;
            this.Navigated_Flag = false;
            this.Cover_Content = "";
            this.Cover_URL = "";
            this.Encoding_Default = "";
            this.Encoding_URL = "";
            this.Encoding_Reflesh = false;

            try {
                if (this.webBrowser != null) {
                    this.webBrowser.Url = new Uri("about:blank");
                    this.treeView.Nodes.Clear();
                    if (this.Temp_Path != "") {
                        try {
                            if (Directory.Exists(this.Temp_Path)) {
                                Directory.Delete(this.Temp_Path, true);
                            }
                        } catch {
                        }
                        try {
                            if (Directory.Exists(this.Temp_Path)) {
                                Directory.Delete(this.Temp_Path, true);
                            }
                        } catch {
                        }
                        this.Temp_Path = "";
                    }
                }
            } catch {
            }
        }

        private bool equalsFileURL (string url1, string url2) {
            bool result;
            try {
                url1 = url1.Trim().ToLower();
                url2 = url2.Trim().ToLower();
                if (url1 == url2) {
                    result = true;
                } else {
                    url1 = this.getFileName(url1);
                    url2 = this.getFileName(url2);
                    if (url1 == url2) {
                        result = true;
                    } else {
                        url1 = Uri.UnescapeDataString(url1);
                        url2 = Uri.UnescapeDataString(url2);
                        if (url1 == url2) {
                            result = true;
                        } else {
                            url1 = this.unescapeFileName(url1);
                            url2 = this.unescapeFileName(url2);
                            if (url1 == url2) {
                                result = true;
                            } else {
                                result = false;
                            }
                        }
                    }
                }
            } catch {
                result = false;
            }
            return result;
        }

        private string unescapeFileName (string url) {
            try {
                url = Uri.UnescapeDataString(url);
                if (url.IndexOf("%") < 0) {
                    string result = url;
                    return result;
                }
                string[] array = new string[]
                {
                    "%21",
                    "%27",
                    "%28",
                    "%29",
                    "%5F",
                    "%2A",
                    "%2D",
                    "%2E",
                    "%7E"
                };
                string[] array2 = new string[]
                {
                    "!",
                    "'",
                    "(",
                    ")",
                    "_",
                    "*",
                    "-",
                    ".",
                    "~"
                };
                for (int i = 0; i < array.Length; i++) {
                    url = url.Replace(array[i], array2[i]);
                }
                if (url.IndexOf("%") < 0) {
                    string result = url;
                    return result;
                }
                for (char c = 'A'; c <= 'Z'; c += '\u0001') {
                    url = url.Replace("%" + ((byte) (c - 'A' + ')')).ToString(), c.ToString());
                }
                if (url.IndexOf("%") < 0) {
                    string result = url;
                    return result;
                }
                for (char c2 = 'a'; c2 <= 'z'; c2 += '\u0001') {
                    url = url.Replace("%" + ((byte) (c2 - 'a' + '=')).ToString(), c2.ToString());
                }
                if (url.IndexOf("%") < 0) {
                    string result = url;
                    return result;
                }
                for (char c3 = '0'; c3 <= '9'; c3 += '\u0001') {
                    url = url.Replace("%" + ((byte) (c3 - '0' + '\u001e')).ToString(), c3.ToString());
                }
            } catch {
            }
            return url;
        }

        private string getFileName (string url) {
            try {
                int num = url.LastIndexOf('#');
                if (num != -1) {
                    url = url.Substring(0, num);
                }
            } catch {
            }
            return url;
        }

        private string getFileURL (string contant_Path, string href) {
            return string.Format("file:///{0}/" + href, contant_Path).Replace("\\", "/");
        }

        private string getFileURL (string href) {
            return ("file:///" + href).Replace("\\", "/");
        }

        private string getFilePath (string url) {
            return this.getFileName(url).Replace("file:///", "").Replace("/", "\\");
        }

        //verificado e a funcionar
        private void formatCoverUrl (string cover_url) {
            this.Cover_Content = "";
            this.Cover_URL = "";
            if (string.IsNullOrEmpty(cover_url)) {
                return;
            }
            cover_url = this.getFilePath(cover_url);
            if (!File.Exists(cover_url)) {
                return;
            }
            try {
                string text = File.ReadAllText(cover_url);
                if (!string.IsNullOrEmpty(text)) {
                    int num = text.IndexOf("<svg ", System.StringComparison.Ordinal);
                    if (num >= 0) {
                        int num2 = text.IndexOf("</svg>", num, System.StringComparison.Ordinal);
                        if (num2 >= 0) {
                            string text2 = text.Substring(num, num2 - num);
                            string text3 = text2.Trim().ToLower();
                            if (!string.IsNullOrEmpty(text3)) {
                                int num3 = text3.IndexOf("viewbox=\"", System.StringComparison.Ordinal);
                                if (num3 >= 0) {
                                    int num4 = text3.IndexOf("\"", num3 + 9, System.StringComparison.Ordinal);
                                    if (num4 >= 0) {
                                        string text4 = text3.Substring(num3 + 9, num4 - num3 - 9).Trim();
                                        if (!string.IsNullOrEmpty(text4)) {
                                            string[] array = text4.TrimStart(new char[]
                                            {
                                                '"'
                                            }).TrimEnd(new char[]
                                            {
                                                '"'
                                            }).Split(new char[]
                                            {
                                                ' '
                                            });
                                            if (array.Length == 4) {
                                                int num5 = 0;
                                                if (int.TryParse(array[2], out num5)) {
                                                    if (num5 > 0) {
                                                        int num6 = 0;
                                                        if (int.TryParse(array[3], out num6)) {
                                                            if (num6 > 0) {
                                                                string text5 = text2;
                                                                text5 = Regex.Replace(text5, "height=\"100%\"", "height=\"" + num6.ToString() + "\"", RegexOptions.IgnoreCase);
                                                                text5 = Regex.Replace(text5, "width=\"100%\"", "width=\"" + num5.ToString() + "\"", RegexOptions.IgnoreCase);
                                                                string text6 = text;
                                                                text6 = text6.Replace(text2, text5);
                                                                text6 = Regex.Replace(text6, "</html>", string.Concat(new string[]
                                                                {
                                                                    "<style type=\"text/css\">svg {width: ",
                                                                    num5.ToString(),
                                                                    "px; height: ",
                                                                    num6.ToString(),
                                                                    "px;}</style></html>"
                                                                }), RegexOptions.IgnoreCase);
                                                                if (text6 != text) {
                                                                    this.writeFileContent(cover_url, text6);
                                                                    this.Cover_Content = text;

                                                                    this.Cover_URL = cover_url;

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } catch {
                this.Cover_Content = "";
                this.Cover_URL = "";
            }
        }

        private void writeFileContent (string file, string content) {
            Encoding encoding = null;
            try {
                if (File.Exists(file)) {
                    StreamReader streamReader = new StreamReader(file);
                    encoding = streamReader.CurrentEncoding;
                    streamReader.Close();
                }
            } catch {
            }
            if (encoding == null) {
                File.WriteAllText(file, content);
                return;
            }
            File.WriteAllText(file, content, encoding);
        }

        /*
         Public ***********************************************************************
         */

        public string getTitle () {
            if (this.EPUB_Title != "") {
                return this.EPUB_Title;
            } else {
                return "";
            }
        }

        public string getFileName () {
            return this.EPUB_Filename;
        }

        public ArrayList getEPUB_Information () {
            return this.EPUB_InformationArray;
        }

        /******************************************************************************/

        public void treeView_AfterSelect (object sender, TreeViewEventArgs e) {
            if (this.SelectedNode_Flag) {
                return;
            }
            this.SelectedNode_Flag = true;
            try {
                string text = "";
                if (e != null) {
                    text = e.Node.Name;
                } else {
                    if (this.treeView.SelectedNode != null) {
                        text = this.treeView.SelectedNode.Name;
                    }
                }
                string text2 = "";
                if (text != "") {
                    int num = text.LastIndexOf('#');
                    if (num != -1) {
                        text2 = text.Substring(num + 1);
                        text = text.Substring(0, num);
                    }
                    if (text != "") {
                        text = text.Replace("\\", "/");
                        if (this.webBrowser.Url == null) {
                            this.webBrowser.Url = new Uri(@"about:blank");
                        }
                        //Workaround :D
                        var tempUri = new Uri(text);
                        if (this.webBrowser.Url != tempUri) {
                            try {
                                this.Doc_Anchor = text2;
                                this.webBrowser.Url = new Uri(text);
                                goto IL_196;
                            } catch (Exception ex) {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                goto IL_196;
                            }
                        }
                        if (text2 == "" && this.Doc_Anchor != text2) {
                            this.Doc_Anchor = "";
                            try {
                                var htmlDocument = this.webBrowser.Document;
                                if (htmlDocument != null) {
                                    if (htmlDocument.Body != null) {
                                        HtmlElementCollection all = htmlDocument.Body.All;
                                        if (all.Count > 0) {
                                            all[0].ScrollIntoView(true);
                                        } else {
                                            this.webBrowser.Url = new Uri(text);
                                        }
                                    }
                                }
                            } catch (Exception ex2) {
                                MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
                    IL_196:
                        if (text2 != "" && this.Doc_Anchor != text2) {
                            this.Doc_Anchor = text2;
                            this.webBrowser_DocumentCompleted(null, null);
                        }
                    }
                }
            } finally {
                this.SelectedNode_Flag = false;
            }
        }

        public void webBrowser_DocumentCompleted (object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (this.Navigated_Flag) {
                return;
            }
            if (this.Doc_Anchor != "") {
                try {
                    HtmlElementCollection all = this.webBrowser.Document.Body.All;
                    foreach (HtmlElement htmlElement in all) {
                        string attribute = htmlElement.GetAttribute("ID");
                        if (!string.IsNullOrEmpty(attribute) && attribute == this.Doc_Anchor) {
                            htmlElement.ScrollIntoView(true);
                            break;
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            try {
                if (!string.IsNullOrEmpty(this.webBrowser.DocumentText) && this.webBrowser.Document != null && this.webBrowser.Document.Body != null && string.IsNullOrEmpty(this.webBrowser.Document.Body.InnerHtml) && this.webBrowser.DocumentText.IndexOf("<script ") > 0 && Regex.Match(this.webBrowser.DocumentText, "<script (.*?)/>").Success) {
                    string text = Regex.Replace(this.webBrowser.DocumentText, "<script (.*?)/>", "<script $1><!--//--></script>");
                    if (this.webBrowser.DocumentText != text) {
                        string filePath = this.getFilePath(this.webBrowser.Url.ToString());
                        if (File.Exists(filePath)) {
                            this.writeFileContent(filePath, text);
                            if (this.Script_Files.IndexOf(filePath) < 0) {
                                this.Script_Files.Add(filePath);
                            }
                            this.webBrowser.Refresh();
                        }
                    }
                }
            } catch {
            }
            this.webBrowserFocus();
            try {
                if (this.webBrowser.Document != null && this.webBrowser.Document.Body != null) {
                    this.treeView.Focus();
                }
            } catch {
            }
        }

        public void webBrowser_Navigated (object sender, WebBrowserNavigatedEventArgs e) {
            if (this.Navigated_Flag) {
                return;
            }
            if (this.Encoding_Reflesh) {
                this.Encoding_Reflesh = false;
            }
            try {
                string text = this.getFileName(e.Url.ToString());
                if (text == "about:blank") {
                    return;
                }
                string filePath = this.getFilePath(text);
                if (File.Exists(filePath)) {
                    string a = Path.GetExtension(text).ToLower();
                    if (a == ".xml" || (filePath == this.Cover_URL && !string.IsNullOrEmpty(this.Cover_Content) && a == ".html")) {
                        string text2 = Path.ChangeExtension(filePath, ".xhtml");
                        if (!File.Exists(text2)) {
                            try {
                                File.Copy(filePath, text2, true);
                                if (File.Exists(text2)) {
                                    this.XHTML_Files.Add(text2);
                                    this.XHTML_Sources.Add(filePath);
                                }
                            } catch {
                            }
                        }
                        if (File.Exists(text2)) {
                            text = this.getFileURL(text2);
                            this.webBrowser.Url = new Uri(text);
                        }
                    }
                } else {
                    if (filePath.StartsWith(this.Temp_Path) && filePath.IndexOf("%") > 0) {
                        string text3 = this.unescapeFileName(filePath);
                        string fileName = Path.GetFileName(filePath);
                        string fileName2 = Path.GetFileName(text3);
                        if (text3.ToLower() != filePath.ToLower() && fileName.ToLower() != fileName2.ToLower() && File.Exists(text3)) {
                            string text4 = text.Replace(fileName, fileName2);
                            if (text4 != text && text4.Trim().ToLower() != text.Trim().ToLower() && text4.IndexOf("%") < 0) {
                                this.webBrowser.Url = new Uri(text4);
                                return;
                            }
                        }
                    }
                }
            } catch {
            }
            try {
                string text5 = e.Url.ToString();
                if (this.treeView.SelectedNode != null && !string.IsNullOrEmpty(text5) && this.treeView.Nodes.Count > 0 && !this.SelectedNode_Flag) {
                    text5 = this.getFileName(text5);
                    if (this.getFileName(this.treeView.SelectedNode.Name) != text5) {
                        for (int i = 0; i < this.treeView.Nodes[0].Nodes.Count; i++) {
                            if (this.treeView.Nodes[0].Nodes[i] != this.treeView.SelectedNode && this.getFileName(this.treeView.Nodes[0].Nodes[i].Name) == text5) {
                                this.SelectedNode_Flag = true;
                                try {
                                    this.treeView.SelectedNode = this.treeView.Nodes[0].Nodes[i];
                                } finally {
                                    this.SelectedNode_Flag = false;
                                }
                            }
                        }
                    }
                }
            } catch {
            }
        }

        public void webBrowser_PreviewKeyDown (object sender, PreviewKeyDownEventArgs e) {
            if (e.Control && e.KeyCode == Keys.O) {
                e.IsInputKey = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.W) {
                e.IsInputKey = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Right) {
                e.IsInputKey = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.Left) {
                e.IsInputKey = true;
                return;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) {
                e.IsInputKey = true;
                return;
            }
            if (e.Control && e.KeyCode != Keys.F && e.KeyCode != Keys.P && e.KeyCode != Keys.S && e.KeyCode != Keys.C && e.KeyCode != Keys.A && e.KeyCode != Keys.Oemplus && e.KeyCode != Keys.OemMinus) {
                e.IsInputKey = true;
            }
        }

        private void nextSectionToolStripMenuItem_Click (object sender, EventArgs e) {
            if (!this.readyEPUBFile()) {
                return;
            }
            if (this.treeView.SelectedNode == null) {
                return;
            }
            if (this.treeView.SelectedNode.NextNode == null) {
                if (this.treeView.SelectedNode.Nodes.Count > 0) {
                    this.treeView.SelectedNode = this.treeView.SelectedNode.Nodes[0];
                }
            } else {
                this.treeView.SelectedNode = this.treeView.SelectedNode.NextNode;
            }
            this.treeView_AfterSelect(null, null);
        }

        private void webBrowserFocus () {
            try {
                this.webBrowser.Focus();
                if (this.webBrowser.Document != null) {
                    this.webBrowser.Document.Focus();
                    if (this.webBrowser.Document.Body != null) {
                        this.webBrowser.Document.Body.Focus();
                    }
                }
            } catch {
            }
        }
    }
}