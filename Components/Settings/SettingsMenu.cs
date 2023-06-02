namespace CMSGame
{
    public partial class SettingsMenu : TabContainer
    {
        public GameSettingsNode? Settings;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettingsNode));
        }
    }
}
