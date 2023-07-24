using System.Text;

namespace CMSGame
{
    internal sealed class ChangelogList : List<Changelog>
    {
        private static GodotPath ChangelogPath => new("res://CHANGELOG.md");

        public ChangelogList()
        {
            try
            {
                var fileContent = ReadChangelogFile();
                ParseChangelogFile(fileContent);
            }
            catch (Exception ex)
            {
                GD.PushError(ex);
            }
        }

        public string GetLatestVersion()
        {
            if (this.Count > 0)
            {
                return this[0].Version;
            }

            return "";
        }

        private static string ReadChangelogFile()
        {
            using var file = FileAccess.Open(ChangelogPath, FileAccess.ModeFlags.Read);
            var fileContent = file.GetAsText();
            return fileContent ?? "";
        }

        private void ParseChangelogFile(string fileContent, int maxLogCount = 10)
        {
            Changelog? changelog = null;
            StringBuilder descriptionBuilder = new();

            var commitChangelog = () =>
            {
                if (changelog != null && this.Count < maxLogCount)
                {
                    changelog.Description = descriptionBuilder.ToString().Trim() + '\n';
                    descriptionBuilder.Clear();
                    this.Add(changelog);
                    changelog = null;
                }
            };

            string lastLine = string.Empty;
            foreach (var line in fileContent.Split("\n").Select(line => line.Trim()))
            {
                if (line == string.Empty && lastLine == string.Empty)
                {
                    continue;
                }
                lastLine = line;

                if (line.StartsWith("#"))
                {
                    if (line.StartsWith("# ")) // 一级标题
                    {
                        continue;
                    }

                    if (line.StartsWith("## ")) // 二级标题，格式为 [未发布] 或 [1.0.0] - 2023-06-03
                    {
                        commitChangelog();
                        if (this.Count >= maxLogCount)
                        {
                            break;
                        }

                        changelog = new Changelog();
                        ParseTitleAndDate(ref changelog, line);

                        continue;
                    }
                }

                descriptionBuilder.Append(line);
                descriptionBuilder.Append('\n');
            }

            commitChangelog();
        }

        private static void ParseTitleAndDate(ref Changelog changelog, string line)
        {
            string title = line.TrimStart(new char[] { '#', ' ' });
            string[] parts = title.Split('-', 2).Select(str => str.Trim()).ToArray();

            string versionString = parts[0];
            string dateString = "";
            if (parts.Length >= 2)
            {
                dateString = parts[1];
            }

            changelog.Date = dateString != string.Empty ? DateOnly.Parse(dateString) : null;
            changelog.Version = versionString;
        }
    }
}
