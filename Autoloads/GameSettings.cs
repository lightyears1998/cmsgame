using Newtonsoft.Json;

namespace CMSGame
{
    /// <summary>
    /// 游戏设置持久化
    ///
    /// TODO 添加 VideoSettings 并重构
    /// </summary>
    public partial class GameSettings : Node
    {
        public BattleSettings? OriginalBattleSettings;

        public BattleSettings BattleSettings { set; get; } = new();

        protected string BattleSettingsSavePath = new GodotPath("user://Settings/BattleSettings.json");

        public override void _Ready()
        {
            MakeDirectories();

            OriginalBattleSettings = GetSettings<BattleSettings>(BattleSettingsSavePath);
            BattleSettings = OriginalBattleSettings with { };
        }

        public override void _ExitTree()
        {
            if (BattleSettings != OriginalBattleSettings)
            {
                SaveSettings(BattleSettingsSavePath);
            }
        }

        private void MakeDirectories()
        {
            DirAccess.MakeDirRecursiveAbsolute("user://Settings/");
        }

        private TSettings GetSettings<TSettings>(string path)
            where TSettings : SettingsBase, new()
        {
            string settings_text = ReadFileAsString(path);
            var settings = JsonConvert.DeserializeObject<TSettings>(settings_text) ?? new TSettings();
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

    public record class SettingsBase
    {
    }

    public record class BattleSettings : SettingsBase
    {
        public bool PauseBattleWhenCharacterIsSelected = true;
    }
}
