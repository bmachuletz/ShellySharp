using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Update
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("has_update", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasUpdate { get; set; }

        [JsonProperty("new_version", NullValueHandling = NullValueHandling.Ignore)]
        public string NewVersion { get; set; }

        [JsonProperty("old_version", NullValueHandling = NullValueHandling.Ignore)]
        public string OldVersion { get; set; }
    }
}
