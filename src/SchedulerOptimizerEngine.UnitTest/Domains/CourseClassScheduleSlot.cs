using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class CourseClassScheduleSlot
    {
        public CourseClassScheduleSlot()
        {
            IsAvailable = true;
        }
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; protected set; }

        public void Allocate()
        {
            IsAvailable = false;
        }

        public void Deallocate()
        {
            IsAvailable = true;
        }
    }
}