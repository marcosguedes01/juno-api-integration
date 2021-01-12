using JunoApiIntegration.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public sealed class JunoBalance : JunoApi, IJunoBalance
    {
        public JunoBalance(string accessToken, string privateToken) : base(accessToken, privateToken)
        {
        }

        public async Task<BalanceResponse> GetBalanceAsync()
        {
            var request = new RestRequest("balance", DataFormat.Json);

            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("X-Resource-Token", _privateToken);

            return await client.GetAsync<BalanceResponse>(request);
        }
    }
}
