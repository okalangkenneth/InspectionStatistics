using InspectionStatistics.BlazorApp.Contracts;
using InspectionStatistics.BlazorApp.Services.Base;
using InspectionStatistics.BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Pages
{
    public partial class InspectionDetails
    {
        [Inject]
        public IInspectionDataService InspectionDataService { get; set; }

        [Inject]
        public IDepartmentDataService DepartmentDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public InspectionDetailViewModel InspectionDetailViewModel { get; set; } 
            = new InspectionDetailViewModel() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<DepartmentViewModel> Departments { get; set; } 
            = new ObservableCollection<DepartmentViewModel>();

        public string Message { get; set; }
        public string SelectedDepartmentId { get; set; }

        [Parameter]
        public string InspectionId { get; set; }
        private Guid SelectedInspectionId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(InspectionId, out SelectedInspectionId))
            {
                InspectionDetailViewModel = await InspectionDataService.GetInspectionById(SelectedInspectionId);
                SelectedDepartmentId = InspectionDetailViewModel.DepartmentId.ToString();
            }

            var list = await DepartmentDataService.GetAllDepartments();
            Departments = new ObservableCollection<DepartmentViewModel>(list);
            SelectedDepartmentId = Departments.FirstOrDefault().DepartmentId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            InspectionDetailViewModel.DepartmentId = Guid.Parse(SelectedDepartmentId);
            ApiResponse<Guid> response;

            if (SelectedInspectionId == Guid.Empty)
            {
                response = await InspectionDataService.CreateInspection(InspectionDetailViewModel);
            }
            else
            {
                 response = await InspectionDataService.UpdateInspection(InspectionDetailViewModel);
            }
            HandleResponse(response);

        }

        protected async Task DeleteInspection()
        {
            var response = await InspectionDataService.DeleteInspection(SelectedInspectionId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/inspectionoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/inspectionoverview");
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
