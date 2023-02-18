namespace CMSGame
{
    static class TimeHelper
    {
        public static string FormatTime(double time)
        {
            return TimeSpan.FromSeconds(time).ToString("c");
        }
    }
}
