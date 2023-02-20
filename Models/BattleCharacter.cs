namespace CMSGame
{
    public partial class BattleCharacter : CharacterBody3D
    {
        [Signal]
        public delegate void MousePressedEventHandler(Vector3 position);

        [Export]
        public Texture SpriteTexture;

        public BattleFieldPosition BattleFieldPosition;

        public Character Character;

        public Sprite3D Sprite3D;

        public Label3D StatusLabel;

        public int ActionPoint;

        public double ActionPointGathering;

        public override void _Ready()
        {
            this.GetUniqueNode(ref Sprite3D, nameof(Sprite3D));
            this.GetUniqueNode(ref StatusLabel, nameof(StatusLabel));
        }

        public override void _Process(double delta)
        {
            UpdateStatus(delta);
            UpdateUI();
        }

        public void UpdateStatus(double delta)
        {
            ActionPointGathering += delta;
            ActionPoint += (int)ActionPointGathering / 10;
            ActionPointGathering %= 10;
        }

        public void UpdateUI()
        {
            StatusLabel.Text = $"HP {120}\nAP {ActionPoint}";
        }

        public override void _InputEvent(Camera3D camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButtonEvent)
            {
                if (mouseButtonEvent.Pressed)
                {
                    EmitSignal(SignalName.MousePressed, position);
                }
            }
        }
    }
}
