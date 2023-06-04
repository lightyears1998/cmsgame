namespace CMSGame
{
    internal static class FileHelper
    {
        public static string GodotPathToSystemPath(string godotPath)
        {
            return ProjectSettings.GlobalizePath(godotPath);
        }
    }
}
