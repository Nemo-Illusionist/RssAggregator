using System.Collections.Generic;
using DAL.Entites;

namespace RSS
{
    public interface IRSSParser
    {
        List<NewsEntites> Parser(string xml, string urlName, RSSTeg teg);
    }
}