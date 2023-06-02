using Newtonsoft.Json;

namespace CMSGame
{
    /// <summary>
    /// 游戏设置持久化节点
    ///
    /// 在游戏开始时载入用户设置，并在游戏关闭时保存用户设置。
    /// </summary>
    public partial class GameSettingsNode : Node
    {
        protected Dictionary<Type, GameSettings> CurrentSettings = new();

        protected Dictionary<Type, GameSettings> OriginalSettings = new();

        protected Dictionary<Type, string> SettingsPaths = new();

        public BattleSettings BattleSettings => GetSettings<BattleSettings>();

        public VideoSettings VideoSettings => GetSettings<VideoSettings>();

        public AudioSettings AudioSettings => GetSettings<AudioSettings>();

        public GameSettingsNode()
        {
            RegisterAllSettings();
        }

        public override void _Ready()
        {
            MakeDirectories();
            LoadAllSettings();
        }

        protected void RegisterAllSettings()
        {
            RegisterSettings<BattleSettings>("BattleSettings.json");
            RegisterSettings<VideoSettings>("VideoSettings.json");
            RegisterSettings<AudioSettings>("AudioSettings.json");
        }

        protected void RegisterSettings<TSettings>(string filename) where TSettings : GameSettings, new()
        {
            var defaultSettings = new TSettings();
            CurrentSettings.Add(typeof(TSettings), defaultSettings);
            SettingsPaths.Add(typeof(TSettings), new GodotPath($"user://Settings/{filename}"));
        }

        protected void LoadAllSettings()
        {
            foreach (var settingsType in SettingsPaths.Keys)
            {
                LoadSettings(settingsType);
            }
        }

        public override void _ExitTree()
        {
            foreach (var settingsType in SettingsPaths.Keys)
            {
                if (!OriginalSettings.ContainsKey(settingsType) || OriginalSettings[settingsType] != CurrentSettings[settingsType])
                {
                    SaveSettings(settingsType);
                }
            }
        }

        private static void MakeDirectories()
        {
            DirAccess.MakeDirRecursiveAbsolute("user://Settings/");
        }

        private void LoadSettings(Type settingsType)
        {
            string settingsText = ReadFileAsString(SettingsPaths[settingsType]);
            var settings = JsonConvert.DeserializeObject(settingsText, settingsType);
            if (settings != null)
            {
                OriginalSettings[settingsType] = (GameSettings)settings;
                CurrentSettings[settingsType] = (GameSettings)settings;
            }
        }

        public TSettings GetSettings<TSettings>() where TSettings : GameSettings, new()
        {
            return (TSettings)CurrentSettings[typeof(TSettings)];
        }

        private static string ReadFileAsString(string path)
        {
            if (FileAccess.FileExists(path))
            {
                using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
                return file.GetAsText();
            }
            return "null";
        }

        private void SaveSettings(Type settingsType)
        {
            string settingsText = JsonConvert.SerializeObject(CurrentSettings[settingsType]);
            using var file = FileAccess.Open(SettingsPaths[settingsType], FileAccess.ModeFlags.Write);
            file.StoreString(settingsText);
        }
    }
}
