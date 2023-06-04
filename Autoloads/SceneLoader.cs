namespace CMSGame.Autoloads
{
    internal partial class SceneLoader : Node
    {
        public AudioStreamPlayer? BackgroundMusicPlayer;

        public override void _Ready()
        {
            // 获取节点
            this.GetAutoloadNode(ref BackgroundMusicPlayer, nameof(BackgroundMusicPlayer));

            // 切换初始场景的背景音乐
            SwitchBackgroundMusic();
        }

        public void SwitchBackgroundMusic()
        {
            var scene = GetTree().CurrentScene;
            var backgroundMusic = scene.Get(LandingScene.PropertyName.BackgroundMusic).As<AudioStream>();
            if (backgroundMusic != null)
            {
                BackgroundMusicPlayer!.Stop();
                BackgroundMusicPlayer.Stream = backgroundMusic;
                BackgroundMusicPlayer.Play();
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
