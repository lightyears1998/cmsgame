namespace CMSGame
{
    public record class GameSettings
    {
    }

    public record class BattleSettings : GameSettings
    { }

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
        public string LastRunVersion { set; get; } = "";

        public bool ShowChangelogAtLandingScene { set; get; } = true;
    }
}
