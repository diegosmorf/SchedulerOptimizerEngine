namespace SchedulerOptimizerEngine.UnitTest
{
    public interface IScheduleRule
    {
        SchedulerTable Table { get; set; }
        void Apply(CourseClass courseClass, System.Collections.Generic.IEnumerable<InfrastructureResource> resources);
    }


}
