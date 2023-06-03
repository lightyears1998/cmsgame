namespace CMSGame
{
    internal record class Changelog
    {
        public DateOnly? Date { set; get; }

        public string Title { set; get; }

        public string Description { set; get; }

        public Changelog(DateOnly? date, string title, string description)
        {
            Date = date;
            Title = title;
            Description = description;
        }
    }
}
