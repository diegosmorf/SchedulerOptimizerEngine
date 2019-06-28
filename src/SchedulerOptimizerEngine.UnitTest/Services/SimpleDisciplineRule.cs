using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SimpleDisciplineRule : IScheduleRule
    {
        public SchedulerTable Table { get; set; }
        public void Apply(CourseClass courseClass, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas)
        {
            foreach (var courseClassDiscipline in courseClass.Disciplines.OrderBy(x => x.Priority))
            {
                for (int i = 0; i < courseClassDiscipline.Quantity; i++)
                {
                    var item = Table.Items.FirstOrDefault(x =>
                                x.CourseClass.Id == courseClass.Id
                                && x.Discipline == null);

                    if (item != null)
                    {
                        item.Discipline = courseClassDiscipline.Discipline;
                    }
                }
            }
        }
    }
}