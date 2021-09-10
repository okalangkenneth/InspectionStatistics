using AutoMapper;
using Blazored.LocalStorage;
using InspectionStatistics.BlazorApp.Contracts;
using InspectionStatistics.BlazorApp.Services.Base;
using InspectionStatistics.BlazorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Services
{
    public class InspectionDataService: BaseDataService, IInspectionDataService
    {
        
        private readonly IMapper _mapper;

        public InspectionDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<InspectionListViewModel>> GetAllInspections()
        {
            var allInspections = await _client.GetAllInspectionsAsync();
            var mappedInspections = _mapper.Map<ICollection<InspectionListViewModel>>(allInspections);
            return mappedInspections.ToList();
        }

        public async Task<InspectionDetailViewModel> GetInspectionById(Guid id)
        {
            var selectedInspection = await _client.GetInspectionByIdAsync(id);
            var mappedInspection = _mapper.Map<InspectionDetailViewModel>(selectedInspection);
            return mappedInspection;
        }

        public async Task<ApiResponse<Guid>> CreateInspection(InspectionDetailViewModel inspectionDetailViewModel)
        {
            try
            {
                CreateInspectionCommand createInspectionCommand = _mapper.Map<CreateInspectionCommand>(inspectionDetailViewModel);
                var newId = await _client.AddInspectionAsync(createInspectionCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateInspection(InspectionDetailViewModel inspectionDetailViewModel)
        {
            try
            {
                UpdateInspectionCommand updateInspectionCommand = _mapper.Map<UpdateInspectionCommand>(inspectionDetailViewModel);
                await _client.UpdateInspectionAsync(updateInspectionCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteInspection(Guid id)
        {
            try
            {
                await _client.DeleteInspectionAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
