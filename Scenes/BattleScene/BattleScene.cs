namespace CMSGame
{
    [SceneTree]
    internal partial class BattleScene : Node2D
    {
        public const int TileSize = 64;

        private CameraMode? _cameraMode;

        private Rect2 _cameraArea = new();

        private Rect2 SafeCameraFocusArea
        {
            get
            {
                var windowSize = GetViewport().GetWindow().Size;
                var width = windowSize.X / 2;
                var height = windowSize.Y / 2;
                return _cameraArea.GrowIndividual(-width / 2, -height / 2, -width / 2, -height / 2);
            }
        }

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
                        if (!SafeCameraFocusArea.HasPoint(CameraFocus.Position))
                        {
                            var x = Mathf.Clamp(CameraFocus.Position.X, SafeCameraFocusArea.Position.X, SafeCameraFocusArea.End.X);
                            var y = Mathf.Clamp(CameraFocus.Position.Y, SafeCameraFocusArea.Position.Y, SafeCameraFocusArea.End.Y);
                            CameraFocus.Position = new Vector2(x, y);
                        }
                        break;

                    case CameraMode.TrackMode:
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
                HandleMouseInput(mouseEvent);
            }
            else if (@event is InputEventKey keyEvent)
            {
                HandleKeyboardInput(keyEvent);
            }
        }

        public void HandleMouseInput(InputEventMouse mouseEvent)
        {
            bool isValidInput = false;

            // 左键单击
            if ((mouseEvent.ButtonMask & MouseButtonMask.Left) != 0)
            {
                var globalPosition = Camera2D.GetScreenCenterPosition() - GetViewport().GetWindow().Size / 2 + mouseEvent.GlobalPosition;
                var localPositionToTileMap = globalPosition - BattleTileMap.Position;
                var gridPosition = BattleTileMap.LocalToMap(localPositionToTileMap);
                SelectionMarker.TryMoveTo(gridPosition);
                isValidInput = true;
            }

            // 中键拖拽
            if ((mouseEvent.ButtonMask & MouseButtonMask.Middle) != 0)
            {
                if (InputAction.IsMiddleMouseDragging)
                {
                    var dragDistance = mouseEvent.Position - InputAction.LastMiddleMouseDragEvent!.Position;
                    var newPosition = CameraFocus.Position - dragDistance;
                    if (!SafeCameraFocusArea.HasPoint(newPosition))
                    {
                        var x = Mathf.Clamp(newPosition.X, SafeCameraFocusArea.Position.X, SafeCameraFocusArea.End.X);
                        var y = Mathf.Clamp(newPosition.Y, SafeCameraFocusArea.Position.Y, SafeCameraFocusArea.End.Y);
                        newPosition = new Vector2(x, y);
                    }
                    CameraFocus.Position = newPosition;
                }
                InputAction.LastMiddleMouseDragEvent = mouseEvent;
                isValidInput = true;
            }
            else
            {
                if (InputAction.IsMiddleMouseDragging)
                {
                    InputAction.LastMiddleMouseDragEvent = null;
                }
            }

            if (isValidInput)
            {
                UseCameraMode(CameraMode.FreeMode);
            }
        }

        public void HandleKeyboardInput(InputEventKey keyEvent)
        {
            bool isValidInput = false;

            // 是否为方向输入
            foreach (var kv in InputAction.MoveDirections)
            {
                var action = kv.Key;
                var direction = kv.Value;
                if (keyEvent.IsAction(action) && keyEvent.Pressed)
                {
                    SelectionMarker.TryMove(direction);
                    CameraFocus.Position = SelectionMarker.Position;
                    isValidInput = true;
                }
            }

            if (isValidInput)
            {
                UseCameraMode(CameraMode.TrackMode);
            }
        }

        internal enum CameraMode
        {
            FreeMode,
            TrackMode
        }
    }
}
