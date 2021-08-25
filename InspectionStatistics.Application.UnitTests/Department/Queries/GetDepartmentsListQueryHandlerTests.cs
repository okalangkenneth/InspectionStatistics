using AutoMapper;
using InspectionStatistics.Application.Features.Departments.Queries.GetCategoriesList;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList;
using InspectionStatistics.Application.Profiles;
using InspectionStatistics.Application.UnitTests.Mocks;
using InspectionStatistics.Domain.Contracts.Persistence;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using InspectionStatistics.Domain.Entities;

namespace InspectionStatistics.Application.UnitTests.Department.Queries
{
    public class GetDepartmentsListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Department>> _mockDepartmentRepository;

        public GetDepartmentsListQueryHandlerTests()
        {
            _mockDepartmentRepository = RepositoryMocks.GetDepartmentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetDepartmentsListQueryHandler(_mapper, _mockDepartmentRepository.Object);

            var result = await handler.Handle(new GetDepartmentsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<DepartmentListVm>>();

            result.Count.ShouldBe(4);
        }
    }
}
