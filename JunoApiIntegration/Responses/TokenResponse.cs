using Newtonsoft.Json;

namespace JunoApiIntegration.Responses
{
    public sealed class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("jti")]
        public string Jti { get; set; }
    }
}
