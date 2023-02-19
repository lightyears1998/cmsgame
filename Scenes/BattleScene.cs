namespace CMSGame
{
    public partial class BattleScene : Node3D
    {
        public Popup PauseMenuPopup;

        public Popup SettingsMenuPopup;

        public Label BattleTimeLabel;

        public double Time;

        public bool IsPause = false;

        private bool IsPauseBeforePauseMenuPopup = false;

        public override void _Ready()
        {
            PauseMenuPopup = this.GetUniqueNode<Popup>($"%{nameof(PauseMenuPopup)}");
            SettingsMenuPopup = this.GetUniqueNode<Popup>($"%{nameof(SettingsMenuPopup)}");
            BattleTimeLabel = this.GetUniqueNode<Label>($"%{nameof(BattleTimeLabel)}");
        }

        public override void _Process(double delta)
        {
            if (!IsPause)
            {
                Time += delta;
            }
            UpdateUI();
        }

        public override void _UnhandledInput(InputEvent input)
        {
            if (input.IsActionPressed("battle_pause_toggle"))
            {
                TogglePauseBattle();
            }
            else if (input.IsActionPressed("battle_pause"))
            {
                ShowPauseMenu();
            }
        }

        public void UpdateUI()
        {
            BattleTimeLabel.Text = TimeHelper.FormatTime(Time);
        }

        private void TogglePauseBattle()
        {
            IsPause = !IsPause;
        }

        private void ShowPauseMenu()
        {
            IsPauseBeforePauseMenuPopup = IsPause;
            IsPause = true;
            PauseMenuPopup.PopupCentered();
        }

        private void On_PauseBattleButton_Pressed()
        {
            TogglePauseBattle();
        }

        private void On_PauseMenuPopup_PopupHide()
        {
            IsPause = IsPauseBeforePauseMenuPopup;
        }

        private void On_ResumeBattleButton_Pressed()
        {
            PauseMenuPopup.Hide();
        }

        private void On_SettingsMenuButton_Pressed()
        {
            SettingsMenuPopup.PopupCentered();
        }
    }
}
