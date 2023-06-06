namespace CMSGame
{
    public interface ICharacterAbility
    {
        /// <summary>
        /// 力量
        /// </summary>
        public int Strength { get; }

        /// <summary>
        /// 魔力
        /// </summary>
        public int MagicPower { get; }

        /// <summary>
        /// 技巧
        /// </summary>
        public int Skill { get; }

        /// <summary>
        /// 速度
        /// </summary>
        public int Speed { get; }

        /// <summary>
        /// 防御
        /// </summary>
        public int Defense { get; }

        /// <summary>
        /// 魔防
        /// </summary>
        public int MagicDefense { get; }

        /// <summary>
        /// 幸运
        /// </summary>
        public int Luck { get; }
    }
}
