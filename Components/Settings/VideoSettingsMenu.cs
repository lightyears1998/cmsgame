namespace CMSGame
{
    internal partial class VideoSettingsMenu : Control
    {
        public VideoSettings? Settings;

        public CheckButton? FullScreenCheckButton;

        public override void _Ready()
        {
            Settings = this.GetAutoloadNode<GameSettingsNode>(nameof(GameSettingsNode)).VideoSettings;

            this.GetUniqueNode(ref FullScreenCheckButton, nameof(FullScreenCheckButton));

            FullScreenCheckButton!.Toggled += FullScreenCheckButton_Toggled;

            FullScreenCheckButton.SetPressedNoSignal(Settings.UseFullScreen);
        }

        private void FullScreenCheckButton_Toggled(bool buttonPressed)
        {
            Settings!.UseFullScreen = buttonPressed;
            DisplayServerHelper.ApplyResolutionSettings(buttonPressed);
        }
    }
}
