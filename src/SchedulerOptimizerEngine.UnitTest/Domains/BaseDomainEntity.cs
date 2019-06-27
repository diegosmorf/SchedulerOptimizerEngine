using System;

namespace SchedulerOptimizerEngine.UnitTest
{
    public abstract class BaseDomainEntity
    {
        protected BaseDomainEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}