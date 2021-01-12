using JunoApiIntegration.Requests;
using JunoApiIntegration.Responses;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public sealed class JunoCharge : JunoApi, IJunoCharge
    {
        public JunoCharge(string accessToken, string privateToken) : base(accessToken, privateToken)
        {
        }

        public async Task<ChargeListResponse> GetCharges()
        {
            var request = new RestRequest("charges", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<ChargeListResponse>(request);
        }

        public async Task<ChargeResponse> GetCharge(string chargeId)
        {
            var request = new RestRequest($"charges/{chargeId}", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<ChargeResponse>(request);
        }

        public async Task<BillingBillResponse> GenerateBillingBillAsync(ChargeRequest body)
        {
            var request = new RestRequest("charges", DataFormat.Json)
                .AddJsonBody(JsonConvert.SerializeObject(body));

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.PostAsync<BillingBillResponse>(request);
        }

        public async Task<bool> CancelBillingBillAsync(string chargeId)
        {
            var request = new RestRequest($"charges/{chargeId}/cancelation", Method.PUT);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            var response = await client.ExecuteAsync(request);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}
