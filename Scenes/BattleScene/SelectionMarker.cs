namespace CMSGame
{
    [Tool]
    internal partial class SelectionMarker : GridSprite2D
    {
        public void TryMove(Vector2I moveDistance)
        {
            GridPosition += moveDistance;
        }
    }
}
