namespace CMSGame
{
    public partial class SettingsMenu : VBoxContainer
    {
        private GameSettings _settings;

        private CheckBox _checkBoxPauseBattleWhenCharacterIsSelected;

        public override void _Ready()
        {
            InitializeComponents();

            _checkBoxPauseBattleWhenCharacterIsSelected.ButtonPressed = _settings.BattleSettings.PauseBattleWhenCharacterIsSelected;
        }

        private void InitializeComponents()
        {
            _settings = GetNode<GameSettings>("/root/GameSettings");
            _checkBoxPauseBattleWhenCharacterIsSelected = GetNode<CheckBox>("%CheckBoxPauseBattleWhenCharacterIsSelected");
        }

        public void On_CheckBoxPauseBattleWhenCharacterIsSelected_Toggled(bool pressed)
        {
            _settings.BattleSettings.PauseBattleWhenCharacterIsSelected = pressed;
        }
    }
}
