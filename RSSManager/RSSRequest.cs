using System;
using System.IO;
using System.Net;

namespace RSSManager
{
    public class RssRequest
    {
        public string Request(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException(nameof(url));
            string news;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            using (StreamReader stream = new StreamReader(request.GetResponse().GetResponseStream()))
                news = stream.ReadToEnd();
            return news;
        }
    }
}