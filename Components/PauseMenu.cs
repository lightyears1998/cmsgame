using CommunityToolkit.Diagnostics;

namespace CMSGame
{
    public partial class PauseMenu : VBoxContainer
    {
        public void On_ResumeBattleButton_Pressed()
        {
            Hide();
        }

        public void On_SettingsMenuButton_Pressed()
        {
            GetNode<Popup>("%SettingsPopup").PopupCentered();
        }

        public void On_EscapeFromBattleButton_Pressed()
        {
            ThrowHelper.ThrowNotSupportedException();
        }
    }
}
