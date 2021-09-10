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
    public class DepartmentDataService : BaseDataService, IDepartmentDataService
    {
        private readonly IMapper _mapper;

        public DepartmentDataService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartments()
        {
            await AddBearerToken();

            var allDepartments = await _client.GetAllDepartmentsAsync();
            var mappedDepartments = _mapper.Map<ICollection<DepartmentViewModel>>(allDepartments);
            return mappedDepartments.ToList();

        }

        public async Task<List<DepartmentInspectionsViewModel>> GetAllDepartmentsWithInspections(bool includeHistory)
        {
            await AddBearerToken();

            var allDepartments = await _client.GetDepartmentsWithInspectionsAsync(includeHistory);
            var mappedDepartments = _mapper.Map<ICollection<DepartmentInspectionsViewModel>>(allDepartments);
            return mappedDepartments.ToList();

        }

        public async Task<ApiResponse<DepartmentDto>> CreateDepartment(DepartmentViewModel departmentViewModel)
        {
            try
            {
                ApiResponse<DepartmentDto> apiResponse = new ApiResponse<DepartmentDto>();
                CreateDepartmentCommand createDepartmentCommand = _mapper.Map<CreateDepartmentCommand>(departmentViewModel);
                var createDepartmentCommandResponse = await _client.AddDepartmentAsync(createDepartmentCommand);
                if (createDepartmentCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<DepartmentDto>(createDepartmentCommandResponse.Department);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createDepartmentCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<DepartmentDto>(ex);
            }
        }
    }
}