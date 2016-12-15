namespace RSSManager
{
    public class RSSTeg
    {
        public string Item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public RSSTeg()
        {
            Item = "item";
            Title = "title";
            Description = "description";
        }

        public RSSTeg(string item, string title, string description)
        {
            Item = item;
            Title = title;
            Description = description;
        }
    }
}