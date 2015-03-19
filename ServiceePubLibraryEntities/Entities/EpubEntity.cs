using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceePubLibraryEntities.Exceptions;

namespace ServiceePubLibraryEntities.Entities
{
    public class EpubEntity
    {

        private Model_Service_ePub_LibraryContainer context;

        public EpubEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void Register(string title, string author,string subject)
        {
            try
            {
                Epub e = new Epub();
                e.Title = title;
                e.Author = author;
                e.Subject = subject;
                this.context.Epub.Add(e);
                this.context.SaveChanges();
            }
            catch (DbUpdateException due)
            {
            }
        }

        public void SetEpubFav(string title, string author, int idUser)
        {
            try
            {
                Epub e = this.GetEpub(title,author);
                EpubFav ef = new EpubFav();
                ef.User_Id = idUser;
                ef.Epub_Id = e.Id;
                this.context.EpubFav.Add(ef);
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
            catch (Exception)
            {      
            }
            
        }

        public Epub GetEpub(string title, string author)
        {
            try
            {
                return this.context.Epub.SqlQuery("select * from Epub where Title = "+title+" AND Author = "+author).ToList().First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetId(string title, string author)
        {
            int i = this.context.Epub.SqlQuery("select * from [Epub] where [Title] = '" + title + "' AND [Author] = '" + author + "'").ToList().First().Id;
            return i;
        }

        public Epub GetEpub(int epubId)
        {
            
            return this.context.Epub.Find(epubId);
        }
    }
}
