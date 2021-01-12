using RestSharp;

namespace JunoApiIntegration
{
    public abstract class JunoApi
    {
        protected RestClient client;
        protected string _privateToken;

        public JunoApi()
        {
            client = new RestClient("https://api.juno.com.br");
        }

        public JunoApi(string accessToken, string privateToken) : this()
        {
            client.AddDefaultHeader("Authorization", $"Bearer {accessToken}");

            _privateToken = privateToken;
        }
    }
}
