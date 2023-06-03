namespace CMSGame
{
    public partial class VideoSettingsMenu : Control
    {
        public VideoSettings? Settings;

        public CheckButton? FullScreenCheckButton;

        public override void _Ready()
        {
            Settings = this.GetAutoloadNode<GameSettingsNode>(nameof(GameSettingsNode)).VideoSettings;

            this.GetUniqueNode(ref FullScreenCheckButton, nameof(FullScreenCheckButton));

            FullScreenCheckButton!.SetPressedNoSignal(Settings.UseFullScreen);

            FullScreenCheckButton.Toggled += FullScreenCheckButton_Toggled; ;
        }

        private void FullScreenCheckButton_Toggled(bool buttonPressed)
        {
            Settings!.UseFullScreen = buttonPressed;
            if (buttonPressed)
            {
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
            }
            else
            {
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
            }
        }
    }
}
