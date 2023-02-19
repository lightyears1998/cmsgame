namespace CMSGame
{
    public static class NodeExtension
    {
        public static T GetUniqueNode<T>(this Node node, string uniqueName) where T : Node
        {
            return node.GetNode<T>($"%{uniqueName}");
        }
    }
}
