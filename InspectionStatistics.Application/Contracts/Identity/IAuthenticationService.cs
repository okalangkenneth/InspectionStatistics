using InspectionStatistics.Application.Models.Authentication;
using System.Threading.Tasks;

namespace InspectionStatistics.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
