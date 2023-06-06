using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CMSGame
{
    [Tool]
    [SceneTree]
    internal partial class BattleCamera : Node2D
    {
        private Rect2 _safeCameraArea = new Rect2(-10000, -10000, 20000, 20000);

        [Export]
        public Rect2 SafeCameraArea
        {
            get => _safeCameraArea; set
            {
                _safeCameraArea = value;
                if (Camera2D != null)
                    SetupCamera2D();
            }
        }

        private Vector2 _focusPosition = Vector2.Zero;

        [Export]
        public Vector2 FocusPosition
        {
            get => _focusPosition;
            set
            {
                _focusPosition = value;
                if (CameraFocus != null)
                    CameraFocus.Position = value;
            }
        }

        private bool _dragEnabled = false;

        [Export]
        public bool DragEnabled
        {
            get => _dragEnabled;
            set
            {
                _dragEnabled = value;
                if (Camera2D != null)
                    Camera2D.DragHorizontalEnabled = Camera2D.DragVerticalEnabled = value;
            }
        }

        public Rect2 SafeCameraFocusArea
        {
            get
            {
                var windowSize = DisplayServer.WindowGetSize();
                var width = windowSize.X / 2;
                var height = windowSize.Y / 2;
                return SafeCameraArea.GrowIndividual(-width / 2, -height / 2, -width / 2, -height / 2);
            }
        }

        public override void _Ready()
        {
            SetupCamera2D();
        }

        protected void SetupCamera2D()
        {
            Camera2D.LimitLeft = (int)SafeCameraArea.Position.X;
            Camera2D.LimitTop = (int)SafeCameraArea.Position.Y;
            Camera2D.LimitRight = (int)SafeCameraArea.End.X;
            Camera2D.LimitBottom = (int)SafeCameraArea.End.Y;
            FocusOn(FocusPosition);
            Camera2D.ResetSmoothing();
        }

        public void FocusOn(Vector2 position)
        {
            position = ClampFocusPosition(position);
            FocusPosition = position;
        }

        protected Vector2 ClampFocusPosition(Vector2 position)
        {
            var span = SafeCameraFocusArea.End - SafeCameraFocusArea.Position;
            if (span.X < 0 || span.Y < 0)
            {
                return position; // SafeCameraFocusArea 不是合法的矩形，返回默认值。
            }

            if (!SafeCameraFocusArea.HasPoint(position))
            {
                var x = Mathf.Clamp(position.X, SafeCameraFocusArea.Position.X, SafeCameraFocusArea.End.X);
                var y = Mathf.Clamp(position.Y, SafeCameraFocusArea.Position.Y, SafeCameraFocusArea.End.Y);
                position = new Vector2(x, y);
            }

            return position;
        }

        public Vector2 GetScreenCenterPosition()
        {
            return Camera2D.GetScreenCenterPosition();
        }
    }
}
