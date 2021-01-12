using JunoApiIntegration.Responses;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public interface IJunoBalance
    {
        Task<BalanceResponse> GetBalanceAsync();
    }
}
