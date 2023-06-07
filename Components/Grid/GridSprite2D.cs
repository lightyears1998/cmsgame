namespace CMSGame
{
    [Tool]
    internal partial class GridSprite2D : Sprite2D
    {
        private Vector2I _gridPosition = new();

        [Export]
        public Vector2I GridPosition
        {
            get => _gridPosition;
            set => SetGridPosition(value);
        }

        protected void SetGridPosition(Vector2I gridPosition)
        {
            _gridPosition = gridPosition;
            Position = GridPosition * BattleScene.TileSize + new Vector2I(32, 32);
        }

        public Vector2I GetGridPosition(Vector2 position)
        {
            Vector2I gridPosition = (new Vector2I((int)position.X, (int)position.Y) - new Vector2I(32, 32)) / BattleScene.TileSize;
            return gridPosition;
        }

        public override void _Notification(int what)
        {
            if (Engine.IsEditorHint())
            {
                if (what == NotificationEditorPreSave)
                {
                    SnapToGrid();
                }
            }
        }

        public void SnapToGrid()
        {
            var gridPosition = GetGridPosition(Position);
            if (GridPosition != gridPosition)
            {
                GridPosition = gridPosition;
            }
        }
    }
}
