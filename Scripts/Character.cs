public partial class Character : Node
{
    private int _hp;

    public int Hp
    {
        get => _hp;
        set => _hp = value;
    }

    public override void _Ready()
    {
    }

    public override void _Process(double delta)
    {
    }
}
