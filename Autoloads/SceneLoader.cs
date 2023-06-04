namespace CMSGame
{
    internal partial class SceneLoader : Node
    {
        public static SceneLoader? Current { get; private set; }

        public override void _EnterTree()
        {
            Current = this;
        }

        public override void _Ready()
        {
            SwitchBackgroundMusic();
        }

        public void SwitchBackgroundMusic()
        {
            var scene = GetTree().CurrentScene;
            var backgroundMusic = scene.Get(LandingScene.PropertyName.BackgroundMusic).As<AudioStream>();
            if (backgroundMusic != null)
            {
                var player = BackgroundMusicPlayer.Current!;
                player.Stop();
                player.Stream = backgroundMusic;
                player.Play();
            }
        }

        public void ChangeSceneToFile(string path)
        {
            GetTree().ChangeSceneToFile(path);
            DoPostSceneChangedAction();
        }

        public void ChangeSceneToPacked(PackedScene scene)
        {
            GetTree().ChangeSceneToPacked(scene);
            DoPostSceneChangedAction();
        }

        private void DoPostSceneChangedAction()
        {
            SwitchBackgroundMusic();
        }
    }
}
