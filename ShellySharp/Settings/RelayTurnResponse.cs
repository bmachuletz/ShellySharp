using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class RelayTurnResponse
    {
        [JsonProperty("ison", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ison { get; set; }

        [JsonProperty("has_timer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasTimer { get; set; }

        [JsonProperty("timer_started", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimerStarted { get; set; }

        [JsonProperty("timer_duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimerDuration { get; set; }

        [JsonProperty("timer_remaining", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimerRemaining { get; set; }

        [JsonProperty("overpower", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Overpower { get; set; }

        [JsonProperty("overtemperature", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Overtemperature { get; set; }

        [JsonProperty("is_valid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsValid { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
    }
}
