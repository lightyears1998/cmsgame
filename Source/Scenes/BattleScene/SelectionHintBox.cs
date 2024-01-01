namespace CMSGame
{
    [SceneTree]
    internal partial class SelectionHintBox : PanelContainer
    {
        public void ShowText(BattleTileData data)
        {
            string tileName = data.Name;
            string movementDescription = GetMovementTypeDescription(data.AllowMovementType);
            string tileEffects = GetTileEffectDescription(data);

            SelectionHintLabel.Text = $"{tileName} {tileEffects}\n{movementDescription}";
        }

        private string GetMovementTypeDescription(BattleTileData.AllowMovementTypes movementTypes)
        {
            return movementTypes switch
            {
                BattleTileData.AllowMovementTypes.None => "不可通行",
                BattleTileData.AllowMovementTypes.All => "",
                BattleTileData.AllowMovementTypes.AirborneOnly => "无法步行",
                _ => throw new ArgumentOutOfRangeException(nameof(movementTypes)),
            };
        }

        private string GetTileEffectDescription(BattleTileData data)
        {
            string description = "";

            if (data.DodgeRateModifier != 0)
            {
                description += "回避 " + data.DodgeRateModifier.ToString("+#;-#");
            }

            return description;
        }
    }
}
