using CommunityToolkit.Diagnostics;

namespace CMSGame
{
    internal partial class BackgroundMusicPlayer : AudioStreamPlayer
    {
        public static BackgroundMusicPlayer? Current { get; private set; }

        public BackgroundMusicPlayer()
        {
            Guard.IsNull(Current); // 单例
            Current = this;
        }
    }
}
