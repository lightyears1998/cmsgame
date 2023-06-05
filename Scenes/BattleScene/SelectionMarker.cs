namespace CMSGame
{
    [Tool]
    internal partial class SelectionMarker : GridSprite2D
    {
        public BattleTileMap? tileMap;

        public override void _EnterTree()
        {
            tileMap = GetParent<BattleScene>().BattleTileMap;
        }

        public override void _ExitTree()
        {
            tileMap = null;
        }

        public void TryMove(Vector2I gridDistance)
        {
            TryMoveTo(GridPosition + gridDistance);
        }

        public void TryMoveTo(Vector2I gridPosition)
        {
            var tileData = tileMap!.GetCellTileData(0, gridPosition);
            var isBoundary = tileData.GetCustomData("is_boundary").As<bool>();
            if (!isBoundary)
                GridPosition = gridPosition;
        }
    }
}
