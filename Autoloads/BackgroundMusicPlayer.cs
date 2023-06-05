using CommunityToolkit.Diagnostics;

namespace CMSGame
{
    internal partial class BackgroundMusicPlayer : AudioStreamPlayer
    {
        public static BackgroundMusicPlayer? Current { get; private set; }

        public override void _EnterTree()
        {
            Guard.IsNull(Current); // 单例
            Current = this;
        }
    }
}
