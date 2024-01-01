namespace CMSGame
{
    [SceneTree]
    internal partial class SettingsMenuPopup : Popup
    {
        public override void _Ready()
        {
            HideButton.Pressed += HideButton_Pressed;
        }

        private void HideButton_Pressed()
        {
            Hide();
        }
    }
}
