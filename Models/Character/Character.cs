namespace CMSGame
{
    internal class Character : ICharacterAbility
    {
        public int Strength { set; get; }

        public int MagicPower { set; get; }

        public int Skill { set; get; }

        public int Speed { set; get; }

        public int Defense { set; get; }

        public int MagicDefense { set; get; }

        public int Luck { set; get; }
    }
}
