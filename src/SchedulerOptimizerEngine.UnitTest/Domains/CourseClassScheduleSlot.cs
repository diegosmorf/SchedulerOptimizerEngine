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
        public TimeSpan StartTime{get; set;}
        public TimeSpan EndTime{get; set;}
        public bool IsAvailable{get; set;}

        public SchedulerItem MakeReservation(Discipline discipline)
        {
            IsAvailable = false;

            return new SchedulerItem(){ 
                                StartTime = StartTime, 
                                EndTime = EndTime,  
                                WeekDay = WeekDay,
                                Discipline = discipline};                        
        }
    }
}