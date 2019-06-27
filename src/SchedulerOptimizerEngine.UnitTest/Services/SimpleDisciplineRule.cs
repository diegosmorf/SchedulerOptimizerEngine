using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SimpleDisciplineRule : IScheduleRule
    {
        public IEnumerable<SchedulerItem> Apply(CourseClass courseClass)
        {
            SchedulerTable table = new SchedulerTable();

            foreach (var courseClassDiscipline in courseClass.Disciplines)
            {
                while (courseClassDiscipline.Quantity > 0 && courseClass.ScheduleSlots.Any(x => x.IsAvailable))
                {
                    foreach (var slot in courseClass.ScheduleSlots)
                    {
                        if (slot.IsAvailable)
                        {
                            table.Items.Add(slot.MakeReservation(courseClassDiscipline));
                            break;
                        }
                    }
                }
            }

            return table.Items;
        }
    }
}