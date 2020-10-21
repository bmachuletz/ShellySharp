using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public partial class Mqtt
    {
        [JsonProperty("enable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enable { get; set; }

        [JsonProperty("server", NullValueHandling = NullValueHandling.Ignore)]
        public string Server { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("reconnect_timeout_max", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconnectTimeoutMax { get; set; }

        [JsonProperty("reconnect_timeout_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReconnectTimeoutMin { get; set; }

        [JsonProperty("clean_session", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CleanSession { get; set; }

        [JsonProperty("keep_alive", NullValueHandling = NullValueHandling.Ignore)]
        public long? KeepAlive { get; set; }

        [JsonProperty("max_qos", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxQos { get; set; }

        [JsonProperty("retain", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Retain { get; set; }

        [JsonProperty("update_period", NullValueHandling = NullValueHandling.Ignore)]
        public long? UpdatePeriod { get; set; }
    }
}
