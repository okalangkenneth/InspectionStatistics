using AutoMapper;
using InspectionStatistics.BlazorApp.Services;
using InspectionStatistics.BlazorApp.ViewModels;

namespace InspectionStatistics.BlazorApp.Profiles
{
    public class Mappings:Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor

            CreateMap<InspectionListVm, InspectionListViewModel>().ReverseMap();
            CreateMap<InspectionDetailVm, InspectionDetailViewModel>().ReverseMap();

            CreateMap<InspectionDetailViewModel, CreateInspectionCommand>().ReverseMap();
            CreateMap<InspectionDetailViewModel, UpdateInspectionCommand>().ReverseMap();

            CreateMap<DepartmentInspectionDto, InspectionNestedViewModel>().ReverseMap();

            CreateMap<DepartmentDto, DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentListVm, DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentInspectionListVm, DepartmentInspectionsViewModel>().ReverseMap();
            CreateMap<CreateDepartmentCommand, DepartmentViewModel>().ReverseMap();
            CreateMap<CreateDepartmentDto, DepartmentDto>().ReverseMap();

            CreateMap<PagedOrdersForMonthVm, PagedOrderForMonthViewModel>().ReverseMap();
            CreateMap<OrdersForMonthDto, OrdersForMonthListViewModel>().ReverseMap();
        }
    }
}
