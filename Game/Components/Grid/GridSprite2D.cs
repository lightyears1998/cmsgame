using CMSGame.Extensions;

namespace CMSGame
{
    [Tool]
    internal partial class GridSprite2D : Sprite2D
    {
        private Vector2I _gridPosition = new();

        private const int _tileSize = BattleScene.TileSize;

        [Export]
        public Vector2I GridPosition
        {
            get => _gridPosition;
            set => SetGridPosition(value);
        }

        protected void SetGridPosition(Vector2I gridPosition)
        {
            _gridPosition = gridPosition;
            Position = GridPosition * _tileSize + new Vector2I(_tileSize / 2, _tileSize / 2);
        }

        public static Vector2I GetGridPosition(Vector2 position)
        {
            Vector2I gridPosition = (position.ToVector2I() - new Vector2I(_tileSize / 2, _tileSize / 2)) / _tileSize;
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
