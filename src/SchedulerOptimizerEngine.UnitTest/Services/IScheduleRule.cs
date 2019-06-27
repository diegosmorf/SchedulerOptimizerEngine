using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public interface IScheduleRule
    {
        IEnumerable<SchedulerItem> Apply(CourseClass courseClass);
    }


}
