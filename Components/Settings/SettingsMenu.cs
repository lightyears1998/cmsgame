namespace CMSGame
{
    public partial class SettingsMenu : TabContainer
    {
        private static bool InDevelopment => OS.HasFeature("debug") || OS.HasFeature("editor");

        public GameSettingsNode? Settings;

        public Control? BattleSettingsMenu;

        public Control? VideoSettingsMenu;

        public Control? AudioSettingsMenu;

        public Control? DeveloperOptionsMenu;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettingsNode));

            this.GetUniqueNode(ref BattleSettingsMenu, nameof(BattleSettingsMenu));
            this.GetUniqueNode(ref VideoSettingsMenu, nameof(VideoSettingsMenu));
            this.GetUniqueNode(ref AudioSettingsMenu, nameof(AudioSettingsMenu));
            this.GetUniqueNode(ref DeveloperOptionsMenu, nameof(DeveloperOptionsMenu));

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
