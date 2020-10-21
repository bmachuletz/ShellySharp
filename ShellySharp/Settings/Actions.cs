using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Actions
    {
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        [JsonProperty("names", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Names { get; set; }
    }

}
