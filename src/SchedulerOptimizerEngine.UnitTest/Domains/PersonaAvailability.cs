namespace SchedulerOptimizerEngine.UnitTest
{
    public class PersonaAvailability : BaseDomainEntity
    {
        public Persona Persona { get; set; }
        public PersonaType Type { get; set; }
        public Discipline Discipline { get; set; }
        public int Priority { get; set; }
    }
}