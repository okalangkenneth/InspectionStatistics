using InspectionStatistics.BlazorApp.Contracts;
using InspectionStatistics.BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Pages
{
    public partial class DepartmentOverview
    {
        [Inject]
        public IDepartmentDataService DepartmentDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<DepartmentInspectionsViewModel> Departments { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Departments = await DepartmentDataService.GetAllDepartmentsWithInspections(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if((bool)args.Value)
            {
                Departments = await DepartmentDataService.GetAllDepartmentsWithInspections(true);
            }
            else
            {
                Departments = await DepartmentDataService.GetAllDepartmentsWithInspections(false);
            }
        }
    }
}
