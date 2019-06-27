namespace SchedulerOptimizerEngine.UnitTest
{
    public class Discipline : BaseDomainEntity
    {
        public string Name { get; set; }
        public InfrastructureResourceType InfrastructureResourceType { get; set; }
    }
}