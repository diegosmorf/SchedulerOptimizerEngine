using FluentAssertions;
using NUnit.Framework;
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
            table.Items.Count().Should().Be(courseClass.Disciplines.Count);
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

            var courseClass = new CourseClass();
            courseClass.Disciplines.Add(new CourseClassDiscipline("Matemática", 2));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Português", 1));
            courseClass.Disciplines.Add(new CourseClassDiscipline("Física", 1));

            //act
            var table = service.GenerateCenario(courseClass);
            var result = service.HasConflicts(table);

            //assert
            table.Should().NotBeNull();
            table.Items.Count().Should().Be(courseClass.Disciplines.Count);
            result.Should().BeFalse();
        }
    }

}
