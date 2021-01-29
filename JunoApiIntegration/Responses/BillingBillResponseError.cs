using System;
using System.Collections.Generic;

namespace JunoApiIntegration.Responses
{
    public class BillingBillResponseError : IBillingBillResponse
    {
        public DateTime Timestamp { get; set; }

        public int Status { get; set; }

        public string Error { get; set; }

        public List<Detail> Details { get; set; }

        public string Path { get; set; }
    }
}
