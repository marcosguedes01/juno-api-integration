using JunoApiIntegration.Responses;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public interface IJunoAuthorization
    {
        Task<TokenResponse> GenerateTokenAsync();
    }
}
