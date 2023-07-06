namespace CMSGame
{
    [Tool]
    [SceneTree]
    internal partial class PhaseIndicator : PanelContainer
    {
        public override void _Ready()
        {
            ShowPlayerPhase();
        }

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
