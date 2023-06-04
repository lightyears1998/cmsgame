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
    }
}
