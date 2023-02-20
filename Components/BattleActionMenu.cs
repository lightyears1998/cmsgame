namespace CMSGame
{
    public partial class BattleActionMenu : VBoxContainer
    {
        public VBoxContainer DynamicActions;

        public Button ItemActionButton;

        public Button SkillActionButton;

        public Button CommandActionButton;

        public override void _Ready()
        {
            this.GetUniqueNode(ref ItemActionButton, nameof(ItemActionButton));
            this.GetUniqueNode(ref DynamicActions, nameof(DynamicActions));
            this.GetUniqueNode(ref SkillActionButton, nameof(SkillActionButton));
            this.GetUniqueNode(ref CommandActionButton, nameof(CommandActionButton));
        }
    }
}
