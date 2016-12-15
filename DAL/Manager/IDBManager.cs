using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Entites;

namespace DAL.Manager
{
    public interface IDBManager
    {
        void AddEntites<T>(T t);
        void AddEntites<T>(IList<T> t);
        void CreateTable();
        List<NewsEntites> GetNews(Expression<Func<NewsEntites, bool>> func);
        UrlEntites GetUrl(string key);
    }
}