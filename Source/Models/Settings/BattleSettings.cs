namespace CMSGame
{
    public record class BattleSettings : GameSettings
    {
        /// <summary>
        /// 是否跳过非玩家回合
        /// </summary>
        public bool SkipNonPlayerTurn { set; get; } = false;
    }
}
