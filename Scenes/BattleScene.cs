namespace CMSGame
{
    public partial class BattleScene : Node2D
    {
        private Label _labelBattleTime;

        public double Time;

        public bool IsPause = false;

        public override void _Ready()
        {
            _labelBattleTime = GetNode<Label>("%LabelBattleTime");
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
                ToggleBattlePause();
            }
        }

        public void UpdateUI()
        {
            _labelBattleTime.Text = TimeHelper.FormatTime(Time);
        }

        private void ToggleBattlePause()
        {
            IsPause = !IsPause;
        }

        public void On_ButtonPauseBattle_Pressed()
        {
            ToggleBattlePause();
        }
    }
}
