namespace CMSGame
{
    public partial class AudioSettingsMenu : VBoxContainer
    {
        public GameSettings? GameSettings;

        public HSlider? MasterVolumeSlider;

        public HSlider? MusicVolumeSlider;

        public HSlider? SoundEffectVolumeSlider;

        public override void _Ready()
        {
            this.GetAutoloadNode(ref GameSettings, nameof(GameSettings));

            MasterVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MasterVolumeSlider));
            MusicVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MusicVolumeSlider));
            SoundEffectVolumeSlider = this.GetUniqueNode<HSlider>(nameof(SoundEffectVolumeSlider));
        }
    }
}
