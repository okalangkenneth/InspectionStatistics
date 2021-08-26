using InspectionStatistics.Application.Contracts;
using InspectionStatistics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace InspectionStatistics.Persistence.IntergrationTests
{
    public class InspectionStatisticsDbContextTests
    {
        private readonly InspectionStatisticsDbContext _inspectionStatisticsDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public InspectionStatisticsDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<InspectionStatisticsDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _inspectionStatisticsDbContext = new InspectionStatisticsDbContext(dbContextOptions);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ins = new Inspection() { InspectionId = Guid.NewGuid(), InspectionType = "Test inspection" };

            _inspectionStatisticsDbContext.Inspections.Add(ins);
            await _inspectionStatisticsDbContext.SaveChangesAsync();

            ins.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
