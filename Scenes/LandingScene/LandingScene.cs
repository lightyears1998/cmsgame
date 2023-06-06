namespace CMSGame
{
    [SceneTree]
    internal partial class LandingScene : Control, IBackgroundMusicScene
    {
        [Export]
        public AudioStream BackgroundMusic { get; set; } = new();

        public override void _Ready()
        {
            // 连接信号
            ChangelogContainer.VisibilityChanged += UpdateButtonText;

            // 更新控件
            UpdateButtonText();
            DetermineIfShowChangelog();
        }

        private void UpdateButtonText()
        {
            ChangelogToggleButton.Text = ChangelogContainer.Visible ? "收\n起\n更\n新\n日\n志" : "展\n开\n更\n新\n日\n志";
        }

        public void DetermineIfShowChangelog()
        {
            var miscSettings = GameSettingsNode.Current!.MiscSettings;
            bool showShowChangeLog = miscSettings.ShowChangelogAtLandingScene;

            string lastRunVersion = miscSettings.LastRunVersion;
            if (ChangelogContainer.LatestVersion != lastRunVersion)
            {
                showShowChangeLog = true;
            }
            miscSettings.LastRunVersion = ChangelogContainer.LatestVersion;

            ChangelogContainer.Visible = showShowChangeLog;
        }

        public static void On_StartButton_Pressed()
        {
            SceneLoader.Current!.ChangeSceneToFile("res://Scenes/BattleScene/BattleScene.tscn");
        }

        public void On_SettingsPopupButton_Pressed()
        {
            SettingsMenuPopup.PopupCentered();
        }

        public void On_QuitButton_Pressed()
        {
            GetTree().Quit();
        }

        public void On_ChangelogToggleButton_Pressed()
        {
            ChangelogContainer.Visible = !ChangelogContainer.Visible;
            GameSettingsNode.Current!.MiscSettings.ShowChangelogAtLandingScene = ChangelogContainer.Visible;
        }
    }
}
