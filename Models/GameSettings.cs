namespace CMSGame
{
    public record class GameSettings
    {
    }

    public record class BattleSettings : GameSettings
    {
        public bool SkipNonPlayerTurn { set; get; } = false;
    }

    public record class VideoSettings : GameSettings
    {
        public bool UseFullScreen { set; get; } = false;
    }

    public record class AudioSettings : GameSettings
    {
        /// <summary>
        /// 主音量
        /// </summary>
        public double MasterVolume { set; get; } = 0.8;

        /// <summary>
        /// 音乐音量
        /// </summary>
        public double MusicVolume { set; get; } = 0.8;

        /// <summary>
        /// 音效音量
        /// </summary>
        public double SoundEffectVolume { set; get; } = 0.8;
    }

    public record class MiscSettings : GameSettings
    {
        /// <summary>
        /// 上次运行的游戏版本
        /// </summary>
        public string LastRunVersion { set; get; } = "";

        /// <summary>
        /// 是否在着陆页显示更新日志
        /// </summary>
        public bool ShowChangelogAtLandingScene { set; get; } = true;
    }
}
