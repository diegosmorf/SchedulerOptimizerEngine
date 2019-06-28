using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public class CourseClassDisciplineFactory : CourseClass
    {
        public string FileName { get; protected set; }

        public CourseClassDisciplineFactory()
        {
            FileName = "Disciplines.json";
        }
        public virtual IEnumerable<CourseClassDiscipline> Create()
        {
            var inputFolder = AppDomain.CurrentDomain.BaseDirectory;
            var jsonList = JsonConvert.DeserializeObject<IEnumerable<DisciplineJson>>(File.ReadAllText(Path.Combine(inputFolder, "Configuration", FileName)));

            var courseClassDiscipline = new List<CourseClassDiscipline>();

            foreach (var item in jsonList)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    courseClassDiscipline.Add(new CourseClassDiscipline
                    {
                        Discipline = new Discipline
                        {
                            Name = item.Discipline,
                            Level = item.Level,
                            Segment = new EducationSegment { Name = item.Segment, Institute = new EducationInstituteFactory().Create() },
                            InfrastructureResourceType = InfrastructureResourceType.ClassRoom
                        },
                        Priority = 0,
                        Quantity = item.Quantity
                    });
                }
            }

            return courseClassDiscipline;
        }

        public class DisciplineJson
        {
            public string Segment { get; set; }
            public string Level { get; set; }
            public string Discipline { get; set; }
            public int Quantity { get; set; }
        }
    }
}
