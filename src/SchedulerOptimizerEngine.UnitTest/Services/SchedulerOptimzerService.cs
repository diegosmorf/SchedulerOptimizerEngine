using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerOptimzerService
    {
        private readonly List<IScheduleRule> rules;

        public SchedulerOptimzerService()
        {
            rules = new List<IScheduleRule>();
        }

        public void RegisterRule(IScheduleRule rule)
        {
            rules.Add(rule);
        }

        public SchedulerTable GenerateCenario(CourseClass courseClass)
        {
            SchedulerTable table = new SchedulerTable();

            foreach(var rule in rules)
            {
                table.Items.AddRange(rule.Apply(courseClass));
            }

            return table;
        }

        public bool HasConflicts(SchedulerTable table)
        {
            return false;
        }
    }
}
