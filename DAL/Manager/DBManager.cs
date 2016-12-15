using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Entites;
using SQLite;

namespace DAL.Manager
{
    public class DBManager : IDBManager
    {
        private readonly SQLiteAsyncConnection _db;

        public DBManager()
        {
            _db = new SQLiteAsyncConnection(DBConstant.Name);
            _db.CreateTableAsync<UrlEntites>();
            _db.CreateTableAsync<NewsEntites>();
        }

        public async Task<List<NewsEntites>> GetNews(Expression<Func<NewsEntites, bool>> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            return await _db.Table<NewsEntites>().Where(func).ToListAsync();
        }

        public async Task<UrlEntites> GetUrl(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            return await _db.Table<UrlEntites>().Where(x => x.UrlName == key).FirstAsync();
        }

        public async Task AddEntites<T>(T t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            await _db.InsertAsync(t);
        }

        public async Task AddEntites<T>(IList<T> t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            await _db.InsertAllAsync(t);
        }

    }
}