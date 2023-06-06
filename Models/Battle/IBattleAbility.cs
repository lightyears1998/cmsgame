namespace CMSGame
{
    public interface IBattleAbility
    {
        /// <summary>
        /// 攻击
        /// </summary>
        public int Attack { get; }

        /// <summary>
        /// 命中
        /// </summary>
        public int HitRate { get; }

        /// <summary>
        /// 回避
        /// </summary>
        public int DodgeRate { get; }

        /// <summary>
        /// 必杀
        /// </summary>
        public int CriticalHitRate { get; }

        /// <summary>
        /// 必避
        /// </summary>
        public int DodgeCriticalRate { get; }
    }
}
