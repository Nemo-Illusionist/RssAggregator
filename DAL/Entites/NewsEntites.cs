using SQLite;

namespace DAL.Entites
{
    public class NewsEntites
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [NotNull]
        public string UrlName { get; set; }

        [NotNull]
        public string Title { get; set; }

        [NotNull]
        public string Description { get; set; }
    }
}