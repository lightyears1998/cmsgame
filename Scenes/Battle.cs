public partial class Battle : Control
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

    public override void _Input(InputEvent input)
    {
        if (Input.IsActionPressed("battle_pause"))
        {
            IsPause = !IsPause;
        }
    }

    public void UpdateUI()
    {
        _labelBattleTime.Text = TimeHelper.FormatTime(Time);
    }

    public static void On_ButtonBattlePause_Pressed()
    {
        Input.ParseInputEvent(new InputEventAction { Action = "battle_pause" });
    }
}
