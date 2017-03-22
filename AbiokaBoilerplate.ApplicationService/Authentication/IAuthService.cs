using AbiokaBoilerplate.ApplicationService.Abstractions;
using AbiokaBoilerplate.ApplicationService.Messaging;
using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using System.Threading.Tasks;

namespace AbiokaBoilerplate.ApplicationService.Authentication
{
    public interface IAuthService : IService
    {
        Task<string> LoginAsync(AuthRequest request);

        Task<string> RefreshTokenAsync(string refreshToken);

        AuthProvider Provider { get; }
    }
}
