namespace CMSGame
{
    internal partial class VideoSettingsMenu : Control
    {
        public VideoSettings? Settings;

        public CheckButton? FullScreenCheckButton;

        public override void _Ready()
        {
            // 获取节点
            Settings = GameSettingsNode.Current!.VideoSettings;
            this.GetUniqueNode(ref FullScreenCheckButton, nameof(FullScreenCheckButton));

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
