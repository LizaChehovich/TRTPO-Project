namespace RSS_Reader.Model
{
    public class News
    {
        public string Title { get; }
        public string Link { get; }
        public string Description { get; }
        public string Category { get; }
        public string PublicationDate { get; }

        public News(string title, string link, string description, string category, string publicationDate)
        {
            Title = title;
            Link = link;
            Description = description;
            Category = category;
            PublicationDate = publicationDate;
        }
    }
}
