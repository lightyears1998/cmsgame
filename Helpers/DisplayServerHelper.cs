namespace CMSGame
{
    /// <summary>
    /// DisplayServerHelper
    /// </summary>
    /// <remarks>
    /// 关于 Godot 图形显示相关的提示：
    /// <list type="bullet">
    /// <item>
    /// ViewPort 的 Size 包括了标题栏和边框在内整个窗口的大小；而客户区的大小可以通过 DisplayServer.GetWindowSize() 来获得。
    /// </item>
    /// </list>
    /// </remarks>
    internal static class DisplayServerHelper
    {
        public static void ApplyResolutionSettings(bool useFullScreen)
        {
            if (useFullScreen)
            {
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
            }
            else
            {
                DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
            }
        }
    }
}
