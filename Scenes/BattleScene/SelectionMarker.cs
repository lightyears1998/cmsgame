namespace CMSGame
{
    [Tool]
    internal partial class SelectionMarker : GridSprite2D
    {
        [Signal]
        public delegate void SelectionChangedEventHandler(Vector2I gridPosition);

        public void MoveDistance(Vector2I gridDistance)
        {
            MoveTo(GridPosition + gridDistance);
        }

        public void MoveTo(Vector2I gridPosition)
        {
            GridPosition = gridPosition;
            EmitSignal(SignalName.SelectionChanged, GridPosition);
        }
    }
}
