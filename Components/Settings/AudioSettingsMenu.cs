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

        public Button? MuteAllButton;

        public override void _Ready()
        {
            // 获取节点
            Settings = this.GetAutoloadNode<GameSettingsNode>(nameof(GameSettingsNode)).AudioSettings;
            this.GetUniqueNode(ref MasterVolumeSlider, nameof(MasterVolumeSlider));
            this.GetUniqueNode(ref MusicVolumeSlider, nameof(MusicVolumeSlider));
            this.GetUniqueNode(ref SoundEffectVolumeSlider, nameof(SoundEffectVolumeSlider));
            this.GetUniqueNode(ref AudioResetButton, nameof(AudioResetButton));
            this.GetUniqueNode(ref MuteAllButton, nameof(MuteAllButton));

            // 连接信号
            MasterVolumeSlider!.ValueChanged += MasterVolumeSlider_ValueChanged;
            MusicVolumeSlider!.ValueChanged += MusicVolumeSlider_ValueChanged;
            SoundEffectVolumeSlider!.ValueChanged += SoundEffectVolumeSlider_ValueChanged;
            AudioResetButton!.Pressed += AudioResetButton_Pressed;

            // 更新控件
            MasterVolumeSlider.Value = Settings.MasterVolume;
            MusicVolumeSlider.Value = Settings.MusicVolume;
            SoundEffectVolumeSlider.Value = Settings.SoundEffectVolume;
        }

        private void MasterVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.Master, value);
            Settings!.MasterVolume = value;
        }

        private void MusicVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.Music, value);
            Settings!.MusicVolume = value;
        }

        private void SoundEffectVolumeSlider_ValueChanged(double value)
        {
            AudioServerHelper.SetBusVolumeLinear(AudioBusLayout.SoundEffect, value);
            Settings!.SoundEffectVolume = value;
        }

        private void AudioResetButton_Pressed()
        {
            var defaultAudioSettings = new AudioSettings();
            MasterVolumeSlider!.Value = defaultAudioSettings.MasterVolume;
            MusicVolumeSlider!.Value = defaultAudioSettings.MusicVolume;
            SoundEffectVolumeSlider!.Value = defaultAudioSettings.SoundEffectVolume;
        }
    }
}
