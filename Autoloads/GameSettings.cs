using Newtonsoft.Json;

namespace CMSGame
{
    public partial class GameSettings : Node
    {
        public BattleSettings BattleSettings;

        protected string BattleSettingsSavePath = new GodotPath("user://Settings/BattleSettings.json");

        public override void _Ready()
        {
            MakeDirectories();
            BattleSettings = GetSettings<BattleSettings>(BattleSettingsSavePath);
        }

        public override void _ExitTree()
        {
            SaveSettings(BattleSettingsSavePath);
        }

        private void MakeDirectories()
        {
            DirAccess.MakeDirRecursiveAbsolute("user://Settings/");
        }

        private SettingsType GetSettings<SettingsType>(string path) where SettingsType : new()
        {
            string settings_text = ReadFileAsString(path);
            var settings = JsonConvert.DeserializeObject<SettingsType>(settings_text) ?? new SettingsType();
            return settings;
        }

        private string ReadFileAsString(string path)
        {
            if (FileAccess.FileExists(path))
            {
                using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
                return file.GetAsText();
            }
            return "null";
        }

        private void SaveSettings(string path)
        {
            string settings_text = JsonConvert.SerializeObject(BattleSettings);
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
            file.StoreString(settings_text);
        }
    }

    public class SettingsBase
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class BattleSettings : SettingsBase
    {
        public bool PauseBattleWhenCharacterIsSelected = true;
    }
}
