namespace CMSGame
{
    [InputMap]
    internal static partial class InputAction
    {
        public static bool IsMiddleMouseDragging => LastMiddleMouseDragEvent != null;

        public static InputEventMouse? LastMiddleMouseDragEvent = null;

        public static readonly Dictionary<string, Vector2I> MoveDirections = new(){
            {MoveUp, Vector2I.Up },
            {MoveDown, Vector2I.Down },
            {MoveLeft, Vector2I.Left },
            {MoveRight, Vector2I.Right }
        };
    }
}
