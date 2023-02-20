namespace CMSGame
{
    public partial class BattleSceneTest : Node3D
	{
        public BattleScene BattleScene;

        public override void _Ready()
		{
            BattleScene = GetNode<BattleScene>("BattleScene");
        }

        public void On_BattleCharacter_MousePressed(Vector3 _)
        {
            BattleScene.HUD.ShowActionMenu(BattleScene.HUD.LastMousePressedPosition);
        }
	}
}
