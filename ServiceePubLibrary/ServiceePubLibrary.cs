using System.Collections.Generic;
using ServiceePubLibrary.Controllers;
using ServiceePubLibrary.Exceptions;
using ServiceePubLibraryEntities;
using ServiceePubLibraryEntities.Controllers;
using ServiceePubLibraryEntities.Entities;
using ServiceePubLibraryEntities.Exceptions;
using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Schema;

namespace ServiceePubLibrary {
    public class ServiceePubLibrary : IServiceePubLibrary {
        private static bool _bvalid = true;

        public void RegisterUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "newUser");
                Hashtable htLogin = new Hashtable();
                XmlNode node = doc.SelectSingleNode("/authentication/nickname");
                htLogin.Add("nickname", node.InnerText);
                node = doc.SelectSingleNode("/authentication/email");
                htLogin.Add("email", node.InnerText);
                node = doc.SelectSingleNode("/authentication/password");
                htLogin.Add("password", node.InnerText);
                node = doc.SelectSingleNode("/authentication/birthDate");
                string[] date1 = node.InnerText.Split('-');
                string[] date2 = date1[2].Split('T');
                DateTime dt = new DateTime(Convert.ToInt32(date1[0]), Convert.ToInt32(date1[1]), Convert.ToInt32(date2[0]));
                htLogin.Add("date", dt);

