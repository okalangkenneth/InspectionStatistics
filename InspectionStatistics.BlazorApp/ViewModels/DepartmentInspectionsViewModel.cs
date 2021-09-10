using System;
using System.Collections.Generic;

namespace InspectionStatistics.BlazorApp.ViewModels
{
    public class DepartmentInspectionsViewModel
    {
        public Guid DepartmentId { get; set; }
        public string InspectionType { get; set; }
        public ICollection<InspectionNestedViewModel> Inspections { get; set; }
    }
}
