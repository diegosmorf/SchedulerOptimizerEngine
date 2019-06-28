using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{
    public abstract class BaseTestFactory<TEntity> : ITestFactory<TEntity> where TEntity : BaseDomainEntity
    {
        public string FileName { get; protected set; }

        public virtual IEnumerable<TEntity> Create()
        {
            var inputFolder = AppDomain.CurrentDomain.BaseDirectory;
            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(File.ReadAllText(Path.Combine(inputFolder, "Configuration", FileName)));
        }
    }
}
