namespace CMSGame
{
    public partial class SettingsMenu : TabContainer
    {
        private bool _inDevelopment => OS.HasFeature("debug") || OS.HasFeature("editor");

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

            DeveloperOptionsMenu!.Visible = _inDevelopment;
        }
    }
}
