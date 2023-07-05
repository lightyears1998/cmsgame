namespace CMSGame
{
    [SceneTree]
    internal partial class PhaseIndicator : PanelContainer
    {
        public void ShowPlayerPhase()
        {
            Label.Text = "玩家回合";
        }

        public void ShowEnemyPhase()
        {
            Label.Text = "对手回合";
        }
    }
}
