using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SimpleDisciplineRule : IScheduleRule
    {
        public SchedulerTable Table { get; set; }
        public void Apply(CourseClass courseClass, IEnumerable<InfrastructureResource> resources)
        {
            foreach (var courseClassDiscipline in courseClass.Disciplines)
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