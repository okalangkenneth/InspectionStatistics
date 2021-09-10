using InspectionStatistics.BlazorApp.Contracts;
using InspectionStatistics.BlazorApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Pages
{
    public partial class InspectionOverview
    {
        [Inject]
        public IInspectionDataService InspectionDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<InspectionListViewModel> Inspections { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Inspections = await InspectionDataService.GetAllInspections();
        }

        protected void AddNewInspection()
        {
            NavigationManager.NavigateTo("/inspectiondetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportInspections()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:28383/api/inspections/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }
    }
}
