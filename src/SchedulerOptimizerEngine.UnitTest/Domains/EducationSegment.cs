namespace SchedulerOptimizerEngine.UnitTest
{

    public class EducationSegment : BaseDomainEntity
    {
        public string Name { get; set; }
        public EducationInstitue Institute { get; set; }
    }
}