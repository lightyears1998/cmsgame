namespace CMSGame
{
    public partial class AudioSettingsMenu : Control
    {
        public GameSettingsNode? Settings;

        public HSlider? MasterVolumeSlider;

        public HSlider? MusicVolumeSlider;

        public HSlider? SoundEffectVolumeSlider;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref Settings, nameof(GameSettingsNode));

            MasterVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MasterVolumeSlider));
            MusicVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MusicVolumeSlider));
            SoundEffectVolumeSlider = this.GetUniqueNode<HSlider>(nameof(SoundEffectVolumeSlider));
        }
    }
}
