using AutoMapper;
using InspectionStatistics.Application.Features.Departments.Commands.CreateDepartment;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsList;
using InspectionStatistics.Application.Features.Departments.Queries.GetDepartmentsListWithInspections;
using InspectionStatistics.Application.Features.Inspections;
using InspectionStatistics.Application.Features.Inspections.Commands.CreateInspection;
using InspectionStatistics.Application.Features.Inspections.Commands.UpdateInspection;
using InspectionStatistics.Application.Features.Inspections.Queries.GetInspectionDetail;
using InspectionStatistics.Application.Features.Orders.GetOrdersForMonth;
using InspectionStatistics.Domain.Entities;

namespace InspectionStatistics.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {   
            CreateMap<Inspection, CreateInspectionCommand>().ReverseMap();
            CreateMap<Inspection, UpdateInspectionCommand>().ReverseMap();
            CreateMap<Inspection, InspectionListVm>().ReverseMap();
            CreateMap<Inspection, InspectionDetailVm>().ReverseMap();
            CreateMap<Inspection, DepartmentInspectionDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>();
            CreateMap<Department, DepartmentListVm>();
            CreateMap<Department, DepartmentInspectionListVm>();
            CreateMap<Department, CreateDepartmentCommand>();
            CreateMap<Department, CreateDepartmentDto>();

            CreateMap<Order, OrdersForMonthDto>();

        }
    }
}
