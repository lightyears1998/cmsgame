namespace CMSGame
{
    public class Character
    {
        public string FamilyName;

        public string GivenName;

        public string Name => FamilyName + GivenName;

        public int HealthPoint;

        public int MaxHealthPoint;
    }
}
