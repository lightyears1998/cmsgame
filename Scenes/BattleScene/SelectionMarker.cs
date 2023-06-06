namespace CMSGame
{
    [Tool]
    internal partial class SelectionMarker : GridSprite2D
    {
        public void MoveDistance(Vector2I gridDistance)
        {
            MoveTo(GridPosition + gridDistance);
        }

        public void MoveTo(Vector2I gridPosition)
        {
            GridPosition = gridPosition;
        }
    }
}
