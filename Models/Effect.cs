namespace CMSGame
{
    public abstract class Effect
    {
        public string Name = string.Empty;

        public string Description = string.Empty;

        public abstract void Perform(Character character);
    }
}
