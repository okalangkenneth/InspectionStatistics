using InspectionStatistics.API.IntergrationTests.Base;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InspectionStatistics.API.IntergrationTests
{
    public class DepartmentControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DepartmentControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/department/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<DepartmentListVm>>(responseString);

            Assert.IsType<List<DepartmentListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
