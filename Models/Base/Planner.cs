namespace CMSGame
{
    public abstract class Planner<TContext> where TContext : IGoalContext
    {
        public TContext Context;

        public Planner(TContext context)
        {
            Context = context;
        }

        public abstract Plan MakePlan();
    }
}
