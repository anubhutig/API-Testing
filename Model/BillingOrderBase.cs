using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_july2021.Model
{
    public class BillingOrderBase
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public BillingOrderN Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
