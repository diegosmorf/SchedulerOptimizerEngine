using System;
using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public class CourseClassSchedulerSlotFactory : CourseClass
    {
        public IEnumerable<CourseClassScheduleSlot> Create()
        {
            var scheduleSlots = new List<CourseClassScheduleSlot>();

            CreateDay(scheduleSlots, DayOfWeek.Monday);
            CreateDay(scheduleSlots, DayOfWeek.Tuesday);
            CreateDay(scheduleSlots, DayOfWeek.Wednesday);
            CreateDay(scheduleSlots, DayOfWeek.Thursday);
            CreateDay(scheduleSlots, DayOfWeek.Friday);

            return scheduleSlots;
        }

        private void CreateDay(List<CourseClassScheduleSlot> scheduleSlots, DayOfWeek dayOfWeek)
        {
            scheduleSlots.Add(CreateSlot(dayOfWeek, 7, 8));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 8, 9));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 9, 10));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 10, 11));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 11, 12));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 13, 14));
            scheduleSlots.Add(CreateSlot(dayOfWeek, 14, 15));

        }
        private CourseClassScheduleSlot CreateSlot(DayOfWeek dayOfWeek, int startTime, int endTime)
        {
            return new CourseClassScheduleSlot()
            {
                WeekDay = dayOfWeek,
                StartTime = TimeSpan.FromHours(startTime),
                EndTime = TimeSpan.FromHours(endTime)
            };
        }
    }
}