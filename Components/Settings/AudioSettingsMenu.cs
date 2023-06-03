using CMSGame.Helpers;

namespace CMSGame
{
    public partial class AudioSettingsMenu : Control
    {
        public AudioSettings? Settings;

        public HSlider? MasterVolumeSlider;

        public HSlider? MusicVolumeSlider;

        public HSlider? SoundEffectVolumeSlider;

        public Button? AudioResetButton;

        public override void _Ready()
        {
            Settings = this.GetAutoloadNode<GameSettingsNode>(nameof(GameSettingsNode)).AudioSettings;

            MasterVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MasterVolumeSlider));
            MusicVolumeSlider = this.GetUniqueNode<HSlider>(nameof(MusicVolumeSlider));
            SoundEffectVolumeSlider = this.GetUniqueNode<HSlider>(nameof(SoundEffectVolumeSlider));
            AudioResetButton = this.GetUniqueNode<Button>(nameof(AudioResetButton));

            MasterVolumeSlider.ValueChanged += MasterVolumeSlider_ValueChanged;
            MusicVolumeSlider.ValueChanged += MusicVolumeSlider_ValueChanged;
            SoundEffectVolumeSlider.ValueChanged += SoundEffectVolumeSlider_ValueChanged;
            AudioResetButton.Pressed += AudioResetButton_Pressed;

            MasterVolumeSlider.Value = Settings.MusicVolume;
        }

        private void MasterVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.Master, value);
            Settings!.MusicVolume = value;
        }

        private void MusicVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.Music, value);
            Settings!.MusicVolume = value;
        }

        private void SoundEffectVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.SoundEffect, value);
            Settings!.MusicVolume = value;
        }

        private void AudioResetButton_Pressed()
        {
            MasterVolumeSlider!.Value = 0.8;
            MusicVolumeSlider!.Value = 0.8;
            SoundEffectVolumeSlider!.Value = 0.8;
        }
    }
}
