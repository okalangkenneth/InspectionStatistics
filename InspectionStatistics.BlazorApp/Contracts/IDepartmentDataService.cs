using InspectionStatistics.BlazorApp.Services;
using InspectionStatistics.BlazorApp.Services.Base;
using InspectionStatistics.BlazorApp.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Contracts
{
    public interface IDepartmentDataService
    {
        Task<List<DepartmentViewModel>> GetAllDepartments();
        Task<List<DepartmentInspectionsViewModel>> GetAllDepartmentsWithInspections(bool includeHistory);
        Task<ApiResponse<DepartmentDto>> CreateDepartment(DepartmentViewModel departmentViewModel);
    }
}
