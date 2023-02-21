namespace CMSGame
{
    static class TimeHelper
    {
        /// <summary>获取自引擎启动后经过的时间。</summary>
        public static double GetTicks()
        {
            return Time.GetTicksMsec() / 1000.0;
        }

        /// <summary>将时间（单位为秒）格式化为字符串“时:分:秒.毫秒”。</summary>
        public static string FormatTime(double time)
        {
            return TimeSpan.FromSeconds(time).ToString("c");
        }
    }
}
