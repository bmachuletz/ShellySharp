using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public partial class BuildInfo
    {
        [JsonProperty("build_id", NullValueHandling = NullValueHandling.Ignore)]
        public string BuildId { get; set; }

        [JsonProperty("build_timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? BuildTimestamp { get; set; }

        [JsonProperty("build_version", NullValueHandling = NullValueHandling.Ignore)]
        public string BuildVersion { get; set; }
    }
}
