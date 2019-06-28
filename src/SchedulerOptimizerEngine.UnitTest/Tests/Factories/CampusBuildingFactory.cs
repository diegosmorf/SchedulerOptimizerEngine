using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{


    public class CampusBuildingFactory
    {
        public CampusBuilding Create()
        {
            return new CampusBuilding
            {
                Name = "Prédio 1",
                Campus = new Campus
                {
                    Name = "Santo André",
                    Institue = new EducationInstituteFactory().Create()
                }
            };
        }
    }
}
