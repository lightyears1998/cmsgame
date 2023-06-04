namespace CMSGame
{
    [SceneTree]
    internal partial class LandingScene : Control, IBackgroundMusicScene
    {
        [Export]
        public AudioStream BackgroundMusic { get; set; } = new();

        public void On_StartButton_Pressed()
        {
            GetTree().ChangeSceneToFile("res://Scenes/BattleScene/BattleScene.tscn");
        }

        public void On_SettingsPopupButton_Pressed()
        {
            SettingsMenuPopup.PopupCentered();
        }

        public void On_QuitButton_Pressed()
        {
            GetTree().Quit();
        }

        public void On_ChangelogToggleButton_Pressed()
        {
            ChangelogContainer.Visible = !ChangelogContainer.Visible;
        }
    }
}
