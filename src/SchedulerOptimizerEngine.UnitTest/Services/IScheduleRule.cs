using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public interface IScheduleRule
    {
        SchedulerTable Table { get; set; }
        void Apply(CourseClass courseClass, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas);
    }
}
