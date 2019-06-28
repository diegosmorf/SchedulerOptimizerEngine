using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchedulerOptimizerEngine.UnitTest.Tests.Factories
{

    public class InfraResourceClassFactory : CourseClass
    {
        public string FileName { get; protected set; }

        public InfraResourceClassFactory()
        {
            FileName = "InfraResources.json";
        }
        public virtual IEnumerable<InfrastructureResource> Create()
        {
            var inputFolder = AppDomain.CurrentDomain.BaseDirectory;
            var jsonList = JsonConvert.DeserializeObject<IEnumerable<InfrastructureResourceJson>>(File.ReadAllText(Path.Combine(inputFolder, "Configuration", FileName)));

            var resources = new List<InfrastructureResource>();
            var campusBuilding = new CampusBuildingFactory().Create();

            foreach (var item in jsonList)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    resources.Add(new InfrastructureResource
                    {
                        Building = campusBuilding,
                        Name = $"{item.ResourceType} - {i}",
                        Type = item.ResourceType.ParseToEnum<InfrastructureResourceType>(),
                        MaxCapacity = item.MaxCapacity
                    });
                }
            }

            return resources;
        }

        public class InfrastructureResourceJson
        {
            public string ResourceType { get; set; }
            public int Quantity { get; set; }
            public int MaxCapacity { get; set; }
        }
    }
}
