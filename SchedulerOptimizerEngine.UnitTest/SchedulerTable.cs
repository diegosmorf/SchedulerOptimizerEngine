﻿using System.Collections.Generic;

namespace SchedulerOptimizerEngine.UnitTest
{
    public class SchedulerTable
    {
        public SchedulerTable()
        {
            Items = new List<SchedulerItem>();
        }
        public IEnumerable<SchedulerItem> Items { get; set; }
    }
}