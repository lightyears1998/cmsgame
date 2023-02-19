namespace CMSGame
{
    public partial class BattleScene : Node2D
    {
        public Label BattleTimeLabel;

        public double Time;

        public bool IsPause = false;

        public override void _Ready()
        {
            BattleTimeLabel = GetNode<Label>($"%{nameof(BattleTimeLabel)}");
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
            if (Input.IsActionPressed("battle_pause_toggle"))
            {
                TogglePauseBattle();
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

        public void On_PauseBattleButton_Pressed()
        {
            TogglePauseBattle();
        }
    }
}
