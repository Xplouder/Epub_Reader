using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceePubLibraryEntities.Entities
{
    public class ChapterEntity
    {
        private Model_Service_ePub_LibraryContainer context;

        public ChapterEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterChapter(int epubId, string title)
        {
            try
            {
                Chapter c = new Chapter();
                c.Epub_Id = epubId;
                c.Title = title;
                this.context.Chapter.Add(c);
                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public int GetId(int epubId, string title)
        {
            int i = this.context.Chapter.SqlQuery("select * from [Chapter] where [Title] = '" + title + "' AND [Epub_Id] = " + epubId).ToList().First().Id;
            return i;
        }

        public Chapter GetChapter(int chapterId)
        {
            return this.context.Chapter.Find(chapterId);
        }
    }
}
