using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerTests
    {
        [Test]
        public void WhenGenerateCenario_Then_ReturnScheduleList()
        {
            //arrange
            var service = new SchedulerOptimzerService();

            var courseClass = new CourseClass();

            //act
            var table = service.GenerateCenario(courseClass);

            //assert
            table.Should().NotBeNull();
            table.Items.Count.Should().Be(courseClass.Disciplines.Count);
        }

        [Test]
        public void WhenGenerateCenario_Then_CannotExistConflicts()
        {
            //arrange
            var service = new SchedulerOptimzerService();

            var courseClass = new CourseClass();

            //act
            var table = service.GenerateCenario(courseClass);
            var result = service.HasConflicts(table);

            //assert
            result.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateCenarioWith3Discipline_Then_ReturnScheduleListWith3Items()
        {
            //arrange
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
            var table = service.GenerateCenario(courseClass);
            var result = service.HasConflicts(table);

            //assert
            table.Should().NotBeNull();
            table.Items.Count.Should().Be(courseClass.Disciplines.Count);
            result.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateCenarioWith3DisciplineAnd1Slot_Then_ReturnScheduleListWith1Item()
        {
            //arrange
            var service = new SchedulerOptimzerService();
            service.RegisterRule(new SimpleDisciplineRule());

            var courseClass = new CourseClass();
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 1));

            courseClass.ScheduleSlots.Add(new CourseClassScheduleSlot() { WeekDay = DayOfWeek.Monday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(9) });

            //act
            var table = service.GenerateCenario(courseClass);
            var result = service.HasConflicts(table);

            //assert
            table.Should().NotBeNull();
            table.Items.Count.Should().Be(1);
            table.Items.First().Discipline.Name.Should().Be("Matemática");
            result.Should().BeFalse();
        }

        [Test]
        public void WhenGenerateCenarioWith10DisciplineAnd10Slots_Then_ReturnScheduleListWith10Item()
        {
            //arrange
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
            var table = service.GenerateCenario(courseClass);
            var result = service.HasConflicts(table);

            //assert
            table.Should().NotBeNull();
            table.Items.Count.Should().Be(10);
            table.Items[0].Discipline.Name.Should().Be("Matemática");
            table.Items[1].Discipline.Name.Should().Be("Matemática");
            table.Items[2].Discipline.Name.Should().Be("Matemática");
            table.Items[3].Discipline.Name.Should().Be("Matemática");
            table.Items[4].Discipline.Name.Should().Be("Português");
            table.Items[5].Discipline.Name.Should().Be("Português");
            table.Items[6].Discipline.Name.Should().Be("Português");
            table.Items[7].Discipline.Name.Should().Be("Português");
            table.Items[8].Discipline.Name.Should().Be("Física");
            table.Items[9].Discipline.Name.Should().Be("Física");
            result.Should().BeFalse();
        }
    }
}
