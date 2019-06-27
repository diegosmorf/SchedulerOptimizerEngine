namespace SchedulerOptimizerEngine.UnitTest
{
    public class Persona : BaseDomainEntity
    {
        public string Name { get; set; }
        public PersonaProfile Profile { get; set; }
        public PersonaHireContract Contract { get; set; }
    }
}