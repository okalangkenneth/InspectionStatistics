using InspectionStatistics.Domain.Contracts.Persistence;
using InspectionStatistics.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Contracts.Persistence
{
    public interface IDepartmentRepository:IAsyncRepository<Department>
    {
        Task<List<Department>> GetDepartmentsWithInspections(bool includePassedEvents);
    }
}
