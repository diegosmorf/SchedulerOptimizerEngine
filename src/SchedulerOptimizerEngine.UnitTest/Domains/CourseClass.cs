using System.Collections.Generic;
using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class CourseClass
    {
        public CourseClass()
        {
            Disciplines = new List<CourseClassDiscipline>();
            ScheduleSlots = new List<CourseClassScheduleSlot>();
        }

        public EducationSegment Segment { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string Level { get; set; }

        public List<CourseClassDiscipline> Disciplines { get; internal set; }

        public List<CourseClassScheduleSlot> ScheduleSlots { get; internal set; }
    }
}