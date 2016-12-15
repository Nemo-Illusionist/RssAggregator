using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DAL.Entites;

namespace RSS
{
    public class RSSParser : IRSSParser
    {
        public List<NewsEntites> Parser(string xml, string urlName, RSSTeg teg)
        {
            if (string.IsNullOrEmpty(xml) || string.IsNullOrEmpty(urlName) || teg == null)
                throw new ArgumentNullException();
            XElement dok = XDocument.Parse(xml).Root;
            NotNull(dok);
            dok = dok.Element(teg.Channel);
            NotNull(dok);
            return dok.Elements(teg.Item).Select(item => new NewsEntites
            {
                UrlName = urlName,
                Title = GetTegValue(item, teg.Title),
                Description = GetTegValue(item, teg.Description),
                Date = DateTime.Parse(GetTegValue(item, teg.Date))
            }).ToList();
        }

        private string GetTegValue(XElement item, string teg)
        {
            XElement tegElement = item.Element(teg);
            NotNull(tegElement);
            XNode tegNode = tegElement.FirstNode;
            string tegValue = tegNode.ToString();
            try
            {
                tegValue = ((XCData)tegNode).Value;
            }
            catch (InvalidCastException)
            {
            }
            return tegValue;
        }

        private void NotNull(XElement element)
        {
            if (element == null)
                throw new Exception("Неудалось распарсить XML");
        }
    }
}