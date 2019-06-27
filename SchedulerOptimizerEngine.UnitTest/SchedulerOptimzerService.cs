namespace SchedulerOptimizerEngine.UnitTest
{

    public class SchedulerOptimzerService
    {
        public SchedulerTable GenerateCenario(CourseClass courseClass)
        {
            return new SchedulerTable();
        }

        public bool HasConflicts(SchedulerTable table)
        {
            return false;
        }
    }
}
