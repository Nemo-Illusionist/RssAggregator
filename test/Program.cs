using DAL.Entites;
using RSS;

namespace test
{
    class Program
    {
        static void Main()
        {
            RSSParser parser = new RSSParser();
            RSSTeg teg = new RSSTeg();
            UrlEntites url = new UrlEntites
            {
                Url = "https://habrahabr.ru/rss/feed/posts/6266e7ec4301addaf92d10eb212b4546/",
                UrlName = "habr"
            };
            string s = Properties.Resources.RSSHabr;
            parser.Parser(s, url.UrlName,teg);
        }
    }
}
