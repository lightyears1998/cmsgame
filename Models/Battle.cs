using System.Collections.Generic;

namespace CMSGame
{
    public class Battle
    {
        public List<BattleParty> Parties;

        public BattleParty Attacker;

        public BattleParty Defender;

        public BattleParty PlayerParty;

        public Battle()
        {
            // load characters of the attacker and defender;
        }

        public void Begin()
        {
        }
    }
}
