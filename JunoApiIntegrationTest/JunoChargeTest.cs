using JunoApiIntegration;
using JunoApiIntegration.Requests;
using JunoApiIntegration.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace JunoApiIntegrationTest
{
    public class JunoChargeTest : JunoApiTests
    {
        [Fact]
        public async Task GetChargesTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
            var chargeResponse = await charge.GetCharges();

            Assert.NotNull(chargeResponse);
        }

        [Fact]
        public async Task GetChargeTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
            var chargeResponse = await charge.GetCharge("chr_BB8434E0E7905ACCE01834F0EFBC71AA");

            Assert.NotNull(chargeResponse);
        }

        [Fact]
        public async Task GenerateBillingBillTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
            var body = new ChargeRequest
            {
                Charge = new Charge
                {
                    Description = "Cobrança Test - XUnit",
                    References = new List<string> { "Uma simples referencia para teste 2 - XUnit" },
                    Amount = 22.45,
                    Fine = 3,
                    Interest = "2.4",
                    DueDate = DateTime.Now.AddDays(10).ToString("yyyy-MM-dd"),
                    MaxOverdueDays = 3,
                    PaymentAdvance = true
                },
                Billing = new Billing
                {
                    Name = "Joao da Silva Sauro",
                    Document = "82738475589",
                    Email = "joao.silva.sauro@gmail.com",
                    Phone = "+5581732141290",
                    //BirthDate = "1968-03-21",
                    Notify = false
                }
            };
            var chargeResponse = await charge.GenerateBillingBillAsync(body);

            if (chargeResponse is BillingBillResponseSuccess)
            {
                Assert.NotNull(((BillingBillResponseSuccess)chargeResponse).Embedded);
            }
            else if (chargeResponse is BillingBillResponseError)
            {
                Assert.NotNull(((BillingBillResponseError)chargeResponse).Error);
                Assert.NotEmpty(((BillingBillResponseError)chargeResponse).Error);
            }

            Assert.NotNull(null);
        }

        [Fact]
        public async Task CancelBillingBillTestAsync()
        {
            var auth = new JunoAuthorization(_clientId, _clientSecret);
            var tokenResponse = await auth.GenerateTokenAsync();

            Assert.NotNull(tokenResponse);
            Assert.NotNull(tokenResponse.AccessToken);
            Assert.NotEmpty(tokenResponse.AccessToken);

            var charge = new JunoCharge(tokenResponse.AccessToken, _privateToken);
            var chargeResponse = await charge.CancelBillingBillAsync("chr_BB8434E0E7905ACCE01834F0EFBC71AA");

            Assert.True(chargeResponse);
        }
    }
}
