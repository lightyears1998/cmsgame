namespace CMSGame
{
    [Tool]
    [SceneTree]
    internal partial class CharacterStatusBox : PanelContainer
    {
        public void ShowInfo(BattleUnitSprite? unit)
        {
            if (unit == null)
            {
                Hide();
                return;
            }

            ShowBattleUnitInfo(unit);
        }

        private void ShowBattleUnitInfo(BattleUnitSprite unit)
        {
            Show();

            UnitNameLabel.Text = unit.UnitName;
            EquipmentLabel.Text = "无装备";

            AttackLabel.Text = unit.Attack.ToString();
            SpeedLabel.Text = unit.Speed.ToString();
            HitLabel.Text = unit.HitRate.ToString();
            DodgeLabel.Text = unit.DodgeRate.ToString();
            CriticalHitLabel.Text = unit.CriticalHitRate.ToString();
            DodgeCriticalLabel.Text = unit.CriticalDodgeRate.ToString();
        }
    }
}
