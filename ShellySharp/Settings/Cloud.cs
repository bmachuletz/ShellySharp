using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public partial class Cloud
    {
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("connected", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Connected { get; set; }
    }
}
