using InspectionStatistics.Application.Models.Authentication;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

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

        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body)
        {
            throw new System.NotImplementedException();
        }

        public Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest body)
        {
            throw new System.NotImplementedException();
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest body, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
