using SQLite;

namespace DAL
{
    public class DBManager
    {
        private readonly SQLiteAsyncConnection _db;

        public DBManager()
        {
            _db = new SQLiteAsyncConnection(DBConstant.Name);
        }

        public string GetUrl(string key)
        {
            return 
        }

    }
}