using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerTable
    {
        public SchedulerTable()
        {
            Items = new List<SchedulerItem>();
        }
        public IEnumerable<SchedulerItem> Items { get; set; }

        public bool AddItem(SchedulerItem item)
        {
            //if (Items.Any(x =>
            //         x.Resource.Id == item.Resource.Id
            //         && x.WeekDay == item.WeekDay
            //         && x.StartTime == item.StartTime
            //         && x.EndTime == item.EndTime))
            //{
            //    return false;
            //}

            //if (Items.Any(x =>
            //         x.Teacher.Id == item.Teacher.Id
            //         && x.Assistant.Id == item.Assistant.Id
            //         && x.WeekDay == item.WeekDay
            //         && x.StartTime == item.StartTime
            //         && x.EndTime == item.EndTime))
            //{
            //    return false;
            //}

            ((List<SchedulerItem>)Items).Add(item);

            return true;
        }
    }
}
