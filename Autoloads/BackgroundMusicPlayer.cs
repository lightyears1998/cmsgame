namespace CMSGame
{
    internal partial class BackgroundMusicPlayer : AudioStreamPlayer
    {
        public static BackgroundMusicPlayer? Current { get; private set; }

        public override void _EnterTree()
        {
            Current = this;
        }
    }
}
