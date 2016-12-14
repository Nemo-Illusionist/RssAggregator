using SQLite;

namespace DAL.Entites
{
    public class UrlEntites
    {

        [PrimaryKey]
        public string UrlName { get; set; }

        [NotNull, Unique]
        public string Url { get; set; }
    }
}