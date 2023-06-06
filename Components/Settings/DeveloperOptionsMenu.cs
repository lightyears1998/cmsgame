namespace CMSGame
{
    [SceneTree]
    internal partial class DeveloperOptionsMenu : Control
    {
        public static void On_OpenUserDataDirButton_Pressed()
        {
            OS.ShellOpen(new GodotPath("user://"));
        }
    }
}
