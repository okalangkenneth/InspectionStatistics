using InspectionStatistics.Domain.Entities;
using InspectionStatistics.Persistence;
using System;

namespace InspectionStatistics.API.IntergrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(InspectionStatisticsDbContext context)
        {
            var quantityControlGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var qualityControlGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var cleanlinessControlGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var pestControlGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            context.Departments.Add(new Department
            {
                DepartmentId = quantityControlGuid,
                InspectionType = "Quantity Control"
            });
            context.Departments.Add(new Department
            {
                DepartmentId = qualityControlGuid,
                InspectionType = "Quality Controls"
            });
            context.Departments.Add(new Department
            {
                DepartmentId = cleanlinessControlGuid,
                InspectionType = "Cleanliness Controls"
            });
            context.Departments.Add(new Department
            {
                DepartmentId = pestControlGuid,
                InspectionType = "Pest Controls"
            });

            context.SaveChanges();
        }
    }
}
