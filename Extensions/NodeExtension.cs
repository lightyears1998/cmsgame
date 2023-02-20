using System;
using System.Threading.Tasks;

namespace CMSGame
{
    public static class NodeExtension
    {
        public static T GetAutoloadNode<T>(this Node parent, string autoloadName) where T : Node
        {
            return parent.GetNode<T>($"/root/{autoloadName}");
        }

        public static void GetAutoloadNode<T>(this Node parent, ref T node, string autoloadName) where T : Node
        {
            node = parent.GetAutoloadNode<T>(autoloadName);
        }

        public static T GetUniqueNode<T>(this Node parent, string uniqueName) where T : Node
        {
            return parent.GetNode<T>($"%{uniqueName}");
        }

        public static void GetUniqueNode<T>(this Node parent, ref T node, string uniqueName) where T : Node
        {
            node = parent.GetUniqueNode<T>(uniqueName);
        }
    }
}
