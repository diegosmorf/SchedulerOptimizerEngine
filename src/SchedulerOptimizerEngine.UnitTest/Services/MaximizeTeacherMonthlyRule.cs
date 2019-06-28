using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class MaximizeTeacherMonthlyRule : IScheduleRule
    {
        public SchedulerTable Table { get; set; }
        public void Apply(CourseClass courseClass, IEnumerable<InfrastructureResource> resources, IEnumerable<PersonaAvailability> personas)
        {
            var elegibleTeachers = personas
                                        .Where(x =>
                                            x.Type == PersonaType.Teacher
                                            && x.Persona.Contract == PersonaHireContract.Monthly
                                            && courseClass.Disciplines.Any(d => d.Discipline.Name == x.Discipline.Name))
                                        .OrderBy(x => x.Priority);

            foreach (var teacher in elegibleTeachers)
            {
                var elegibleDisciplines = courseClass.Disciplines.Where(d => d.Discipline.Name == teacher.Discipline.Name);

                foreach (var courseClassDiscipline in elegibleDisciplines)
                {
                    for (int i = 0; i < courseClassDiscipline.Quantity; i++)
                    {
                        var item = Table.Items.FirstOrDefault(x =>
                                    x.CourseClass.Id == courseClass.Id
                                    && x.Discipline != null
                                    && x.Teacher == null);

                        if (item != null)
                        {
                            item.Discipline = courseClassDiscipline.Discipline;
                            item.Teacher = teacher.Persona;
                        }
                        else
                        {
                            var item2 = Table.Items.FirstOrDefault(x =>
                                    x.CourseClass.Id == courseClass.Id
                                    && x.Discipline == null
                                    && x.Teacher == null);

                            if (item2 != null)
                            {
                                item2.Discipline = courseClassDiscipline.Discipline;
                                item2.Teacher = teacher.Persona;
                            }
                        }
                    }
                }
            }
        }
    }
}