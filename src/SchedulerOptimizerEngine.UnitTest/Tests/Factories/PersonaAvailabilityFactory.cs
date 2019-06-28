using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public class PersonaAvailabilityFactory : CourseClass
    {
        public string FileName { get; protected set; }

        public PersonaAvailabilityFactory()
        {
            FileName = "PersonaAvailabilities.json";
        }
        public virtual IEnumerable<PersonaAvailability> Create()
        {
            var inputFolder = AppDomain.CurrentDomain.BaseDirectory;
            var jsonList = JsonConvert.DeserializeObject<IEnumerable<PersonaJson>>(File.ReadAllText(Path.Combine(inputFolder, "Configuration", FileName)));

            var personas = new List<PersonaAvailability>();

            foreach (var item in jsonList)
            {
                personas.Add(new PersonaAvailability
                {
                    Discipline = new Discipline { Name = item.Discipline },
                    Type = PersonaType.Teacher,
                    Persona = new Persona { Name = item.Teacher, Contract = PersonaHireContract.Monthly, Profile = PersonaProfile.Specialist },
                    Priority = 1
                });
            }

            return personas;
        }

        public class PersonaJson
        {
            public string Teacher { get; set; }
            public string Discipline { get; set; }
        }
    }
}
