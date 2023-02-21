namespace CMSGame
{
    public static class GameSaves
    {
        public static readonly GameSave Demo1 = new()
        {
            Characters = new() {
                new Character {
                    FamilyName = "腾",
                    GivenName = "牧心",
                    HealthPoint = 80
                }
            }
        };
    };
}
