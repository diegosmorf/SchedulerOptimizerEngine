using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SimpleDisciplineRule: IScheduleRule
    {
        public IEnumerable<SchedulerItem> Apply(CourseClass courseClass)
        {
            SchedulerTable table = new SchedulerTable();
            
            foreach(var classDiscipline in courseClass.Disciplines)
            {
                foreach(var slot in courseClass.ScheduleSlots)
                {
                    if(slot.IsAvailable)
                    {
                        table.Items.Add(slot.MakeReservation(classDiscipline.Discipline));
                        break;
                    }
                }
            }            
            
            return table.Items;
        }
    }
}