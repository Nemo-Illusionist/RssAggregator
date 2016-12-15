using SQLite;

namespace DAL.Entites
{
    public class UrlEntites
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, Unique]
        public string UrlName { get; set; }

        [NotNull]
        public string Url { get; set; }
    }
}