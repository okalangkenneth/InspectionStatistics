using System.Net.Http;

namespace InspectionStatistics.BlazorApp.Services
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
        
    }
}
