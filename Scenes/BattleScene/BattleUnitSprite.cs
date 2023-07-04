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

        public static readonly Color PlayerColor = new("6894ff");

        public static readonly Color EnemyColor = new("ff5468");

        private UnitSide _side;

        [Export]
        public UnitSide Side
        {
            get => _side;
            set
            {
                _side = value;
                var color = Side == UnitSide.Player ? PlayerColor : EnemyColor;
                ((ShaderMaterial)this.Material).SetShaderParameter("unit_color", color);
            }
        }

        private int _health;

        [Export]
        public int Health
        {
            set
            {
                _health = value;
                HealthRatio = (double)_health / _maxHealth;
            }
            get => _health;
        }

        private int _maxHealth;

        [Export]
        public int MaxHealth
        {
            set
            {
                _maxHealth = value;
                HealthRatio = (double)_health / _maxHealth;
            }
            get => _maxHealth;
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

        [Export]
        public string UnitName
        {
            set; get;
        } = "";

        private int _actionPoints = 1;

        [Export]
        public int ActionPoints
        {
            get => _actionPoints;
            set
            {
                _actionPoints = value;
                ((ShaderMaterial)this.Material).SetShaderParameter("grayscale", _actionPoints <= 0);
            }
        }

        [Export]
        public int MoveAbility
        {
            set; get;
        }

        [Export]
        public int Attack
        {
            set; get;
        }

        [Export]
        public int HitRate
        {
            set; get;
        }

        [Export]
        public int DodgeRate
        {
            set; get;
        }

        [Export]
        public int CriticalHitRate
        {
            set; get;
        }

        [Export]
        public int CriticalDodgeRate
        {
            set; get;
        }

        [Export]
        public int Strength
        {
            set; get;
        }

        [Export]
        public int MagicPower
        {
            set; get;
        }

        [Export]
        public int Skill
        {
            set; get;
        }

        [Export]
        public int Speed
        {
            set; get;
        }

        [Export]
        public int Defense
        {
            set; get;
        }

        [Export]
        public int MagicDefense
        {
            set; get;
        }

        [Export]
        public int Luck
        {
            set; get;
        }
    }
}
