using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public partial class WifiSta
    {
        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("ssid", NullValueHandling = NullValueHandling.Ignore)]
        public string Ssid { get; set; }

        [JsonProperty("ipv4_method", NullValueHandling = NullValueHandling.Ignore)]
        public string Ipv4Method { get; set; }

        [JsonProperty("ip")]
        public object Ip { get; set; }

        [JsonProperty("gw")]
        public object Gw { get; set; }

        [JsonProperty("mask")]
        public object Mask { get; set; }

        [JsonProperty("dns")]
        public object Dns { get; set; }
    }
}
