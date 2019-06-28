using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class MaximizeInfraResourceRule : IScheduleRule
    {
        public SchedulerTable Table { get; set; }
        public void Apply(CourseClass courseClass, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas)
        {
            foreach (var item in Table.Items.Where(x => x.CourseClass.Id == courseClass.Id && x.Resource == null))
            {
                var elegibleResources = resources.Where(x => x.MaxCapacity >= courseClass.NumberOfStudents).AsQueryable();

                if (item.Discipline != null)
                {
                    elegibleResources.Where(x => x.Type == item.Discipline.InfrastructureResourceType).AsQueryable();
                }

                foreach (var resource in elegibleResources.OrderBy(x => x.MaxCapacity))
                {
                    if (!Table.Items.Any(x =>
                            x.Resource?.Id == resource.Id
                            && x.WeekDay == item.WeekDay
                            && x.StartTime == item.StartTime
                            && x.EndTime == item.EndTime))
                    {
                        item.Resource = resource;
                    }
                }
            }
        }
    }
}