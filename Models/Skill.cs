using System.Collections.Generic;

namespace CMSGame
{
    public abstract class Skill
    {
        public string Name = string.Empty;

        public List<Effect> Effects = new();
    }
}
