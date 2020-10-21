using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Input
    {
        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public long? InputInput { get; set; }

        [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
        public string Event { get; set; }

        [JsonProperty("event_cnt", NullValueHandling = NullValueHandling.Ignore)]
        public long? EventCnt { get; set; }
    }
}
