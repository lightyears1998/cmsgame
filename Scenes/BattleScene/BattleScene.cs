namespace CMSGame
{
    [SceneTree]
    internal partial class BattleScene : Node2D
    {
        public const int TileSize = 64;

        private CameraMode _cameraMode = CameraMode.FreeMode;

        private Rect2 _cameraArea = new();

        public override void _Ready()
        {
            SetCamera();
            UseCameraMode(CameraMode.FreeMode);
        }

        private void SetCamera()
        {
            var used = BattleTileMap.GetUsedRect().Grow(-1);
            _cameraArea.Position = used.Position * TileSize;
            _cameraArea.End = used.End * TileSize;

            Camera2D.LimitLeft = (int)_cameraArea.Position.X;
            Camera2D.LimitTop = (int)_cameraArea.Position.Y;
            Camera2D.LimitRight = (int)_cameraArea.End.X;
            Camera2D.LimitBottom = (int)_cameraArea.End.Y;

            Camera2D.ResetSmoothing();
        }

        private void UseCameraMode(CameraMode mode)
        {
            if (mode != _cameraMode)
            {
                switch (mode)
                {
                    case CameraMode.FreeMode:
                        Camera2D.DragHorizontalEnabled = false;
                        Camera2D.DragVerticalEnabled = false;
                        break;

                    case CameraMode.AutoMode:
                        Camera2D.DragHorizontalEnabled = true;
                        Camera2D.DragVerticalEnabled = true;
                        break;

                    default:
                        throw new NotImplementedException();
                }

                _cameraMode = mode;
            }
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventMouse mouseEvent)
            {
                UseCameraMode(CameraMode.FreeMode);
                HandleMouseInput(mouseEvent);
            }
            else if (@event is InputEventKey keyEvent)
            {
                UseCameraMode(CameraMode.AutoMode);
                HandleKeyboardInput(keyEvent);
            }
        }

        public void HandleMouseInput(InputEventMouse mouseEvent)
        {
            // 左键单击
            if ((mouseEvent.ButtonMask & MouseButtonMask.Left) != 0)
            {
                var globalPosition = Camera2D.GetScreenCenterPosition() - GetViewport().GetWindow().Size / 2 + mouseEvent.GlobalPosition;
                var localPositionToTileMap = globalPosition - BattleTileMap.Position;
                var gridPosition = BattleTileMap.LocalToMap(localPositionToTileMap);
                SelectionMarker.TryMoveTo(gridPosition);
            }

            // 中键拖拽
            if ((mouseEvent.ButtonMask & MouseButtonMask.Middle) != 0)
            {
                if (InputAction.IsMiddleMouseDragging)
                {
                    var dragDistance = mouseEvent.Position - InputAction.LastMiddleMouseDragEvent!.Position;
                    var newPosition = CameraFocus.Position - dragDistance;
                    if (_cameraArea.HasPoint(newPosition))
                    {
                        CameraFocus.Position = newPosition;
                    }
                }
                InputAction.LastMiddleMouseDragEvent = mouseEvent;
            }
            else
            {
                if (InputAction.IsMiddleMouseDragging)
                {
                    InputAction.LastMiddleMouseDragEvent = null;
                }
            }
        }

        public void HandleKeyboardInput(InputEventKey keyEvent)
        {
            // 是否为方向输入
            foreach (var kv in InputAction.MoveDirections)
            {
                var action = kv.Key;
                var direction = kv.Value;
                if (keyEvent.IsAction(action) && keyEvent.Pressed)
                {
                    SelectionMarker.TryMove(direction);
                    CameraFocus.Position = SelectionMarker.Position;
                }
            }
        }

        internal enum CameraMode
        {
            FreeMode,
            AutoMode
        }
    }
}
