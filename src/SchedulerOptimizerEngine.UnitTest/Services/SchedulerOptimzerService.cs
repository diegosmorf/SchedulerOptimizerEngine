using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerOptimzerService
    {
        private readonly List<IScheduleRule> rules;
        private readonly SchedulerTable table;

        public SchedulerOptimzerService()
        {
            rules = new List<IScheduleRule>();
            table = new SchedulerTable();
        }

        public void RegisterRule(IScheduleRule rule)
        {
            rules.Add(rule);
        }

        public SchedulerTable GenerateCenario(IEnumerable<CourseClass> courseClasses, IEnumerable<InfrastructureResource> resources)
        {
            foreach (var courseClass in courseClasses)
            {
                GenerateCenario(courseClass, resources);
            }

            return table;
        }

        public SchedulerTable GenerateCenario(CourseClass courseClass, IEnumerable<InfrastructureResource> resources)
        {
            foreach (var slot in courseClass.ScheduleSlots)
            {
                if (slot.IsAvailable)
                {
                    var item = new SchedulerItem()
                    {
                        StartTime = slot.StartTime,
                        EndTime = slot.EndTime,
                        WeekDay = slot.WeekDay,
                        CourseClass = courseClass
                    };

                    table.AddItem(item);
                }
            }

            foreach (var rule in rules)
            {
                rule.Table = table;
                rule.Apply(courseClass, resources);
            }

            return table;
        }

        public bool HasConflicts(SchedulerTable table)
        {
            return false;
        }
    }
}
