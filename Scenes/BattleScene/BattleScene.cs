namespace CMSGame
{
    [SceneTree]
    internal partial class BattleScene : Node2D
    {
        public const int TileSize = 64;

        public override void _Ready()
        {
            LimitCamera();
        }

        private void LimitCamera()
        {
            var used = _.TileMap.GetUsedRect().Grow(-1);
            Camera2D.LimitLeft = used.Position.X * TileSize;
            Camera2D.LimitTop = used.Position.Y * TileSize;
            Camera2D.LimitRight = used.End.X * TileSize;
            Camera2D.LimitBottom = used.End.Y * TileSize;
            Camera2D.ResetSmoothing();
        }

        public override void _Process(double delta)
        {
            var directionX = Input.GetAxis("move_left", "move_right");
            var directionY = Input.GetAxis("move_up", "move_down");
            var moveDistance = new Vector2I((int)directionX, (int)directionY);
            SelectionMarker.TryMove(moveDistance);
        }
    }
}
