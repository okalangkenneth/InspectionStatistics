
using System.Net.Http;

namespace InspectionStatistics.BlazorApp.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        
    }
}
