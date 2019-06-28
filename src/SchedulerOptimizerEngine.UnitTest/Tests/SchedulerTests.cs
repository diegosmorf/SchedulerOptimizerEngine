using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerTests
    {
        [Test]
        public void WhenGenerateThenCannotExistConflicts()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            var service = new SchedulerOptimzerService();
            var courseClass = new CourseClass();

            //act
            service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            hasConflicts.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateWith3DisciplineThenReturnScheduleListWith3Items()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            var service = new SchedulerOptimzerService();
            service.RegisterRule(new SimpleDisciplineRule());

            var courseClass = new CourseClass();
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 1));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(12), EndTime = TimeSpan.FromHours(13) });

            //act
            var table = service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(courseClass.Disciplines.Count);
            hasConflicts.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateWith3DisciplineAnd1SlotThenReturnScheduleListWith1Item()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            var service = new SchedulerOptimzerService();
            service.RegisterRule(new SimpleDisciplineRule());

            var courseClass = new CourseClass();
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 1));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });

            //act
            var table = service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(1);
            table.Items.First().Discipline.Name.Should().Be("Matemática");
            hasConflicts.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateWith10DisciplineAnd10SlotsThenReturnScheduleListWith10Item()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            var service = new SchedulerOptimzerService();
            service.RegisterRule(new SimpleDisciplineRule());

            var courseClass = new CourseClass();
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 2));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });

            //act
            var table = service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            table.Should().NotBeNull();
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(10);
            ((List<SchedulerItem>)table.Items)[0].Discipline.Name.Should().Be("Matemática");
            ((List<SchedulerItem>)table.Items)[1].Discipline.Name.Should().Be("Matemática");
            ((List<SchedulerItem>)table.Items)[2].Discipline.Name.Should().Be("Matemática");
            ((List<SchedulerItem>)table.Items)[3].Discipline.Name.Should().Be("Matemática");
            ((List<SchedulerItem>)table.Items)[4].Discipline.Name.Should().Be("Português");
            ((List<SchedulerItem>)table.Items)[5].Discipline.Name.Should().Be("Português");
            ((List<SchedulerItem>)table.Items)[6].Discipline.Name.Should().Be("Português");
            ((List<SchedulerItem>)table.Items)[7].Discipline.Name.Should().Be("Português");
            ((List<SchedulerItem>)table.Items)[8].Discipline.Name.Should().Be("Física");
            ((List<SchedulerItem>)table.Items)[9].Discipline.Name.Should().Be("Física");
            hasConflicts.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateWith1ResourceThenScheduleList10()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            resources.Add(new InfrastructureResource
            {
                Name = "Sala 1",
                Type = InfrastructureResourceType.Room,
                MaxCapacity = 50,
                Building = new CampusBuilding
                {
                    Name = "Prédio 1",
                    Campus = new Campus
                    {
                        Name = "Santo André",
                        Institue = new EducationInstitue
                        {
                            Name = "Vereda Educação"
                        }
                    }
                }
            });

            var service = new SchedulerOptimzerService();
            service.RegisterRule(new SimpleDisciplineRule());
            service.RegisterRule(new MaximizeInfraResourceRule());

            var courseClass = new CourseClass();
            courseClass.NumberOfStudents = 50;
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 2));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });

            //act
            var table = service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(10);

            foreach (var item in table.Items)
            {
                item.Discipline.Should().NotBeNull();
                item.Resource.Should().NotBeNull();
            }

            hasConflicts.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateOnlyResourceRuleThenScheduleList10()
        {
            //arrange
            var personas = new List<PersonaAvailability>();
            var resources = new List<InfrastructureResource>();
            resources.Add(new InfrastructureResource
            {
                Name = "Sala 1",
                Type = InfrastructureResourceType.Room,
                MaxCapacity = 50,
                Building = new CampusBuilding
                {
                    Name = "Prédio 1",
                    Campus = new Campus
                    {
                        Name = "Santo André",
                        Institue = new EducationInstitue
                        {
                            Name = "Vereda Educação"
                        }
                    }
                }
            });

            var service = new SchedulerOptimzerService();
            service.RegisterRule(new MaximizeInfraResourceRule());

            var courseClass = new CourseClass();
            courseClass.NumberOfStudents = 50;
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 4));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 2));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Thursday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });
            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Friday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(11) });

            //act
            var table = service.GenerateCenario(courseClass, resources, personas);
            var hasConflicts = service.HasConflicts();

            //assert
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(10);

            foreach (var item in table.Items)
            {
                item.Discipline.Should().BeNull();
                item.Resource.Should().NotBeNull();
            }

            hasConflicts.Should().BeFalse();
        }
    }
}
