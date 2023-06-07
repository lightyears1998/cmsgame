namespace CMSGame
{
    public record class BattleTileData
    {
        public enum AllowMovementTypes : int
        {
            None = 0,
            All = 1,
            AirborneOnly = 2
        }

        public bool IsBoundary { set; get; }

        public string Name { set; get; } = "";

        public AllowMovementTypes AllowMovementType { set; get; }

        public int DodgeRateModifier { set; get; }
    }
}
