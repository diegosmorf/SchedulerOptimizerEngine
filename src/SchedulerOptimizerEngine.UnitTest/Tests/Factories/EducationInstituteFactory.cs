using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public class EducationInstituteFactory
    {
        public EducationInstitute Create()
        {
            return new EducationInstitute
            {
                Name = "Vereda Educação"
            };
        }
    }
}
