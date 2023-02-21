using System.Collections.Generic;

namespace CMSGame
{
    public static class BattleGoals
    {
        public static readonly BattleGoal Escape = new()
        {
            Name = "保命要紧",
            BasePriority = -50
        };

        public static readonly BattleGoal SelfRegulatory = new()
        {
            Name = "自律行动",
            BasePriority = 0
        };

        public static readonly BattleGoal FollowOrder = new()
        {
            Name = "服从指令",
            BasePriority = 50
        };

        public static List<BattleGoal> AllGoals()
        {
            return new() {
                Escape,
                SelfRegulatory,
                FollowOrder
            };
        }
    }
}
