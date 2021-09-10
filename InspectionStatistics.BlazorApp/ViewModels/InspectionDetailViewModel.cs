using System;
using System.ComponentModel.DataAnnotations;

namespace InspectionStatistics.BlazorApp.ViewModels
{
    public class InspectionDetailViewModel
    {
        public Guid InspectionId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="The type of the inspection should be 50 characters or less")]
        public string InspectionType { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Price should be a positive value")]
        public int Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name of the client should be 50 characters or less")]
        public string Client { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")] 
        public string Description { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        public DepartmentViewModel Department { get; set; }
    }
}
