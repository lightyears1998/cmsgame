namespace CMSGame
{
    public partial class SettingsMenu : TabContainer
    {
        public GameSettings? Settings;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettings));
        }
    }
}
