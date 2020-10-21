using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public partial class Coiot
    {
        [JsonProperty("update_period", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatePeriod { get; set; }
    }
}
