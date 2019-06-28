using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public static class EnumParser
    {
        public static T ParseToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
