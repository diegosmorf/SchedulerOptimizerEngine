namespace SchedulerOptimizerEngine.UnitTest
{
    public class InfrastructureResource : BaseDomainEntity
    {
        public string Name { get; set; }
        public CampusBuilding Building { get; set; }
        public InfrastructureResourceType Type { get; set; }
        public int MaxCapacity { get; set; }
    }
}