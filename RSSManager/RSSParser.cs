using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DAL.Entites;

namespace RSSManager
{
    public class RSSParser : IRSSParser
    {
        public List<NewsEntites> Parser(string xml, string urlName, RSSTeg teg)
        {
            if (string.IsNullOrEmpty(xml) || string.IsNullOrEmpty(urlName) || teg == null)
                throw new ArgumentNullException();
            XElement dok = XDocument.Parse(xml).Root;
            if (dok == null)
                throw new Exception("Неудалось распарсить XML");
            return dok.Elements(teg.Item)
                .Select(el => new NewsEntites
                {
                    UrlName = urlName,
                    Title = el.Attribute(teg.Title).Value,
                    Description = el.Attribute(teg.Description).Value,
                }).ToList();
        }
    }
}