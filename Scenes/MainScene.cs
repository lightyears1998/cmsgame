namespace CMSGame
{
    public partial class MainScene : Control
    {
        public void On_BattleDemo1Button_Pressed()
        {
            GetTree().ChangeSceneToFile("res://Scenes/BattleScene.tscn");
        }

        public void On_SettingsPopupButton_Pressed()
        {
            GetNode<Popup>("%SettingsPopup").PopupCentered();
        }

        public void On_QuitButton_Pressed()
        {
            GetTree().Quit();
        }
    }
}
