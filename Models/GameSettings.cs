namespace CMSGame.Models
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
        /// 音乐音量
        /// </summary>
        public double MusicVolume { set; get; } = 80;

        /// <summary>
        /// 音效音量
        /// </summary>
        public double SoundEffectVolume { set; get; } = 80;
    }
}
