namespace CMSGame
{
    internal static class Environment
    {
        public static bool InDevelopment => OS.HasFeature("debug") || OS.HasFeature("editor");

        public static readonly string ItchHomePage = "https://lightyears1998.itch.io/cmsgame";

        public static readonly string GitHubHomePage = "https://github.com/lightyears1998/cmsgame";
    }
}
