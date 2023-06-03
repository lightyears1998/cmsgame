using System.Text;

namespace CMSGame
{
    public partial class ChangelogContainer : VBoxContainer
    {
        private readonly ChangelogList _changelogList = new();

        public RichTextLabel? ChangelogLabel;

        public override void _Ready()
        {
            this.GetUniqueNode(ref ChangelogLabel, nameof(ChangelogLabel));

            SetLabelText();
        }

        public void SetLabelText()
        {
            var changelogText = _changelogList.Select(log =>
            {
                StringBuilder textBuilder = new();
                textBuilder.Append($"[b]{log.Title}[/b]");

                if (log.Date != null)
                {
                    textBuilder.Append($" [i]{log.Date}[/i]");
                }

                textBuilder.Append('\n');
                textBuilder.Append(log.Description);

                return textBuilder.ToString();
            }).ToArray().Join("\n");

            ChangelogLabel!.Text = changelogText;
        }
    }
}
