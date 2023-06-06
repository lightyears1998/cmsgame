using CommunityToolkit.Diagnostics;

namespace CMSGame
{
    internal partial class SceneLoader : Node
    {
        public static SceneLoader? Current { get; private set; }

        public SceneLoader()
        {
            Guard.IsNull(Current); // 单例
            Current = this;
        }

        public override void _Ready()
        {
            SwitchBackgroundMusic();
        }

        public void SwitchBackgroundMusic()
        {
            var scene = GetTree().CurrentScene;
            var backgroundMusic = scene.Get(nameof(IBackgroundMusicScene.BackgroundMusic)).As<AudioStream>();
            var player = BackgroundMusicPlayer.Current!;
            player.Stop();
            if (backgroundMusic != null)
            {
                player.Stream = backgroundMusic;
                player.Play();
            }
        }

        public void ChangeSceneToFile(string path)
        {
            GetTree().ChangeSceneToFile(path);
            AwaitSceneChangedAndDoPostAction();
        }

        public void ChangeSceneToPacked(PackedScene scene)
        {
            GetTree().ChangeSceneToPacked(scene);
            AwaitSceneChangedAndDoPostAction();
        }

        private async void AwaitSceneChangedAndDoPostAction()
        {
            await ToSignal(GetTree().CreateTimer(0), SceneTreeTimer.SignalName.Timeout);
            SwitchBackgroundMusic();
        }
    }
}
