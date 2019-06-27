namespace SchedulerOptimizerEngine.UnitTest
{

    public class CourseClassDiscipline : BaseDomainEntity
    {
        public CourseClassDiscipline(string name, int quantity)
        {
            Discipline = new Discipline { Name = name };
            Quantity = quantity;
        }
        public Discipline Discipline { get; set; }
        public int Quantity { get; set; }
    }
}