namespace CMSGame
{
    public partial class MainScene : Control
    {
        public void On_ButtonBattleDemo_Pressed()
        {
            GetTree().ChangeSceneToFile("res://Scenes/BattleScene.tscn");
        }

        public void On_ButtonSettings_Pressed()
        {
            GetNode<Popup>("%PauseMenu").PopupCentered();
        }

        public void On_ButtonExit_Pressed()
        {
            GetTree().Quit();
        }
    }
}
