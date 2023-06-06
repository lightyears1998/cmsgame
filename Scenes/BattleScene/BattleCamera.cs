namespace CMSGame
{
    [Tool]
    [SceneTree]
    internal partial class BattleCamera : Camera2D
    {
        [Export]
        public bool Debug { set; get; } = false;

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

        private bool _dragEnabled = false;

        [Export]
        public bool DragEnabled
        {
            get => _dragEnabled;
            set
            {
                _dragEnabled = this.DragHorizontalEnabled = this.DragVerticalEnabled = value;
            }
        }

        public Rect2 NoDragPositionSafeArea
        {
            get
            {
                var windowSize = DisplayServer.WindowGetSize();
                var width = windowSize.X;
                var height = windowSize.Y;
                return Limit.GrowIndividual(-width / 2, -height / 2, -width / 2, -height / 2);
            }
        }

        public override void _Ready()
        {
            DragEnabled = false;
        }

        public override void _Draw()
        {
            if (Debug)
            {
                DrawSetTransform(-GlobalPosition);

                var viewportTransform = GetViewportTransform();
                var topLeftCoordinate = new Vector2(-viewportTransform.Origin.X, -viewportTransform.Origin.Y);
                DrawCircle(topLeftCoordinate, 64, Colors.Green);
                DrawCircle(Position, 32, Colors.Red);
                DrawRect(NoDragPositionSafeArea, Colors.PowderBlue);

                Console.WriteLine("Camera Position: {0}", Position);
                Console.WriteLine("Camera GlobalPosition: {0}", GlobalPosition);
            }
        }

        public void PositionOn(Vector2 position)
        {
            //Position = ClampPosition(position);
            Position = position;
        }

        public override void _Process(double delta)
        {
            if (Debug)
                QueueRedraw();
        }

        protected Vector2 ClampPosition(Vector2 position)
        {
            var span = NoDragPositionSafeArea.End - NoDragPositionSafeArea.Position;
            if (span.X < 0 || span.Y < 0)
            {
                return position; // SafeCameraFocusArea 不是合法的矩形，返回默认值。
            }

            if (!NoDragPositionSafeArea.HasPoint(position))
            {
                // 将相机中心位置钳制在 NoDragPositionSafeArea 内。
                var x = Mathf.Clamp(position.X, NoDragPositionSafeArea.Position.X, NoDragPositionSafeArea.End.X);
                var y = Mathf.Clamp(position.Y, NoDragPositionSafeArea.Position.Y, NoDragPositionSafeArea.End.Y);
                position = new Vector2(x, y);
            }

            return position;
        }
    }
}
