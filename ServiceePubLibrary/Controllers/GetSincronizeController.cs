using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ServiceePubLibraryEntities;
using ServiceePubLibraryEntities.Entities;

namespace ServiceePubLibrary.Controllers
{
    public class GetSincronizeController
    {
        private int _userId;

        private LinkedList<ChapterFav> _chaptersFav;
        private LinkedList<ChapterBookmark> _chaptersBookmark;

        private LinkedList<EpubFav> _epubsFav;
        private LinkedList<EpubBookmark> _epubsBookmark; 

        public GetSincronizeController(int userId)
        {
            this._userId = userId;
            this._chaptersFav = new LinkedList<ChapterFav>();
            this._chaptersBookmark = new LinkedList<ChapterBookmark>();

            this.SetChaptersFav();
            this.SetChaptersBookmark();
            this.SetEpubsFav();
            this.SetEpubsBookmark();
        }

        private void SetChaptersFav()
        {
            ChapterFavEntity cfe = new ChapterFavEntity();
            this._chaptersFav = cfe.GetChapters(this._userId);
        }

        private void SetChaptersBookmark()
        {
            ChapterBookmarkEntity cbe = new ChapterBookmarkEntity();
            this._chaptersBookmark = cbe.GetChapters(this._userId);
        }

        private void SetEpubsFav()
        {
            EpubFavEntity efe = new EpubFavEntity();
            this._epubsFav = efe.GetEpubs(this._userId);
        }

        private void SetEpubsBookmark()
        {
            EpubBookmarkEntity ebe = new EpubBookmarkEntity();
            this._epubsBookmark = ebe.GetEpubs(this._userId);
        }

        public string GetUserInfo()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);
            XmlElement dados = doc.CreateElement("dados");
            doc.AppendChild(dados);
            XmlElement elem = doc.CreateElement("userId");
            elem.InnerText = this._userId.ToString();
            dados.AppendChild(elem);

            XmlElement epubsElem = doc.CreateElement("epubs");
            dados.AppendChild(epubsElem);
            foreach (EpubFav epubFav in this._epubsFav)
            {
                EpubEntity ee = new EpubEntity();
                Epub epub = ee.GetEpub(epubFav.Epub_Id);
                XmlElement epubElem = doc.CreateElement("epub");
                elem = doc.CreateElement("title");
                elem.InnerText = epub.Title;
                epubElem.AppendChild(elem);
                elem = doc.CreateElement("author");
                elem.InnerText = epub.Author;
                epubElem.AppendChild(elem);
                elem = doc.CreateElement("subject");
                elem.InnerText = epub.Subject;
                epubElem.AppendChild(elem);
                elem = doc.CreateElement("fav");
                elem.InnerText = "true";
                epubElem.AppendChild(elem);
                elem = doc.CreateElement("bookmark");
                elem.InnerText = this.EpubIsBookmark(epubFav.Epub_Id).ToString().ToLower();
                epubElem.AppendChild(elem);
                elem = doc.CreateElement("chapters");
                epubElem.AppendChild(elem);
                epubsElem.AppendChild(epubElem);
            }

            foreach (EpubBookmark epubBookmark in this._epubsBookmark)
            {
                EpubEntity ee = new EpubEntity();
                Epub epub = ee.GetEpub(epubBookmark.Epub_Id);
                if (!this.EpubExists(doc,epub))
                {
                    XmlElement epubElem = doc.CreateElement("epub");
                    elem = doc.CreateElement("title");
                    elem.InnerText = epub.Title;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("author");
                    elem.InnerText = epub.Author;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("subject");
                    elem.InnerText = epub.Subject;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("fav");
                    elem.InnerText = "false";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("bookmark");
                    elem.InnerText = "true";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("chapters");
                    epubElem.AppendChild(elem);
                    epubsElem.AppendChild(epubElem);
                }
            }

