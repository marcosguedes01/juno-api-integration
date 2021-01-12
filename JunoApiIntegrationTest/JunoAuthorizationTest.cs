using JunoApiIntegration;
using System.Threading.Tasks;
using Xunit;

namespace JunoApiIntegrationTest
{
    public class JunoAuthorizationTest: JunoApiTests
    {
        [Fact]
        public async Task GenerateTokenTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var response = await auth.GenerateTokenAsync();

            Assert.NotNull(response);
            Assert.NotNull(response.AccessToken);
            Assert.NotEmpty(response.AccessToken);
        }
    }
}
