namespace CMSGame
{
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
