using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerTable
    {
        public SchedulerTable()
        {
            Items = new List<SchedulerItem>();
        }
        public List<SchedulerItem> Items { get; set; }
    }
}
