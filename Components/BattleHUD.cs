namespace CMSGame
{
    public partial class BattleHUD : Control
    {
        public Vector2 LastMousePressedPosition;

        public Label? BattleTimeLabel;

        public Popup? PauseMenuPopup;

        public Popup? SettingsMenuPopup;

        public BattleActionMenu? BattleActionMenu;

        public override void _Ready()
        {
            this.GetUniqueNode(ref BattleTimeLabel, nameof(BattleTimeLabel));
            this.GetUniqueNode(ref PauseMenuPopup, nameof(PauseMenuPopup));
            this.GetUniqueNode(ref SettingsMenuPopup, nameof(SettingsMenuPopup));
            this.GetUniqueNode(ref BattleActionMenu, nameof(BattleActionMenu));
        }

        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButtonEvent)
            {
                if (mouseButtonEvent.Pressed)
                {
                    LastMousePressedPosition = mouseButtonEvent.Position;
                    var battleActionMenuRect = new Rect2(BattleActionMenu!.Position, BattleActionMenu.Size);
                    if (!battleActionMenuRect.HasPoint(LastMousePressedPosition))
                    {
                        BattleActionMenu.Visible = false;
                    }

                }
            }
        }

        public void ShowActionMenu(Vector2 position)
        {
            if (!BattleActionMenu!.Visible)
            {
                BattleActionMenu.Position = position;
                BattleActionMenu.Visible = true;
            }
        }
    }
}
