namespace CMSGame
{
    public partial class SettingsMenu : VBoxContainer
    {
        public GameSettings Settings;

        public CheckBox PauseBattleWhenCharacterIsSelectedCheckBox;

        public override void _Ready()
        {
            InitializeComponents();

            PauseBattleWhenCharacterIsSelectedCheckBox.ButtonPressed = Settings.BattleSettings.PauseBattleWhenCharacterIsSelected;
        }

        private void InitializeComponents()
        {
            Settings = GetNode<GameSettings>("/root/GameSettings");
            PauseBattleWhenCharacterIsSelectedCheckBox = GetNode<CheckBox>($"%{nameof(PauseBattleWhenCharacterIsSelectedCheckBox)}");
        }

        public void On_PauseBattleWhenCharacterIsSelectedCheckBox_Toggled(bool pressed)
        {
            Settings.BattleSettings.PauseBattleWhenCharacterIsSelected = pressed;
        }
    }
}
