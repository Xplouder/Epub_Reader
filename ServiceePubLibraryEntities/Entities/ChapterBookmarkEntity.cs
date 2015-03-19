using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceePubLibraryEntities.Entities
{
    public class ChapterBookmarkEntity
    {
        private Model_Service_ePub_LibraryContainer context;

        public ChapterBookmarkEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public void RegisterChapterBookmark(int chapterId, int userId)
        {
            try
            {
                ChapterBookmark cb = new ChapterBookmark();
                cb.User_Id = userId;
                cb.Chapter_Id = chapterId;
                this.context.ChapterBookmark.Add(cb);
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
                foreach (ChapterBookmark cb in this.GetChapters(userId))
                    this.context.ChapterBookmark.Remove(cb);

                this.context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
        }

        public LinkedList<ChapterBookmark> GetChapters(int userId)
        {
            return new LinkedList<ChapterBookmark>(this.context.ChapterBookmark.SqlQuery("select * from [ChapterBookmark] where [User_Id] = "+userId));
        }
    }
}
