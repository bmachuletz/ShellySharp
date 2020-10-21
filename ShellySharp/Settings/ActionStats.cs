using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class ActionsStats
    {
        [JsonProperty("skipped", NullValueHandling = NullValueHandling.Ignore)]
        public long? Skipped { get; set; }
    }
}
