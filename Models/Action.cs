using System.Collections.Generic;

namespace CMSGame
{
    public abstract class Action
    {
        public string Name = string.Empty;

        public ActionTargetTypes TargetType;

        public List<IActionTarget> Targets = new();

        public IActionTarget? Target => Targets.Count > 0 ? Targets[0] : null;
    }

    public enum ActionTargetTypes
    {
        None,
        Single,
        Multiple
    }

    public interface IActionTarget
    {
    }
}
