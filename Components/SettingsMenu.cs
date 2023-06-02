namespace CMSGame
{
    public partial class SettingsMenu : VBoxContainer
    {
        public GameSettings? Settings;

        public CheckBox? PauseBattleWhenCharacterIsSelectedCheckBox;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettings));
            this.GetUniqueNode(ref PauseBattleWhenCharacterIsSelectedCheckBox, nameof(PauseBattleWhenCharacterIsSelectedCheckBox));
        }

        public void On_PauseBattleWhenCharacterIsSelectedCheckBox_Toggled(bool pressed)
        {
        }
    }
}
