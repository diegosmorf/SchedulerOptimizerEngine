namespace SchedulerOptimizerEngine.UnitTest
{
    public class Discipline : BaseDomainEntity
    {
        public string Name { get; set; }
        public EducationSegment Segment { get; set; }
        public string Level { get; set; }
        public InfrastructureResourceType InfrastructureResourceType { get; set; }
    }
}