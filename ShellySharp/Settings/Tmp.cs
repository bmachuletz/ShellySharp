using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Tmp
    {
        [JsonProperty("tC", NullValueHandling = NullValueHandling.Ignore)]
        public double? TC { get; set; }

        [JsonProperty("tF", NullValueHandling = NullValueHandling.Ignore)]
        public double? TF { get; set; }

        [JsonProperty("is_valid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsValid { get; set; }
    }
}
