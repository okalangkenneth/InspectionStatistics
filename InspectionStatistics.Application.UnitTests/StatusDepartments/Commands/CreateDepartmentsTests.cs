using AutoMapper;
using InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment;
using InspectionStatistics.Application.Profiles;
using InspectionStatistics.Application.UnitTests.Mocks;
using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InspectionStatistics.Application.UnitTests.StatusDepartments.Commands
{
    public class CreateDepartmentsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Department>> _mockDepartmentRepository;

        public CreateDepartmentsTests()
        {
            _mockDepartmentRepository = RepositoryMocks.GetDepartmentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateDepartmentCommandHandler(_mapper, _mockDepartmentRepository.Object);

            await handler.Handle(new CreateDepartmentCommand() { InspectionType = "Test" }, CancellationToken.None);

            var allCategories = await _mockDepartmentRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }
    }
}
