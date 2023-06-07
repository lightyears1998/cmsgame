namespace CMSGame
{
    [Tool]
    internal partial class BattleUnitSprite : GridSprite2D
    {
        public enum UnitSide
        {
            Player,
            Enemy
        }

        private UnitSide _side;

        [Export]
        public UnitSide Side
        {
            get => _side;
            set
            {
                _side = value;
                var color = Side == UnitSide.Player ? PlayerColor : EnemyColor;
                ((ShaderMaterial)Material).SetShaderParameter("unit_color", color);
            }
        }

        private double _healthRation = 1;

        [Export(PropertyHint.Range, "0, 1")]
        public double HealthRatio
        {
            get => _healthRation; set
            {
                _healthRation = value;
                ((ShaderMaterial)this.Material).SetShaderParameter("health_ratio", value);
            }
        }

        public static readonly Color PlayerColor = new Color("6894ff");

        public static readonly Color EnemyColor = new Color("ff5468");
    }
}
