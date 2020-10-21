using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class StatusResponse
    {
        [JsonProperty("wifi_sta", NullValueHandling = NullValueHandling.Ignore)]
        public WifiSta WifiSta { get; set; }

        [JsonProperty("cloud", NullValueHandling = NullValueHandling.Ignore)]
        public Cloud Cloud { get; set; }

        [JsonProperty("mqtt", NullValueHandling = NullValueHandling.Ignore)]
        public Mqtt Mqtt { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public string Time { get; set; }

        [JsonProperty("unixtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Unixtime { get; set; }

        [JsonProperty("serial", NullValueHandling = NullValueHandling.Ignore)]
        public long? Serial { get; set; }

        [JsonProperty("has_update", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasUpdate { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }

        [JsonProperty("cfg_changed_cnt", NullValueHandling = NullValueHandling.Ignore)]
        public long? CfgChangedCnt { get; set; }

        [JsonProperty("actions_stats", NullValueHandling = NullValueHandling.Ignore)]
        public ActionsStats ActionsStats { get; set; }

        [JsonProperty("relays", NullValueHandling = NullValueHandling.Ignore)]
        public Relay[] Relays { get; set; }

        [JsonProperty("meters", NullValueHandling = NullValueHandling.Ignore)]
        public Meter[] Meters { get; set; }

        [JsonProperty("inputs", NullValueHandling = NullValueHandling.Ignore)]
        public Input[] Inputs { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        public double? Temperature { get; set; }

        [JsonProperty("overtemperature", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Overtemperature { get; set; }

        [JsonProperty("tmp", NullValueHandling = NullValueHandling.Ignore)]
        public Tmp Tmp { get; set; }

        [JsonProperty("update", NullValueHandling = NullValueHandling.Ignore)]
        public Update Update { get; set; }

        [JsonProperty("ram_total", NullValueHandling = NullValueHandling.Ignore)]
        public long? RamTotal { get; set; }

        [JsonProperty("ram_free", NullValueHandling = NullValueHandling.Ignore)]
        public long? RamFree { get; set; }

        [JsonProperty("fs_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? FsSize { get; set; }

        [JsonProperty("fs_free", NullValueHandling = NullValueHandling.Ignore)]
        public long? FsFree { get; set; }

        [JsonProperty("voltage", NullValueHandling = NullValueHandling.Ignore)]
        public double? Voltage { get; set; }

        [JsonProperty("uptime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Uptime { get; set; }
    }
}
