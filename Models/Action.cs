using System.Collections.Generic;

namespace CMSGame
{
    public abstract class Action
    {
        public string Name;

        public ActionTargetTypes TargetType;

        public List<IActionTarget> Targets;

        public IActionTarget Target => Targets.Count > 0 ? Targets[0] : null;
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
