namespace CMSGame
{
    internal static class Environment
    {
        public static bool InDevelopment => OS.HasFeature("debug") || OS.HasFeature("editor");
    }
}
