namespace CMSGame
{
    internal record class Changelog
    {
        public DateOnly? Date { set; get; }

        public string Version { set; get; } = string.Empty;

        public string Description { set; get; } = string.Empty;
    }
}
