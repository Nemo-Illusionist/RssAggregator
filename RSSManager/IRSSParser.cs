using System.Collections.Generic;
using DAL.Entites;

namespace RSSManager
{
    public interface IRSSParser
    {
        List<NewsEntites> Parser(string xml, string urlName, RSSTeg teg);
    }
}