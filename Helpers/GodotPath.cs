namespace CMSGame
{
    public class GodotPath
    {
        private readonly string _path = string.Empty;

        public GodotPath(string godotPath)
        {
            if (godotPath.StartsWith("user://"))
            {
                _path = ProjectSettings.GlobalizePath(godotPath);
            }
            else
            {
                _path = godotPath;
            }
        }

        public override string ToString() => _path;

        public static implicit operator string(GodotPath g) => g.ToString();
    }
}
