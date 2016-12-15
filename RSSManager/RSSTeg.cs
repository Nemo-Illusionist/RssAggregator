namespace RSS
{
    public class RSSTeg
    {
        public string Item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Channel { get; set; }

        public RSSTeg()
        {
            Item = "item";
            Title = "title";
            Description = "description";
            Date = "pubDate";
            Channel = "channel";
        }
    }
}