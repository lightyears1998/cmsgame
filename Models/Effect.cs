namespace CMSGame
{
    public abstract class Effect
    {
        public string Name;

        public string Description;

        public abstract void Perform(Character character);
    }
}
