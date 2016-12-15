using System;
using System.IO;
using System.Net;

namespace RSS
{
    public class RSSRequest : IRSSRequest
    {
        public string Request(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    throw new ArgumentException(nameof(url));
                string news;
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                Stream stream = request.GetResponse().GetResponseStream();
                using (StreamReader streamReader = new StreamReader(stream))
                    news = streamReader.ReadToEnd();
                return news;
            }
            catch 
            {
                throw new Exception("Неудалось загрузить данные");
            }
        }
    }
}