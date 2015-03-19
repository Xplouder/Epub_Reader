using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ServiceePubLibraryEntities.Entities
{
    public class ChapterFavEntity
    {
        private Model_Service_ePub_LibraryContainer context;

        public ChapterFavEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterChapterFav(int chapterId, int userId)
        {
            try
            {
                ChapterFav cf = new ChapterFav();
                cf.User_Id = userId;
                cf.Chapter_Id = chapterId;
                this.context.ChapterFav.Add(cf);
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
                foreach (ChapterFav cf in this.GetChapters(userId))
                    this.context.ChapterFav.Remove(cf);

                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public LinkedList<ChapterFav> GetChapters(int userId)
        {
            return new LinkedList<ChapterFav>(this.context.ChapterFav.SqlQuery("select * from [ChapterFav] where [User_Id] = " + userId).ToList());
        }

        public string GetTopFive(DateTime dt)
        {         

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT title from [Epub] where Id = @userId";


            SqlConnection connection = new SqlConnection(ConnectionString.GetCs());
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@userId",1);

            string test = "";

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    test += reader[0];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            connection.Close();
            return test;
        }

    }
}
