namespace CMSGame
{
    [SceneTree]
    internal partial class DeveloperOptionsMenu : Control
    {
        public override void _Ready()
        {
            // 连接信号
            OpenUserDataDirButton.Pressed += OpenUserDataDirButton_Pressed;
        }

        public void OpenUserDataDirButton_Pressed()
        {
            OS.ShellOpen(new GodotPath("user://"));
        }
    }
}
