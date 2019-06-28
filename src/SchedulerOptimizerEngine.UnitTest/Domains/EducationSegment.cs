namespace SchedulerOptimizerEngine.UnitTest
{

    public class EducationSegment : BaseDomainEntity
    {
        public string Name { get; set; }
        public EducationInstitute Institute { get; set; }
    }
}