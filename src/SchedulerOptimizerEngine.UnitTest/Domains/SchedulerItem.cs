using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerItem
    {
        public CourseClass CourseClass { get; set; }
        public Discipline Discipline { get; set; }
        public Persona Teacher { get; set; }
        public Persona Assistant { get; set; }
        public InfrastructureResource Resource { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public int Score
        {
            get
            {
                var count = 0;
                if (Discipline != null) count++;
                if (Teacher != null) count++;
                if (Assistant != null) count++;
                if (Resource != null) count++;

                return count;
            }
        }
    }
}
