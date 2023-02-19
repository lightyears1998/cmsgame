namespace CMSGame
{
    public static class FileHelper
    {
        public static string GodotPathToSystemPath(string godotPath)
        {
            return ProjectSettings.GlobalizePath(godotPath);
        }
    }
}
