using System.Drawing;
using ePubIntegrator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using ePubIntegrator.Views;

namespace ePubIntegrator.Controllers {
    public static class XMLController {

        private static bool _bvalid = true;

        public static Boolean validaXml (XmlDocument doc, string XSDFilename) {
            ValidationEventHandler eventHandler = ValidationEventHandler;

            doc.Schemas.Add(null, @"../../XSD/" + XSDFilename + ".xsd");
            doc.Validate(eventHandler);

            if (_bvalid) {
                return true;
            } else {
                return false;
            }
        }

        private static void ValidationEventHandler (Object sender, ValidationEventArgs e) {
            switch (e.Severity) {
                case XmlSeverityType.Error:
                    MessageBox.Show(e.Message);
                    _bvalid = false;
                    break;
                case XmlSeverityType.Warning:
                    MessageBox.Show(e.Message);
                    _bvalid = false;
                    break;
            }
        }

        public static void guardarConfigXml (User u, string path, string file) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("config");
            doc.AppendChild(root);

            XmlElement elem = doc.CreateElement("pathEpubs");
            elem.InnerText = path;
            root.AppendChild(elem);
            XmlElement elemU = doc.CreateElement("user");
            root.AppendChild(elemU);

            elem = doc.CreateElement("id");
            elem.InnerText = u.Id.ToString();
            elemU.AppendChild(elem);
            elem = doc.CreateElement("username");
            elem.InnerText = u.Username;
            elemU.AppendChild(elem);
            elem = doc.CreateElement("email");
            elem.InnerText = u.Email;
            elemU.AppendChild(elem);
            elem = doc.CreateElement("birthdate");
            elem.InnerText = u.BirthDate.ToString("yyyy-MM-dd'T'hh':'mm':'ss");
            elemU.AppendChild(elem);

            path += @"\config\";

            if (!Directory.Exists(path)) {
                //Create the directory
                Directory.CreateDirectory(path);
            }

            doc.Save(path + file);
        }

        public static bool IsFileUser (string file, string email) {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode node = doc.SelectSingleNode("/config/user/email");
            return node.InnerText.Equals(email);
        }

        public static User GetUserFromFile (string file) {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode node = doc.SelectSingleNode("/config/user/id");
            int id = Convert.ToInt32(node.InnerText);
            node = doc.SelectSingleNode("/config/user/username");
            string username = node.InnerText;
            node = doc.SelectSingleNode("/config/user/email");
            string email = node.InnerText;
            node = doc.SelectSingleNode("/config/user/birthdate");
            string[] date1 = node.InnerText.Split('-');
            string[] date2 = date1[2].Split('T');
            DateTime dt = new DateTime(Convert.ToInt32(date1[0]), Convert.ToInt32(date1[1]), Convert.ToInt32(date2[0]));
            return new User(id, username, email, dt);
        }

        public static string GetEpubPathFromFile (string file) {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode node = doc.SelectSingleNode("/config/pathEpubs");
            return node.InnerText;
        }

        public static void SetEpubPath (string file, string path) {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            XmlNode node = doc.SelectSingleNode("/config/pathEpubs");
            node.InnerText = path;
            doc.Save(file);
        }

