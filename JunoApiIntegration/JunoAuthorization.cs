using JunoApiIntegration.Extensions;
using JunoApiIntegration.Responses;
using RestSharp;
using System.Threading.Tasks;

namespace JunoApiIntegration
{
    public sealed class JunoAuthorization : JunoApi, IJunoAuthorization
    {
        private string _basicCredentials;

        public JunoAuthorization(string clientId, string clientSecret) : base()
        {
            _basicCredentials = $"{clientId}:{clientSecret}".Base64Encode();
        }

        public async Task<TokenResponse> GenerateTokenAsync()
        {
            var request = new RestRequest("authorization-server/oauth/token?grant_type=client_credentials", DataFormat.Json);

            request.AddHeader("Authorization", $"Basic {_basicCredentials}");

            return await client.PostAsync<TokenResponse>(request);
        }
    }
}
