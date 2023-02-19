using System.Runtime.CompilerServices;

namespace CMSGame
{
    public class GodotPath
    {
        private readonly string _path = string.Empty;

        public GodotPath(string godotPath)
        {
            _path = ProjectSettings.GlobalizePath(godotPath);
        }

        public override string ToString() => _path;

        public static implicit operator string(GodotPath g) => g.ToString();
    }
}
