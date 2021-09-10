using System;

namespace InspectionStatistics.BlazorApp.ViewModels
{
    public class InspectionListViewModel
    {
        public Guid InspectionId { get; set; }
        public string InspectionType { get; set; }
        public DateTime Date { get; set; }
        
    }
}
