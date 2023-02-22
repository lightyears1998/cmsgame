using System.Collections.Generic;

namespace CMSGame
{
    public class Battle
    {
        public List<BattleParty> Parties = new();

        public BattleParty Attacker;

        public BattleParty Defender;

        public BattleParty PlayerParty;

        public Battle(BattleParty attacker, BattleParty defender, BattleParty playerParty)
        {
            Attacker = attacker;
            Defender = defender;
            PlayerParty = playerParty;
        }

        public void Begin()
        {
        }
    }
}
