using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ServiceePubLibraryEntities.Entities;

namespace ServiceePubLibraryEntities.Controllers
{
    public class SetSincronizeController
    {

        private XmlDocument _doc;
        private int _userId;
        private LinkedList<Epub> _epubs;
        private LinkedList<bool> _epubFav;
        private LinkedList<bool> _epubBookmark;
        private LinkedList<bool> _chapterFav;
        private LinkedList<bool> _chapterBookmark;

        public SetSincronizeController(XmlDocument doc)
        {
            this._doc = doc;
            this._epubs = new LinkedList<Epub>();
            this._epubFav = new LinkedList<bool>();
            this._epubBookmark = new LinkedList<bool>();
            this._chapterFav = new LinkedList<bool>();
            this._chapterBookmark = new LinkedList<bool>();

            this.SetUserFromSincronize();
            this.SetEpubsFromSincronize();

            this.DeleteFavsBookmarks();

            this.SaveInfo();
        }

        public void DeleteFavsBookmarks()
        {
            EpubFavEntity efe = new EpubFavEntity();
            efe.DeleteFavs(this._userId);
            EpubBookmarkEntity ebe = new EpubBookmarkEntity();
            ebe.DeleteBookmarks(this._userId);
            ChapterFavEntity cfe = new ChapterFavEntity();
            cfe.DeleteFavs(this._userId);
            ChapterBookmarkEntity cbe = new ChapterBookmarkEntity();
            cbe.DeleteBookmarks(this._userId);
        }

        public void SaveInfo()
        {
            int contadorEpub = 0;
            int contadorChapter = 0;
            foreach (Epub epub in this._epubs)
            {
                this.RegisterEpub(epub);
                if (this._epubFav.ElementAt(contadorEpub))
                {
                    EpubFavEntity efe = new EpubFavEntity();
                    efe.RegisterEpubFav(this.GetEpubId(epub), this._userId);
                }
                if (this._epubBookmark.ElementAt(contadorEpub))
                {
                    EpubBookmarkEntity ebe = new EpubBookmarkEntity();
                    ebe.RegisterEpubBookmark(this.GetEpubId(epub), this._userId);
                }
                foreach(Chapter chapter in epub.Chapter)
                {
                    chapter.Epub_Id = this.GetEpubId(epub);
                    this.RegisterChapter(chapter);
                    if (this._chapterFav.ElementAt(contadorChapter))
                    {
                        ChapterFavEntity cfe = new ChapterFavEntity();
                        cfe.RegisterChapterFav(this.GetChapterId(chapter), this._userId);
                    }
                    if (this._chapterBookmark.ElementAt(contadorChapter))
                    {
                        ChapterBookmarkEntity cfe = new ChapterBookmarkEntity();
                        cfe.RegisterChapterBookmark(this.GetChapterId(chapter), this._userId);
                    }
                    contadorChapter++;
                }
                contadorEpub++;
            }
        }

        public void RegisterChapter(Chapter c)
        {
            ChapterEntity ce = new ChapterEntity();
            ce.RegisterChapter(c.Epub_Id,c.Title);
        }

        public void RegisterEpub(Epub e)
        {
            EpubEntity epubEntity = new EpubEntity();
            epubEntity.Register(e.Title, e.Author, e.Subject);
        }

        public int GetEpubId(Epub e)
        {
            EpubEntity epubEntity = new EpubEntity();
            return epubEntity.GetId(e.Title, e.Author);
        }

        public int GetChapterId(Chapter c)
        {
            ChapterEntity chapterEntity = new ChapterEntity();
            return chapterEntity.GetId(c.Epub_Id,c.Title);
        }

        public void SetEpubsFromSincronize()
        {
            XmlNodeList epubs = this._doc.SelectNodes("/dados/epubs/epub");
            foreach (XmlNode e in epubs)
            {
                XmlNode node = e.SelectSingleNode("title");
                string title = node.InnerText;
                node = e.SelectSingleNode("author");
                string author = node.InnerText;
                node = e.SelectSingleNode("subject");
                string subject = node.InnerText;
                node = e.SelectSingleNode("fav");
                bool fav = Convert.ToBoolean(node.InnerText);
                node = e.SelectSingleNode("bookmark");
                bool bookmark = Convert.ToBoolean(node.InnerText);
                Epub ep = new Epub();
                ep.Title = title;
                ep.Author = author;
                ep.Subject = subject;
                this._epubFav.AddLast(fav);
                this._epubBookmark.AddLast(bookmark);
                XmlNodeList chapters = e.SelectNodes("chapters/chapter");
                foreach (XmlNode c in chapters)
                {
                    XmlNode elem = c.SelectSingleNode("title");
                    String t = elem.InnerText;
                    elem = c.SelectSingleNode("fav");
                    bool f = Convert.ToBoolean(elem.InnerText);
                    elem = c.SelectSingleNode("bookmark");
                    bool b = Convert.ToBoolean(elem.InnerText);
                    Chapter ch = new Chapter();
                    ch.Title = t;
                    this._chapterFav.AddLast(f);
                    this._chapterBookmark.AddLast(b);
                    ep.Chapter.Add(ch);
                }
                this._epubs.AddLast(ep);
            }
        }


        public void SetUserFromSincronize()
        {
            XmlNode node = this._doc.SelectSingleNode("/dados/userId");
            this._userId = Convert.ToInt32(node.InnerText);
        }
    }
}
