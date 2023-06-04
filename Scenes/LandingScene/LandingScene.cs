namespace CMSGame
{
    [SceneTree]
    public partial class LandingScene : Control
    {
        public AudioStreamPlayer? BackgroundMusicPlayer;

        [Export]
        public AudioStream BackgroundMusic = new();

        public override void _Ready()
        {
            this.GetAutoloadNode(ref BackgroundMusicPlayer, nameof(BackgroundMusicPlayer));

            BackgroundMusicPlayer!.Stream = BackgroundMusic;
            BackgroundMusicPlayer!.Play();
        }

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