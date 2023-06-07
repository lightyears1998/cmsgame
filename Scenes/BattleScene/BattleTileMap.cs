using static CMSGame.BattleTileData;

namespace CMSGame
{
    internal partial class BattleTileMap : TileMap
    {
        public static class Layers
        {
            public static int Foundation => 0;

            public static int Floating => 1;
        }

        public BattleTileData GetBattleTileData(Vector2I coordinates)
        {
            var tileData = this.GetCellTileData(Layers.Foundation, coordinates);

            return new BattleTileData
            {
                IsBoundary = tileData.GetCustomData("is_boundary").As<bool>(),
                Name = tileData.GetCustomData("name").As<string>(),
                AllowMovementType = (AllowMovementTypes)tileData.GetCustomData("allowed_movement_type").As<int>(),
                DodgeRateModifier = tileData.GetCustomData("dodge_rate_modifier").As<int>(),
            };
        }
    }
}
