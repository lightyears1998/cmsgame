namespace CMSGame
{
    public class BattleCharacter
    {
        public List<Goal<BattleContext>> Goals = new();

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
