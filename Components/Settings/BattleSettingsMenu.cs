namespace CMSGame
{
    [SceneTree]
    internal partial class BattleSettingsMenu : Control
    {
        public BattleSettings Settings = GameSettingsNode.Current!.BattleSettings;

        public override void _Ready()
        {
            // 连接信号
            SkipNonPlayerTurnCheckButton.Toggled += SkipNonPlayerTurnCheckButton_Toggled;

            // 更新控件
            SkipNonPlayerTurnCheckButton.ButtonPressed = Settings.SkipNonPlayerTurn;
        }

        private void SkipNonPlayerTurnCheckButton_Toggled(bool buttonPressed)
        {
            Settings.SkipNonPlayerTurn = buttonPressed;
        }
    }
}
