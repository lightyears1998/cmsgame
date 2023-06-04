using System.Text;

namespace CMSGame
{
    internal sealed class ChangelogList : List<Changelog>
    {
        public ChangelogList()
        {
            try
            {
                ParseChangelogFile();
            }
            catch (Exception ex)
            {
                GD.PushError(ex);
            }
        }

        private void ParseChangelogFile()
        {
            using var file = FileAccess.Open(new GodotPath("res://CHANGELOG.md"), FileAccess.ModeFlags.Read);
            var fileContent = file.GetAsText();

            if (fileContent == null) return;

            Changelog? changelog = null;
            StringBuilder contentBuilder = new();

            var commitChangelog = () =>
            {
                if (changelog != null)
                {
                    changelog.Description = contentBuilder.ToString();
                    contentBuilder.Clear();
                    this.Add(changelog);
                    changelog = null;
                }
            };

            foreach (var line in fileContent.Split("\n"))
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                if (line.StartsWith("#"))
                {
                    if (line.StartsWith("# ")) // 一号标题
                    {
                        continue;
                    }

                    if (line.StartsWith("## ")) // 二号标题，格式为 [未发布] 或 [1.0.0] - 2023-06-03
                    {
                        string title = line.TrimStart(new char[] { '#', ' ' });
                        string[] parts = title.Split('-', 2).Select(str => str.Trim()).ToArray();

                        string versionString = parts[0];
                        string dateString = "";
                        if (parts.Length >= 2)
                        {
                            dateString = parts[1];
                        }

                        commitChangelog();
                        changelog = new Changelog(dateString != string.Empty ? DateOnly.Parse(dateString) : null, versionString, "");

                        continue;
                    }
                }

                contentBuilder.Append(line.Trim());
                contentBuilder.Append('\n');
            }

            commitChangelog();
        }
    }
}
