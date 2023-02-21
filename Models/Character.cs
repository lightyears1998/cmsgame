namespace CMSGame
{
    public class Character
    {
        public string FamilyName = string.Empty;

        public string GivenName = string.Empty;

        public string Name => FamilyName + GivenName;

        public int HealthPoint;

        public int MaxHealthPoint;
    }
}
