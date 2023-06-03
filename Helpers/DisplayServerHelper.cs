namespace CMSGame.Helpers
{
    internal static class DisplayServerHelper
    {
        public static void ApplyAndPersistResolutionSettings(bool useFullScreen)
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