                UsersEntity user = new UsersEntity();
                try {
                    user.Register((string) htLogin["nickname"], (string) htLogin["email"], (string) htLogin["password"], (DateTime) htLogin["date"]);
                } catch (UniqueEmailException uee) {
                    throw new FaultException();
                }
            } catch (XMLNotValidException xmlnve) {
                throw new FaultException();
            }
        }

        private XmlDocument ValidateXML (string xmlString, string XSDFilename) {
            _bvalid = true;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            try {
                if (this.Validation(doc, XSDFilename)) {
                    return doc;

                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        private bool Validation (XmlDocument doc, string XSDFilename) {
            ValidationEventHandler eventHandler = ValidationEventHandler;

            doc.Schemas.Add(null, MapPath(@"~/XSD/" + XSDFilename + ".xsd"));
            doc.Validate(eventHandler);

            if (_bvalid) {
                return true;
            } else {
                throw new XMLNotValidException();
            }
        }

        private static string MapPath (string path) {
            if (HttpContext.Current != null)
                return HttpContext.Current.Server.MapPath(path);

            return HostingEnvironment.MapPath(path);
        }

        static void ValidationEventHandler (Object sender, ValidationEventArgs e) {
            switch (e.Severity) {
                case XmlSeverityType.Error:
                    _bvalid = false;
                    break;
                case XmlSeverityType.Warning:
                    _bvalid = false;
                    break;
            }
        }

        public bool Login (string xmlString) {
            XmlDocument doc = this.ValidateXML(xmlString, "login");
            XmlNode node = doc.SelectSingleNode("/login/email");
            string email = node.InnerText;
            node = doc.SelectSingleNode("/login/password");
            string password = node.InnerText;
            UsersEntity user = new UsersEntity();
            int id = user.IsUser(email, password); //devolve 0 se não for user, caso seja devolve o Id do user
            if (id != 0) {
                LoginHistoryEntity lhe = new LoginHistoryEntity();
                lhe.RegisterLogin(id);
                return true;
            }
            return false;
        }

        public UserContract GetUser (string xmlString) {
            XmlDocument doc = this.ValidateXML(xmlString, "string");
            XmlNode node = doc.SelectSingleNode("/string");
            string email = node.InnerText;
            User user = new User();
            UsersEntity userEntity = new UsersEntity();
            UserContract userContract = new UserContract();
            user = userEntity.GetUser(email);
            userContract.Id = user.Id;
            userContract.Username = user.Username;
            userContract.Email = user.Email;
            userContract.BirthDate = user.Birthdate;
            return userContract;
        }

        public void SetUserInfo (string xmlString) {

            try {
                SetSincronizeController sc = new SetSincronizeController(this.ValidateXML(xmlString, "sincronize"));
            } catch (Exception e) {
            }

        }

        public string GetUserInfo (string xmlString) {
            XmlDocument doc = this.ValidateXML(xmlString, "string");
            XmlNode node = doc.SelectSingleNode("/string");
            string email = node.InnerText;
            UsersEntity ue = new UsersEntity();
            int userId = ue.GetUser(email).Id;
            try {
                GetSincronizeController sc = new GetSincronizeController(userId);
                doc.LoadXml(sc.GetUserInfo());
                if (this.Validation(doc, "sincronize")) {
                    return doc.OuterXml;
                } else {
                    throw new Exception();
                }

            } catch (Exception e) {
                throw new Exception();
            }
        }

        public string GetMostActiveDay () {
            LoginHistoryEntity ue = new LoginHistoryEntity();
            string outup = ue.GetMostActiveDay();
            try {
                XmlDocument doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetMostActiveMonth () {
            LoginHistoryEntity ue = new LoginHistoryEntity();
            string outup = ue.GetMostActiveMonth();
            try {
                XmlDocument doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetMostActiveYear () {
            LoginHistoryEntity ue = new LoginHistoryEntity();
            string outup = ue.GetMostActiveYear();
            try {
                XmlDocument doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetChaptersTopFive () {
            ChapterFavEntity cfe = new ChapterFavEntity();
            return cfe.GetTopFive(new DateTime());
        }

        public string GetAllMonths () {
            LoginHistoryEntity ue = new LoginHistoryEntity();
            string outup = ue.GetAllMonths();
            try {
                XmlDocument doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetMostActiveDayByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                LoginHistoryEntity ue = new LoginHistoryEntity();
                string outup = ue.GetMostActiveDayByUser(userId);

                doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }

            } catch (XMLNotValidException xnve) {
                throw new XMLNotValidException();
            }
        }

        public string GetMostActiveMonthByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                LoginHistoryEntity ue = new LoginHistoryEntity();
                string outup = ue.GetMostActiveMonthByUser(userId);

                doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }

            } catch (XMLNotValidException xnve) {
                throw new XMLNotValidException();
            }
        }

        public string GetMostActiveYearByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                LoginHistoryEntity ue = new LoginHistoryEntity();
                string outup = ue.GetMostActiveYearByUser(userId);

                doc = this.ValidateXML(outup, "mostActive");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }

            } catch (XMLNotValidException xnve) {
                throw new XMLNotValidException();
            }
        }

        public string GetAllMonthsByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                LoginHistoryEntity ue = new LoginHistoryEntity();
                string outup = ue.GetAllMonthsByUser(userId);
                doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetTop5EpubFav () {
            EpubFavEntity efe = new EpubFavEntity();
            string outup = efe.GetTop5();
            try {
                XmlDocument doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetTop5EpubBookmark () {
            EpubBookmarkEntity ebe = new EpubBookmarkEntity();
            string outup = ebe.GetTop5();
            try {
                XmlDocument doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }
            } catch (XMLNotValidException xnvle) {
                throw new XMLNotValidException();
            }
        }

        public string GetTop5EpubFavByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                EpubFavEntity efe = new EpubFavEntity();
                string outup = efe.GetTop5(userId);

                doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }

            } catch (XMLNotValidException xnve) {
                throw new XMLNotValidException();
            }
        }

        public string GetTop5EpubBookmarkByUser (string xmlString) {
            try {
                XmlDocument doc = this.ValidateXML(xmlString, "string");
                XmlNode node = doc.SelectSingleNode("/string");
                int userId = Convert.ToInt32(node.InnerText);

                EpubBookmarkEntity ebe = new EpubBookmarkEntity();
                string outup = ebe.GetTop5(userId);

                doc = this.ValidateXML(outup, "activeAll");
                if (doc != null) {
                    return doc.OuterXml;
                } else {
                    throw new XMLNotValidException();
                }

            } catch (XMLNotValidException xnve) {
                throw new XMLNotValidException();
            }
        }
    }
}
