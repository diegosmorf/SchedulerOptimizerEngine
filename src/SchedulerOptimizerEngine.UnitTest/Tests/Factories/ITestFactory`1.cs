using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{
    public interface ITestFactory<TEntity> where TEntity : BaseDomainEntity
    {
        string FileName { get; }
        IEnumerable<TEntity> Create();
    }
}
