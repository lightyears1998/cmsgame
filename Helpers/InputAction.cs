namespace CMSGame
{
    [InputMap]
    internal static partial class InputAction
    {
        public static readonly Dictionary<string, Vector2I> MoveDirections = new(){
            {InputAction.MoveUp, Vector2I.Up },
            {InputAction.MoveDown, Vector2I.Down },
            {InputAction.MoveLeft, Vector2I.Left },
            {InputAction.MoveRight, Vector2I.Right }
        };
    }
}
