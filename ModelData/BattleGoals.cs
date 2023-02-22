namespace CMSGame
{
    public static class BattleGoals
    {
        public static readonly Goal<BattleContext> Escape = new()
        {
            Name = "保命要紧",
            BasePriority = -50
        };

        public static readonly Goal<BattleContext> SelfRegulatory = new()
        {
            Name = "自律行动",
            BasePriority = 0
        };

        public static readonly Goal<BattleContext> FollowOrder = new()
        {
            Name = "服从指令",
            BasePriority = 50
        };

        public static List<Goal<BattleContext>> AllGoals()
        {
            return new() {
                Escape,
                SelfRegulatory,
                FollowOrder
            };
        }
    }
}
