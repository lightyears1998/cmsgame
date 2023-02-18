namespace CMSGame
{
    public partial class PauseMenu : Control
    {
        private GameSettings _settings;

        public override void _Ready()
        {
            _settings = GetNode<GameSettings>("/root/GameSettings");
            GetNode<CheckBox>("%CheckBoxPauseBattleWhenCharacterIsSelected").ToggleMode = _settings.PauseBattleWhenCharacterIsSelected;
        }

        public void On_CheckBoxPauseBattleWhenCharacterIsSelected_Toggled()
        {
            _settings.PauseBattleWhenCharacterIsSelected = false;
        }
    }

}
