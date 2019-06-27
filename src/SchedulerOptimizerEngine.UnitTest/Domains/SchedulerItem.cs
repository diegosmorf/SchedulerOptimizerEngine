using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerItem
    {
        public Discipline Discipline { get; set; }
        public Persona Teacher { get; set; }
        public Persona Assistant { get; set; }
        public InfrastructureResource Resource { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}
