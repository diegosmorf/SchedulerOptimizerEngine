using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{
    public class CourseClassFactory : CourseClass
    {
        public string FileName { get; protected set; }

        public CourseClassFactory()
        {
            FileName = "CourseClasses.json";
        }

        public virtual IEnumerable<CourseClass> Create()
        {
            var inputFolder = AppDomain.CurrentDomain.BaseDirectory;
            var jsonList = JsonConvert.DeserializeObject<IEnumerable<CourseClassJson>>(File.ReadAllText(Path.Combine(inputFolder, "Configuration", FileName)));

            var courseClasses = new List<CourseClass>();
            var courseClassDisciplines = new CourseClassDisciplineFactory().Create();
            var courseClassScheduleSlots = new CourseClassSchedulerSlotFactory().Create();

            foreach (var item in jsonList)
            {
                for (int i = 0; i < item.NumberOfClasses; i++)
                {
                    var elegibleDisciplines = courseClassDisciplines.Where(x => x.Discipline.Level == item.Level && x.Discipline.Segment.Name == item.Segment);

                    courseClasses.Add(new CourseClass
                    {
                        Year = 2019,
                        Semester = 2,
                        NumberOfStudents = item.NumberOfStudents,
                        ScheduleSlots = courseClassScheduleSlots.ToList(),
                        Disciplines = elegibleDisciplines.ToList(),
                        Level = item.Level,
                        Segment = new EducationSegment { Name = item.Segment }
                    });
                }
            }

            return courseClasses;
        }

        public class CourseClassJson
        {
            public string Level { get; set; }
            public string Segment { get; set; }
            public int NumberOfClasses { get; set; }
            public int NumberOfRooms { get; set; }
            public int NumberOfStudents { get; set; }
            public int MaxStudentsByClass { get; set; }
        }
    }
}