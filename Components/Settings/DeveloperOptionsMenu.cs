namespace CMSGame
{
    public partial class DeveloperOptionsMenu : Control
    {
        public override void _Ready()
        {
        }

        public void On_OpenUserDataDirButton_Pressed()
        {
            OS.ShellOpen(new GodotPath("user://"));
        }
    }
}
