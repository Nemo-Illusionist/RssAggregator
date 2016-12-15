using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entites;

namespace DAL.Manager
{
    public interface IDBManager
    {
        Task AddEntites<T>(T t);
        Task AddEntites<T>(IList<T> t);
        Task CreateTable();
        Task<List<NewsEntites>> GetNews(Expression<Func<NewsEntites, bool>> func);
        Task<UrlEntites> GetUrl(string key);
    }
}