using InspectionStatistics.BlazorApp.ViewModels;
using System;
using System.Threading.Tasks;

namespace InspectionStatistics.BlazorApp.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
