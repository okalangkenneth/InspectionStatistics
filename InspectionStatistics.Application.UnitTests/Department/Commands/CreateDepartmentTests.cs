using AutoMapper;
using InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment;
using InspectionStatistics.Application.Profiles;
using InspectionStatistics.Application.UnitTests.Mocks;
using InspectionStatistics.Domain.Contracts.Persistence;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using InspectionStatistics.Domain.Entities;

namespace InspectionStatistics.Application.UnitTests.Department.Commands
{
    public class CreateDepartmentTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Department>> _mockDepartmentRepository;

        public CreateDepartmentTests()
        {
            _mockDepartmentRepository = RepositoryMocks.GetDepartmentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidDepartment_AddedToDepartmentsRepo()
        {
            var handler = new CreateDepartmentCommandHandler(_mapper, _mockDepartmentRepository.Object);

            await handler.Handle(new CreateDepartmentCommand() { Name = "Test" }, CancellationToken.None);

            var allDepartments = await _mockDepartmentRepository.Object.ListAllAsync();
            allDepartments.Count.ShouldBe(5);
        }
    }
}
