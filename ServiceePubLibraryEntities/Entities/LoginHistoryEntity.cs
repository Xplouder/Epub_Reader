using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServiceePubLibraryEntities.Entities {
    public class LoginHistoryEntity {
        private Model_Service_ePub_LibraryContainer context;

        public LoginHistoryEntity () {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterLogin (int id) {
            try {
                LoginHistory lh = new LoginHistory();
                lh.User_Id = id;
                lh.DateLogin = DateTime.Now;
                this.context.LoginHistory.Add(lh);
                this.context.SaveChanges();
            } catch (DbUpdateException e) {
                Console.WriteLine(e.Message);
            }
        }

        private string GetMostActive(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.GetCs());
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(query, connection);

            string data = "";
            string counter = "";

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data = reader[0].ToString();
                    counter = reader[1].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            connection.Close();

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("mostActive");
            doc.AppendChild(root);
            XmlElement elem = doc.CreateElement("date");
            elem.InnerText = data;
            root.AppendChild(elem);
            elem = doc.CreateElement("counter");
            elem.InnerText = counter;
            root.AppendChild(elem);
            return doc.OuterXml;
        }

        public string GetMostActiveDay ()
        {
            const string queryString = "select top 1 CONVERT(VARCHAR(10), lh.DateLogin , 103), count(*) as counter " +
                                       "from LoginHistory lh " +
                                       "group by CONVERT(VARCHAR(10), lh.DateLogin , 103) " +
                                       "order by counter desc";
            return this.GetMostActive(queryString);
        }

        public string GetMostActiveMonth()
        {
            const string queryString = "select top 1 MONTH(lh.DateLogin) Month, count(*) a " +
                                       "from LoginHistory lh " +
                                       "group by MONTH(lh.DateLogin)";
            return this.GetMostActive(queryString);
        }

        public string GetMostActiveYear()
        {
            const string queryString = "select top 1 YEAR(lh.DateLogin) Year, count(*) a " +
                                       "from LoginHistory lh " +
                                       "group by YEAR(lh.DateLogin)";
            return this.GetMostActive(queryString);
        }

        public string GetMostActiveDayByUser(int userId)
        {
            string queryString = "select top 1 CONVERT(VARCHAR(10), lh.DateLogin , 103), count(*) as counter " +
                                 "from LoginHistory lh " +
                                 "where lh.User_Id = " + userId +
                                 "group by CONVERT(VARCHAR(10), lh.DateLogin , 103) " +
                                 "order by counter desc";
            return this.GetMostActive(queryString);
        }

        public string GetMostActiveMonthByUser(int userId)
        {
            string queryString = "select top 1 MONTH(lh.DateLogin) Month, count(*) a " +
                                 "from LoginHistory lh " +
                                 "where lh.User_Id = " + userId +
                                 "group by MONTH(lh.DateLogin)";
            return this.GetMostActive(queryString);
        }

        public string GetMostActiveYearByUser(int userId)
        {
            string queryString = "select top 1 YEAR(lh.DateLogin) Year, count(*) a " +
                                 "from LoginHistory lh " +
                                 "where lh.User_Id = " + userId +
                                 "group by YEAR(lh.DateLogin)";
            return this.GetMostActive(queryString);
        }

        private string GetMonths(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString.GetCs());
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(query, connection);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("activeAll");
            doc.AppendChild(root);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    XmlElement monthElem = doc.CreateElement("month");
                    root.AppendChild(monthElem);
                    XmlElement elem = doc.CreateElement("date");
                    elem.InnerText = reader[0].ToString();
                    monthElem.AppendChild(elem);
                    elem = doc.CreateElement("counter");
                    elem.InnerText = reader[1].ToString();
                    monthElem.AppendChild(elem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            connection.Close();
            return doc.OuterXml;
        }

        public string GetAllMonths()
        {
            const string query = "select MONTH(lh.DateLogin) Month, count(*) a " +
                         "from LoginHistory lh " +
                         "group by MONTH(lh.DateLogin)";

            return this.GetMonths(query);
        }

        public string GetAllMonthsByUser(int userId)
        {
            string query = "select MONTH(lh.DateLogin) Month, count(*) a " +
                                 "from LoginHistory lh " +
                                 "where lh.User_Id = " + userId +
                                 "group by MONTH(lh.DateLogin)";

            return this.GetMonths(query);
        }
    }
}
