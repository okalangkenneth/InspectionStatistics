using InspectionStatistics.Domain.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using InspectionStatistics.Domain.Entities;

namespace InspectionStatistics.Application.UnitTests.Mocks
{
    public  class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Department>> GetDepartmentRepository()
        {
            var quantityControlGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var qualityControlGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var cleanlinessControlGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var pestControlGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentId = quantityControlGuid,
                    Name = "Quality Controls"
                },
                new Department
                {
                    DepartmentId = qualityControlGuid,
                    Name = "Quality Controls"
                },
                new Department
                {
                    DepartmentId = cleanlinessControlGuid,
                    Name = "Cleanliness Controls"
                },
                 new Department
                {
                    DepartmentId = pestControlGuid,
                    Name = "Pest Controls"
                }
            };

            var mockDepartmentRepository = new Mock<IAsyncRepository<Department>>();
            mockDepartmentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(departments);

            mockDepartmentRepository.Setup(repo => repo.AddAsync(It.IsAny<department>())).ReturnsAsync(
                (Department department) =>
                {
                    departments.Add(department);
                    return department;
                });

            return mockDepartmentRepository;
        }
    }
}

