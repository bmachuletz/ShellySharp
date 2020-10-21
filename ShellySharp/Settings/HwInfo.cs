using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Hwinfo
    {
        [JsonProperty("hw_revision", NullValueHandling = NullValueHandling.Ignore)]
        public string HwRevision { get; set; }

        [JsonProperty("batch_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? BatchId { get; set; }
    }
}
