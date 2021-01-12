using JunoApiIntegration.Requests;
using JunoApiIntegration.Responses;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public interface IJunoCharge
    {
        Task<ChargeListResponse> GetCharges();
        Task<ChargeResponse> GetCharge(string chargeId);
        Task<BillingBillResponse> GenerateBillingBillAsync(ChargeRequest body);
        Task<bool> CancelBillingBillAsync(string chargeId);
    }
}
