using static CMSGame.BattleTileData;

namespace CMSGame
{
    internal partial class BattleTileMap : TileMap
    {
        public static class Layers
        {
            public static int Foundation => 0;

            public static int Masks => 1;

            public static int Floating => 2;
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

        public void AddMovableMask(Vector2I coordinates)
        {
            Vector2I atlasCoordinates = new(5, 0);
            this.SetCell(Layers.Masks, coordinates, 0, atlasCoordinates);
        }

        public void AddAttackableMask(Vector2I coordinates)
        {
            Vector2I atlasCoordinates = new(6, 0);
            this.SetCell(Layers.Masks, coordinates, 0, atlasCoordinates);
        }

        public void ClearMarks()
        {
            ClearLayer(Layers.Masks);
        }
    }
}
