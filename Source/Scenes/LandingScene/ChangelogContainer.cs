using System.Text;

namespace CMSGame
{
    internal partial class ChangelogContainer : VBoxContainer
    {
        private readonly ChangelogList _changelogList = new();

        public string LatestVersion => _changelogList.GetLatestVersion();

        public RichTextLabel? ChangelogLabel;

        public override void _Ready()
        {
            // 获取节点
            this.GetUniqueNode(ref ChangelogLabel, nameof(ChangelogLabel));

            // 更新控件
            SetLabelText();
        }

        public void SetLabelText()
        {
            var changelogText = _changelogList.Select(log =>
            {
                StringBuilder textBuilder = new();
                textBuilder.Append($"[b]{log.Version}[/b]");

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
