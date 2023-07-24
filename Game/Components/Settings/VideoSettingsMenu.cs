namespace CMSGame
{
    [SceneTree]
    internal partial class VideoSettingsMenu : Control
    {
        public VideoSettings Settings = GameSettingsNode.Current!.VideoSettings;

        public override void _Ready()
        {
            // 连接信号
            FullScreenCheckButton!.Toggled += FullScreenCheckButton_Toggled;

            // 更新控件
            FullScreenCheckButton.SetPressedNoSignal(Settings.UseFullScreen);
        }

        private void FullScreenCheckButton_Toggled(bool buttonPressed)
        {
            Settings!.UseFullScreen = buttonPressed;
            DisplayServerHelper.ApplyResolutionSettings(buttonPressed);
        }
    }
}
