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

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventMouse mouseEvent)
            {
                HandleMouseInput(mouseEvent);
            }
            else if (@event is InputEventKey keyEvent)
            {
                HandleKeyboardInput(keyEvent);
            }
        }

        public void HandleMouseInput(InputEventMouse mouseEvent)
        {
            var globalPosition = Camera2D.GetScreenCenterPosition() - GetViewport().GetWindow().Size / 2 + mouseEvent.GlobalPosition;
            var localPositionToTileMap = globalPosition - TileMap.Position;
            var gridPosition = _.TileMap.LocalToMap(localPositionToTileMap);
            SelectionMarker.TryMoveTo(gridPosition);
        }

        public void HandleKeyboardInput(InputEventKey keyEvent)
        {
            foreach (var kv in InputAction.MoveDirections)
            {
                var action = kv.Key;
                var direction = kv.Value;
                if (keyEvent.IsAction(action) && keyEvent.Pressed)
                {
                    SelectionMarker.TryMove(direction);
                }
            }
        }
    }
}
