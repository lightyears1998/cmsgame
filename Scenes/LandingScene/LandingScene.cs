namespace CMSGame
{
    public partial class LandingScene : Control
    {
        public void On_SettingsPopupButton_Pressed()
        {
            GetNode<Popup>("%SettingsMenuPopup").PopupCentered();
        }

        public void On_QuitButton_Pressed()
        {
            GetTree().Quit();
        }
    }
}
