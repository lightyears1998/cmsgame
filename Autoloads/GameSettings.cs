namespace CMSGame
{
    public record class GameSettings
    {
    }

    public record class BattleSettings : GameSettings
    { }

    public record class VideoSettings : GameSettings
    {
        public bool UseFullScreen = false;
    }

    public record class AudioSettings : GameSettings
    {
        /// <summary>
        /// 音乐音量
        /// </summary>
        public double MusicVolume = 80;

        /// <summary>
        /// 音效音量
        /// </summary>
        public double SoundEffectVolume = 80;
    }
}
