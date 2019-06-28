using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerOptimizerService
    {
        private readonly List<IScheduleRule> rules;
        private readonly SchedulerTable table;

        public SchedulerOptimizerService()
        {
            rules = new List<IScheduleRule>();
            table = new SchedulerTable();
        }

        public void RegisterRule(IScheduleRule rule)
        {
            rules.Add(rule);
        }

        public SchedulerTable GenerateCenario(IEnumerable<CourseClass> courseClasses, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas)
        {
            foreach (var courseClass in courseClasses)
            {
                GenerateCenario(courseClass, resources, personas);
            }

            return table;
        }

        public SchedulerTable GenerateCenario(CourseClass courseClass, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas)
        {
            GenerateEmptyScheduleItems(courseClass);

            foreach (var rule in rules)
            {
                rule.Table = table;
                rule.Apply(courseClass, resources, personas);
            }

            return table;
        }

        private void GenerateEmptyScheduleItems(CourseClass courseClass)
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
        }

        public bool HasConflicts()
        {
            if (table.Items.GroupBy(x => new
            {
                x.Resource?.Id,
                x.WeekDay,
                x.StartTime,
                x.EndTime
            }).Any(x => x.Count() > 1))
            {
                return true;
            }

            if (table.Items.GroupBy(x => new
            {
                x.Teacher?.Id,
                x.WeekDay,
                x.StartTime,
                x.EndTime
            }).Any(x => x.Count() > 1))
            {
                return true;
            }

            //if (table.Items.GroupBy(x => new
            //{
            //    x.Assistant?.Id,
            //    x.WeekDay,
            //    x.StartTime,
            //    x.EndTime
            //}).Any(x => x.Count() > 1))
            //{
            //    return true;
            //}

            return false;
        }
    }
}