        public static void addEpub (string filePath, string title, object author, object subject, bool isEpubFavourite, bool isEpubBookmark, List<MutableKeyValuePair<string, bool>> chaptersFavourites, List<MutableKeyValuePair<string, bool>> chaptersBookmarks) {

            //to remove the cover title entry
            chaptersBookmarks.Remove(chaptersBookmarks.First());
            chaptersFavourites.Remove(chaptersFavourites.First());

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            try {
                if (doc.SelectSingleNode("/dados/epubs/epub[title='" + title + "']") != null) {
                    //if the epub already exist, update it...
                    XmlNode epubNode = doc.SelectSingleNode("/dados/epubs/epub[title='" + title + "']");

                    //new epub (first one to the list)...
                    XmlNode epubsNode = doc.SelectSingleNode("/dados/epubs");
                    epubsNode.RemoveChild(epubNode);

                    XmlElement epubElement = doc.CreateElement("epub");
                    epubsNode.AppendChild(epubElement);

                    XmlElement titleElement = doc.CreateElement("title");
                    titleElement.InnerText = title;
                    epubElement.AppendChild(titleElement);
                    XmlElement authorElement = doc.CreateElement("author");
                    authorElement.InnerText = (string) author;
                    epubElement.AppendChild(authorElement);
                    XmlElement subjectElement = doc.CreateElement("subject");
                    subjectElement.InnerText = (string) subject;
                    epubElement.AppendChild(subjectElement);
                    XmlElement favElement = doc.CreateElement("fav");
                    favElement.InnerText = isEpubFavourite.ToString().ToLower();
                    epubElement.AppendChild(favElement);
                    XmlElement bookmarkElement = doc.CreateElement("bookmark");
                    bookmarkElement.InnerText = isEpubBookmark.ToString().ToLower();
                    epubElement.AppendChild(bookmarkElement);

                    XmlElement chaptersElement = doc.CreateElement("chapters");
                    epubElement.AppendChild(chaptersElement);

                    for (int i = 0; i < chaptersBookmarks.Count; i++) {
                        XmlElement chapterElement = doc.CreateElement("chapter");
                        chaptersElement.AppendChild(chapterElement);

                        XmlElement chapTitleElement = doc.CreateElement("title");
                        chapTitleElement.InnerText = chaptersBookmarks[i].Key;
                        chapterElement.AppendChild(chapTitleElement);

                        XmlElement chapFavElement = doc.CreateElement("fav");
                        chapFavElement.InnerText = chaptersFavourites[i].Value.ToString().ToLower();
                        chapterElement.AppendChild(chapFavElement);

                        XmlElement chapBookmarkElement = doc.CreateElement("bookmark");
                        chapBookmarkElement.InnerText = chaptersBookmarks[i].Value.ToString().ToLower();
                        chapterElement.AppendChild(chapBookmarkElement);
                    }


                } else {
                    //new epub (first one to the list)...
                    XmlNode epubsNode = doc.SelectSingleNode("/dados/epubs");
                    XmlElement epubElement = doc.CreateElement("epub");
                    epubsNode.AppendChild(epubElement);

                    XmlElement titleElement = doc.CreateElement("title");
                    titleElement.InnerText = title;
                    epubElement.AppendChild(titleElement);
                    XmlElement authorElement = doc.CreateElement("author");
                    authorElement.InnerText = (string) author;
                    epubElement.AppendChild(authorElement);
                    XmlElement subjectElement = doc.CreateElement("subject");
                    subjectElement.InnerText = (string) subject;
                    epubElement.AppendChild(subjectElement);
                    XmlElement favElement = doc.CreateElement("fav");
                    favElement.InnerText = isEpubFavourite.ToString().ToLower();
                    epubElement.AppendChild(favElement);
                    XmlElement bookmarkElement = doc.CreateElement("bookmark");
                    bookmarkElement.InnerText = isEpubBookmark.ToString().ToLower();
                    epubElement.AppendChild(bookmarkElement);

                    XmlElement chaptersElement = doc.CreateElement("chapters");
                    epubElement.AppendChild(chaptersElement);

                    for (int i = 0; i < chaptersBookmarks.Count; i++) {
                        XmlElement chapterElement = doc.CreateElement("chapter");
                        chaptersElement.AppendChild(chapterElement);

                        XmlElement chapTitleElement = doc.CreateElement("title");
                        chapTitleElement.InnerText = chaptersBookmarks[i].Key;
                        chapterElement.AppendChild(chapTitleElement);

                        XmlElement chapFavElement = doc.CreateElement("fav");
                        chapFavElement.InnerText = chaptersFavourites[i].Value.ToString().ToLower();
                        chapterElement.AppendChild(chapFavElement);

                        XmlElement chapBookmarkElement = doc.CreateElement("bookmark");
                        chapBookmarkElement.InnerText = chaptersBookmarks[i].Value.ToString().ToLower();
                        chapterElement.AppendChild(chapBookmarkElement);
                    }

                }
            } catch (XPathException xpe) {
                //add new epub to the list of existing epubs...
                XmlNode epubsNode = doc.SelectSingleNode("/dados/epubs");
                XmlElement epubElement = doc.CreateElement("epub");
                epubsNode.AppendChild(epubElement);

                XmlElement titleElement = doc.CreateElement("title");
                titleElement.InnerText = title;
                epubElement.AppendChild(titleElement);
                XmlElement authorElement = doc.CreateElement("author");
                authorElement.InnerText = (string) author;
                epubElement.AppendChild(authorElement);
                XmlElement subjectElement = doc.CreateElement("subject");
                subjectElement.InnerText = (string) subject;
                epubElement.AppendChild(subjectElement);
                XmlElement favElement = doc.CreateElement("fav");
                favElement.InnerText = isEpubFavourite.ToString().ToLower();
                epubElement.AppendChild(favElement);
                XmlElement bookmarkElement = doc.CreateElement("bookmark");
                bookmarkElement.InnerText = isEpubBookmark.ToString().ToLower();
                epubElement.AppendChild(bookmarkElement);

                XmlElement chaptersElement = doc.CreateElement("chapters");
                epubElement.AppendChild(chaptersElement);

                for (int i = 0; i < chaptersBookmarks.Count; i++) {
                    XmlElement chapterElement = doc.CreateElement("chapter");
                    chaptersElement.AppendChild(chapterElement);

                    XmlElement chapTitleElement = doc.CreateElement("title");
                    chapTitleElement.InnerText = chaptersBookmarks[i].Key;
                    chapterElement.AppendChild(chapTitleElement);

                    XmlElement chapFavElement = doc.CreateElement("fav");
                    chapFavElement.InnerText = chaptersFavourites[i].Value.ToString().ToLower();
                    chapterElement.AppendChild(chapFavElement);

                    XmlElement chapBookmarkElement = doc.CreateElement("bookmark");
                    chapBookmarkElement.InnerText = chaptersBookmarks[i].Value.ToString().ToLower();
                    chapterElement.AppendChild(chapBookmarkElement);

                }
            }


            doc.Save(filePath);
        }

        public static void createNewEmptyUserEpubInfo (String filePath, User user) {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("dados");
            doc.AppendChild(root);

            XmlElement elemRoot1 = doc.CreateElement("userId");
            elemRoot1.InnerText = user.Id.ToString();
            root.AppendChild(elemRoot1);
            XmlElement elemRoot2 = doc.CreateElement("epubs");
            root.AppendChild(elemRoot2);

            doc.Save(filePath);
        }
    }
}
