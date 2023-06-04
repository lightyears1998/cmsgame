namespace CMSGame
{
    [SceneTree]
    internal partial class SettingsMenu : TabContainer
    {
        private static bool InDevelopment => OS.HasFeature("debug") || OS.HasFeature("editor");

        public GameSettingsNode? Settings;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettingsNode));

            this.SetTabTitle(GetTabIdxFromControl(BattleSettingsMenu), "战斗设置");
            this.SetTabTitle(GetTabIdxFromControl(VideoSettingsMenu), "视频设置");
            this.SetTabTitle(GetTabIdxFromControl(AudioSettingsMenu), "音频设置");
            this.SetTabTitle(GetTabIdxFromControl(DeveloperOptionsMenu), "开发者菜单");

            if (!InDevelopment)
            {
                RemoveChild(DeveloperOptionsMenu);
            }
        }
    }
}
