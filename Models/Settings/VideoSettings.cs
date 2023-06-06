namespace CMSGame
{
    public record class VideoSettings : GameSettings
    {
        /// <summary>
        /// 是否全屏
        /// </summary>
        public bool UseFullScreen { set; get; } = false;
    }
}
