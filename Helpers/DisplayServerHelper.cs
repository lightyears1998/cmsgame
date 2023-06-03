namespace CMSGame
{
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
