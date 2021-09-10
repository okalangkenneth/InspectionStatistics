using InspectionStatistics.BlazorApp.Contracts;
using InspectionStatistics.BlazorApp.Services;
using InspectionStatistics.BlazorApp.Services.Base;
using InspectionStatistics.BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Pages
{
    public partial class AddDepartment
    {
        [Inject]
        public IDepartmentDataService DepartmentDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public DepartmentViewModel DepartmentViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            DepartmentViewModel = new DepartmentViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await DepartmentDataService.CreateDepartment(DepartmentViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<DepartmentDto> response)
        {
            if (response.Success)
            {
                Message = "Department added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
