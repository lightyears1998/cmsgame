namespace CMSGame
{
    internal class GodotPath
    {
        private readonly string _path = string.Empty;

        public GodotPath(string godotPath)
        {
            _path = godotPath;
            if (_path.StartsWith("user://"))
            {
                _path = ProjectSettings.GlobalizePath(_path);
            }
        }

        public override string ToString() => _path;

        public static implicit operator string(GodotPath g) => g.ToString();
    }
}
