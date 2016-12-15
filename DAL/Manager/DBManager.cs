using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Entites;
using SQLite;

namespace DAL.Manager
{
    public class DBManager : IDBManager
    {
        private readonly string _dbName = Environment.CurrentDirectory + "\\RSS.sqlite";

        private SQLiteConnection _db;

        public void CreateTable()
        {
            Injection(() => _db.CreateTable<UrlEntites>() + _db.CreateTable<NewsEntites>());
        }

        public List<NewsEntites> GetNews(Expression<Func<NewsEntites, bool>> func)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func));
            return Injection(() => _db.Table<NewsEntites>().Where(func).ToList());
        }

        public UrlEntites GetUrl(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            return Injection(() => _db.Table<UrlEntites>().First(x => x.UrlName == key));  
        }

        public void AddEntites<T>(T t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            try
            {
                Injection(() => _db.Insert(t));
            }
            catch (SQLiteException)
            {
                throw new Exception("попытка добавить в базу ещё один уникальный элемент");
            }
        }

        public void AddEntites<T>(IList<T> t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));
            try
            {
                Injection(() => _db.InsertAll(t)); 
            }
            catch (SQLiteException)
            {
                throw new Exception("попытка добавить в базу ещё один уникальный элемент");
            }
        }

        private T Injection<T>(Func<T> func)
        {
            T t;
            using (_db = new SQLiteConnection(_dbName))
            {
                t = func();
            }
            return t;
        }
    }
}