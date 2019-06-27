using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class CourseClass : BaseDomainEntity
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

        public int NumberOfStudents { get; set; }

        public List<CourseClassDiscipline> Disciplines { get; internal set; }

        public List<CourseClassScheduleSlot> ScheduleSlots { get; internal set; }
    }
}