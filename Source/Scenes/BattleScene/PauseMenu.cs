namespace CMSGame
{
    [SceneTree]
    internal partial class PauseMenu : PanelContainer
    {
        public override void _Ready()
        {
            ReturnToLandingPageButton.Pressed += ReturnToLandingPageButton_Pressed;
        }

        private void ReturnToLandingPageButton_Pressed()
        {
            SceneLoader.Current!.ChangeSceneToFile(Scenes.LandingScene);
        }
    }
}
