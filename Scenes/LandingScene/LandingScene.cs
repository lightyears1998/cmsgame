namespace CMSGame
{
    [SceneTree]
    internal partial class LandingScene : Control, IBackgroundMusicScene
    {
        public BackgroundMusicPlayer BackgroundMusicPlayer = BackgroundMusicPlayer.Current;

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
    }
}
