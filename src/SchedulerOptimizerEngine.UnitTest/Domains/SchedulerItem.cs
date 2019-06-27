using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerItem
    {
        public Discipline Discipline { get; set; }
        public Persona Teacher { get; set; }
        public Persona Assistant { get; set; }
        public InfrastructureResource Resource { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DayOfWeek WeekDay { get { return StartDate.DayOfWeek; } }
    }
}
