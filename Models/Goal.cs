using System.Collections.Generic;

namespace CMSGame
{
    public class Goal<TContext>
    {
        public string Name = string.Empty;

        public int BasePriority;

        public List<GoalValidityModifier<TContext>> ValidityModifiers = new();

        public List<GoalPriorityModifier<TContext>> PriorityModifiers = new();

        public bool IsValid()
        {
            return ValidityModifiers.All(modifier => modifier.Execute());
        }

        public int Priority()
        {
            return BasePriority + PriorityModifiers.Sum(modifier => modifier.Execute());
        }
    }

    public abstract class GoalModifier<TContext>
    {
        public string Name = string.Empty;

        public TContext Context;

        protected GoalModifier(TContext context)
        {
            Context = context;
        }
    }

    public abstract class GoalValidityModifier<TContext> : GoalModifier<TContext>
    {
        protected GoalValidityModifier(TContext context) : base(context)
        {
        }

        public abstract bool Execute();
    }

    public abstract class GoalPriorityModifier<TContext> : GoalModifier<TContext>
    {
        protected GoalPriorityModifier(TContext context) : base(context)
        {
        }

        public abstract int Execute();
    }
}
