namespace CMSGame
{
    /// <summary>
    /// 2D 战场坐标
    /// </summary>
    public class BattleFieldPosition
    {
        /// <summary>
        /// 坐标点相对于 2D 摄像机镜头所在竖直平面的距离
        /// </summary>
        public int Depth;

        /// <summary>
        /// 坐标点相对于 2D 摄像机初始对准位置的偏移量
        /// </summary>
        public int Offset;
    }
}
