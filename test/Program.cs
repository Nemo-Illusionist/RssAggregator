using System;
using DAL.Entites;
using DAL.Manager;

namespace test
{
    class Program
    {
        static void Main()
        {
            new Program().lol();
        }

        public void lol()
        {
            try
            {
                DBManager db = new DBManager();
                db.CreateTable();
                UrlEntites url = new UrlEntites
                {
                    UrlName = "habr2",
                    Url = "https://habrahabr.ru/rss/feed/posts/6266e7ec4301addaf92d10eb212b4546/"
                };
                UrlEntites url1 = new UrlEntites
                {
                    UrlName = "habr3",
                    Url = "https://habrahabr.ru/rss/feed/posts/6266e7ec4301addaf92d10eb212b4546/"
                };
                db.AddEntites(url);
                db.AddEntites(url1);
                UrlEntites s = db.GetUrl("habr");
                Console.WriteLine(s.UrlName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
