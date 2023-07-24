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
            StartButton.Pressed += StartButton_Pressed;
            SettingsButton.Pressed += SettingsButton_Pressed;
            QuitButton.Pressed += QuitButton_Pressed;
            ChangelogToggleButton.Pressed += ChangelogToggleButton_Pressed;
            ChangelogContainer.VisibilityChanged += UpdateButtonText;
            VisitItchPageButton.Pressed += VisitItchPage;
            VisitGitHubPageButton.Pressed += VisitGitHubPage;

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

        private void StartButton_Pressed()
        {
            SceneLoader.Current!.ChangeSceneToFile(Scenes.BattleScene);
        }

        private void SettingsButton_Pressed()
        {
            SettingsMenuPopup.PopupCentered();
        }

        private void QuitButton_Pressed()
        {
            GetTree().Quit();
        }

        private void ChangelogToggleButton_Pressed()
        {
            ChangelogContainer.Visible = !ChangelogContainer.Visible;
            GameSettingsNode.Current!.MiscSettings.ShowChangelogAtLandingScene = ChangelogContainer.Visible;
        }

        private void VisitItchPage()
        {
            OS.ShellOpen(Environment.ItchHomePage);
        }

        private void VisitGitHubPage()
        {
            OS.ShellOpen(Environment.GitHubHomePage);
        }
    }
}
