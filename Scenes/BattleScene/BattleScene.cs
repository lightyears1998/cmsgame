namespace CMSGame
{
    [SceneTree]
    internal partial class BattleScene : Node2D
    {
        public enum Phase
        {
            PlayerPhase,
            EnemyPhase
        }

        public const int TileSize = 64;

        public override void _Ready()
        {
            SetCamera();
        }

        private void SetCamera()
        {
            var used = BattleTileMap.GetUsedRect().Grow(-1);
            Rect2I cameraArea = new()
            {
                Position = used.Position * TileSize,
                End = used.End * TileSize
            };
            BattleCamera.Limit = cameraArea;
            BattleCamera.DragEnabled = true;
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
            // 左键单击
            if ((mouseEvent.ButtonMask & MouseButtonMask.Left) != 0)
            {
                var globalPosition = BattleCamera.GetScreenCenterPosition() - GetViewport().GetWindow().Size / 2 + mouseEvent.GlobalPosition;
                var localPositionToTileMap = globalPosition - BattleTileMap.Position;
                var gridPosition = BattleTileMap.LocalToMap(localPositionToTileMap);
                TryMoveSelectionMarkerTo(gridPosition);
            }

            // 中键拖拽
            if ((mouseEvent.ButtonMask & MouseButtonMask.Middle) != 0)
            {
                if (InputActions.IsMiddleMouseDragging)
                {
                    var dragDistance = mouseEvent.Position - InputActions.LastMiddleMouseDragEvent!.Position;
                    var newPosition = BattleCamera.Position - dragDistance;
                    BattleCamera.PositionOn(newPosition);
                }
                InputActions.LastMiddleMouseDragEvent = mouseEvent;
            }
            else
            {
                if (InputActions.IsMiddleMouseDragging)
                {
                    InputActions.LastMiddleMouseDragEvent = null;
                }
            }
        }

        public void HandleKeyboardInput(InputEventKey keyEvent)
        {
            // 暂停菜单
            if (keyEvent.IsAction(InputActions.BattlePause))
            {
                PauseMenu.Visible = !PauseMenu.Visible;
            }

            // 是否为方向输入
            foreach (var kv in InputActions.MoveDirections)
            {
                var action = kv.Key;
                var direction = kv.Value;
                if (keyEvent.IsAction(action) && keyEvent.Pressed)
                {
                    TryMoveSelectionMarkerTo(SelectionMarker.GridPosition + direction);
                    BattleCamera.PositionOn(SelectionMarker.Position);
                }
            }
        }

        protected void TryMoveSelectionMarkerTo(Vector2I gridPosition)
        {
            var tileData = BattleTileMap!.GetCellTileData(0, gridPosition);
            var isBoundary = tileData.GetCustomData("is_boundary").As<bool>();
            if (!isBoundary)
                SelectionMarker.MoveTo(gridPosition);
        }
    }
}
