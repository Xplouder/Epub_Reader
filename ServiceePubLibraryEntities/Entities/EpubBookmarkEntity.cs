using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ServiceePubLibraryEntities.Entities
{
    public class EpubBookmarkEntity
    {
        private Model_Service_ePub_LibraryContainer context;

        public EpubBookmarkEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterEpubBookmark(int epubId, int userId)
        {
            try
            {
                EpubBookmark eb = new EpubBookmark();
                eb.Epub_Id = epubId;
                eb.User_Id = userId;
                this.context.EpubBookmark.Add(eb);
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public void DeleteBookmarks(int userId)
        {
            try
            {
                foreach (EpubBookmark eb in this.GetEpubs(userId))
                    this.context.EpubBookmark.Remove(eb);

                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public LinkedList<EpubBookmark> GetEpubs(int userId)
        {
            return new LinkedList<EpubBookmark>(this.context.EpubBookmark.SqlQuery("select * from [EpubBookmark] where [User_Id] ="+userId));
        }

        private string GetTop(string query)
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

        public string GetTop5()
        {
            const string query =
               "select top 5 e.Title, count(*) as counter " +
               "from Epub e, EpubBookmark ef " +
               "where e.Id = ef.Epub_Id " +
               "group by e.Title " +
               "order by counter DESC";

            return this.GetTop(query);
        }

        public string GetTop5(int userId)
        {
            string query =
               "select top 5 e.Title, count(*) as counter " +
               "from Epub e, EpubBookmark ef " +
               "where e.Id = ef.Epub_Id AND ef.User_id = " + userId +
               " group by e.Title " +
               "order by counter DESC";

            return this.GetTop(query);
        }
    }
}
