using System.Collections.Generic;

namespace CMSGame
{
    public class BattleCharacter
    {
        public List<BattleGoal> Goals;

        public Character Character;

        public BattleCharacter(Character character)
        {
            Character = character;
            EstablishGoals();
        }

        private void EstablishGoals()
        {
            Goals = BattleGoals.AllGoals();
        }
    }
}
