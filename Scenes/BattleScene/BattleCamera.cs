using System.Diagnostics;

namespace CMSGame
{
    [Tool]
    [SceneTree]
    internal partial class BattleCamera : Camera2D
    {
        [Export]
        public bool DebugEnabled { set; get; } = false;

        [Export]
        public Rect2I Limit
        {
            set
            {
                LimitLeft = value.Position.X;
                LimitTop = value.Position.Y;
                LimitRight = value.End.X;
                LimitBottom = value.End.Y;
            }
            get => new(LimitLeft, LimitTop, LimitRight - LimitLeft, LimitBottom - LimitTop);
        }

        public override void _Draw()
        {
            if (DebugEnabled)
            {
                DrawSetTransform(-GlobalPosition);

                var topLeftPosition = GetScreenTopLeftOPosition();
                DrawCircle(topLeftPosition, 64, Colors.WhiteSmoke); // 屏幕左上角位置
                DrawCircle(Position, 32, Colors.Red); // 相机中心位置
            }
        }

        public override void _Process(double delta)
        {
            if (DebugEnabled)
                QueueRedraw();
        }

        public override void _Input(InputEvent @event)
        {
            if (DebugEnabled)
            {
                if (@event.IsActionPressed(InputActions.Debug))
                {
                    Debug.WriteLine("Screen top-left position: {0}", GetScreenTopLeftOPosition());
                }
            }
        }

        public Vector2 GetScreenTopLeftOPosition()
        {
            var transformOrigin = GetCanvasTransform().Origin;
            return new Vector2(-transformOrigin.X, -transformOrigin.Y);
        }

        public void PositionOn(Vector2 position)
        {
            using (new NoDrag(this))
            {
                Position = position;
            }
        }

        public void Pan(Vector2 distance)
        {
            using (new NoDrag(this))
            {
                Position += distance;
            }
        }

        public sealed class NoDrag : IDisposable
        {
            private readonly Camera2D _camera;
            private readonly bool _previousDragHorizontalEnabled;
            private readonly bool _previousDragVerticalEnabled;

            public NoDrag(Camera2D camera)
            {
                _camera = camera;

                _previousDragHorizontalEnabled = _camera.DragHorizontalEnabled;
                _previousDragVerticalEnabled = _camera.DragVerticalEnabled;
                _camera.Position = _camera.GetScreenCenterPosition();
                _camera.DragHorizontalEnabled = false;
                _camera.DragVerticalEnabled = false;
            }

            public void Dispose()
            {
                _camera.DragHorizontalEnabled = _previousDragHorizontalEnabled;
                _camera.DragVerticalEnabled = _previousDragVerticalEnabled;
            }
        }
    }
}
