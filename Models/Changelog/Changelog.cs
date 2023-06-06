namespace CMSGame
{
    internal record class Changelog
    {
        public DateOnly? Date { set; get; }

        public string Version { set; get; }

        public string Description { set; get; }

        public Changelog(DateOnly? date, string version, string description)
        {
            Date = date;
            Version = version;
            Description = description;
        }
    }
}