            foreach (ChapterFav cf in this._chaptersFav)
            {
                ChapterEntity ce = new ChapterEntity();
                Chapter c = ce.GetChapter(cf.Chapter_Id);
                XmlElement chapterElem = doc.CreateElement("chapter");
                elem = doc.CreateElement("title");
                elem.InnerText = c.Title;
                chapterElem.AppendChild(elem);
                elem = doc.CreateElement("fav");
                elem.InnerText = "true";
                chapterElem.AppendChild(elem);
                elem = doc.CreateElement("bookmark");
                elem.InnerText = this.ChapterIsBookmark(cf.Chapter_Id).ToString().ToLower();
                chapterElem.AppendChild(elem);
                XmlNode node = this.GetNodeEpub(doc, c);
                if (node != null)
                {
                    node.AppendChild(chapterElem);
                }
                else
                {
                    EpubEntity ee = new EpubEntity();
                    Epub epub = ee.GetEpub(c.Epub_Id);
                    XmlElement epubElem = doc.CreateElement("epub");
                    elem = doc.CreateElement("title");
                    elem.InnerText = epub.Title;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("author");
                    elem.InnerText = epub.Author;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("subject");
                    elem.InnerText = epub.Subject;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("fav");
                    elem.InnerText = "false";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("bookmark");
                    elem.InnerText = "false";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("chapters");
                    elem.AppendChild(chapterElem);
                    epubElem.AppendChild(elem);
                    epubsElem.AppendChild(epubElem);
                }
            }

            foreach (ChapterBookmark cb in this._chaptersBookmark)
            {
                ChapterEntity ce = new ChapterEntity();
                Chapter c = ce.GetChapter(cb.Chapter_Id);
                XmlElement chapterElem = doc.CreateElement("chapter");
                elem = doc.CreateElement("title");
                elem.InnerText = c.Title;
                chapterElem.AppendChild(elem);
                elem = doc.CreateElement("fav");
                elem.InnerText = "false";
                chapterElem.AppendChild(elem);
                elem = doc.CreateElement("bookmark");
                elem.InnerText = "true";
                chapterElem.AppendChild(elem);
                XmlNode node = this.GetNodeEpub(doc, c);
                if (node != null)
                {
                    node.AppendChild(chapterElem);
                }
                else
                {
                    EpubEntity ee = new EpubEntity();
                    Epub epub = ee.GetEpub(c.Epub_Id);
                    XmlElement epubElem = doc.CreateElement("epub");
                    elem = doc.CreateElement("title");
                    elem.InnerText = epub.Title;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("author");
                    elem.InnerText = epub.Author;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("subject");
                    elem.InnerText = epub.Subject;
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("fav");
                    elem.InnerText = "false";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("bookmark");
                    elem.InnerText = "false";
                    epubElem.AppendChild(elem);
                    elem = doc.CreateElement("chapters");
                    elem.AppendChild(chapterElem);
                    epubElem.AppendChild(elem);
                    epubsElem.AppendChild(epubElem);
                }
            }

            return doc.OuterXml;
        }

        private XmlNode GetNodeEpub(XmlDocument doc,Chapter c)
        {
            EpubEntity ee = new EpubEntity();
            Epub e = ee.GetEpub(c.Epub_Id);
            return doc.SelectSingleNode("/dados/epubs/epub[title = '"+ e.Title +"' and author ='"+ e.Author +"']/chapters");
        }

        private bool EpubExists(XmlDocument doc, Epub e)
        {
            return doc.SelectSingleNode("/dados/epubs/epub[title = '" + e.Title + "' and author ='" + e.Author + "']") != null;
        }

        private bool EpubIsBookmark(int epubId)
        {
            foreach (EpubBookmark eb in this._epubsBookmark)
            {
                if (eb.Epub_Id.Equals(epubId))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ChapterIsBookmark(int chapterId)
        {
            foreach (ChapterBookmark cb in this._chaptersBookmark)
            {
                if (cb.Chapter_Id.Equals(chapterId))
                {
                    return true;
                }
            }
            return false;
            {
                
            }
        }


    }
}
