namespace SchedulerOptimizerEngine.UnitTest
{

    public class Campus : BaseDomainEntity
    {
        public string Name { get; set; }
        public EducationInstitute Institue { get; set; }
    }
}