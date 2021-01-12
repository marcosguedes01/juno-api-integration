using JunoApiIntegration;
using System.Threading.Tasks;
using Xunit;

namespace JunoApiIntegrationTest
{
    public class JunoBalanceTest : JunoApiTests
    {
        [Fact]
        public async Task GetBalanceTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var balance = new JunoBalance(tokenResponse.AccessToken, _privateToken);
            var balanceResponse = await balance.GetBalanceAsync();

            Assert.NotNull(balanceResponse);
        }
    }
}
