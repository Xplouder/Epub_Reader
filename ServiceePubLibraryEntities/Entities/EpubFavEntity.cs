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
    public class EpubFavEntity
    {
        private Model_Service_ePub_LibraryContainer context;

        public EpubFavEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterEpubFav(int epubId, int userId)
        {
            try
            {
                EpubFav ef = new EpubFav();
                ef.Epub_Id = epubId;
                ef.User_Id = userId;
                this.context.EpubFav.Add(ef);
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public void DeleteFavs(int userId)
        {
            try
            {
                foreach (EpubFav ef in this.GetEpubs(userId))
                    this.context.EpubFav.Remove(ef);
                
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public LinkedList<EpubFav> GetEpubs(int userId)
        {
            return new LinkedList<EpubFav>(this.context.EpubFav.SqlQuery("select * from [EpubFav] where [User_Id] = "+userId));
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
               "from Epub e, EpubFav ef " +
               "where e.Id = ef.Epub_Id " + 
               "group by e.Title " + 
               "order by counter DESC";

            return this.GetTop(query);
        }

        public string GetTop5(int userId)
        {
            string query =
               "select top 5 e.Title, count(*) as counter " +
               "from Epub e, EpubFav ef " +
               "where e.Id = ef.Epub_Id AND ef.User_id = " + userId +
               " group by e.Title " +
               "order by counter DESC";

            return this.GetTop(query);
        }
    }
}
