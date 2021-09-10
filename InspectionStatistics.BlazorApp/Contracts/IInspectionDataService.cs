using InspectionStatistics.BlazorApp.Services.Base;
using InspectionStatistics.BlazorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Contracts
{
    public interface IInspectionDataService
    {
        Task<List<InspectionListViewModel>> GetAllInspections();
        Task<InspectionDetailViewModel> GetInspectionById(Guid id);
        Task<ApiResponse<Guid>> CreateInspection(InspectionDetailViewModel inspectionDetailViewModel);
        Task<ApiResponse<Guid>> UpdateInspection(InspectionDetailViewModel inspectionDetailViewModel);
        Task<ApiResponse<Guid>> DeleteInspection(Guid id);
    }
}
