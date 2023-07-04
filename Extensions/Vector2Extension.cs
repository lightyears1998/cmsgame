namespace CMSGame.Extensions
{
    internal static class Vector2Extension
    {
        public static Vector2I ToVector2I(this Vector2 vec)
        {
            return new Vector2I((int)vec.X, (int)vec.Y);
        }
    }
}
