using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    class SettingsResonse
    {
        public partial class SettingsResponse
        {
            [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
            public DeviceClass Device { get; set; }

            [JsonProperty("wifi_ap", NullValueHandling = NullValueHandling.Ignore)]
            public WifiAp WifiAp { get; set; }

            [JsonProperty("wifi_sta", NullValueHandling = NullValueHandling.Ignore)]
            public WifiSta WifiSta { get; set; }

            [JsonProperty("wifi_sta1", NullValueHandling = NullValueHandling.Ignore)]
            public WifiSta WifiSta1 { get; set; }

            [JsonProperty("mqtt", NullValueHandling = NullValueHandling.Ignore)]
            public Mqtt Mqtt { get; set; }

            [JsonProperty("coiot", NullValueHandling = NullValueHandling.Ignore)]
            public Coiot Coiot { get; set; }

            [JsonProperty("sntp", NullValueHandling = NullValueHandling.Ignore)]
            public Sntp Sntp { get; set; }

            [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
            public Login Login { get; set; }

            [JsonProperty("pin_code", NullValueHandling = NullValueHandling.Ignore)]
            public string PinCode { get; set; }

            [JsonProperty("name")]
            public object Name { get; set; }

            [JsonProperty("fw", NullValueHandling = NullValueHandling.Ignore)]
            public string Fw { get; set; }

            [JsonProperty("factory_reset_from_switch", NullValueHandling = NullValueHandling.Ignore)]
            public bool? FactoryResetFromSwitch { get; set; }

            [JsonProperty("discoverable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Discoverable { get; set; }

            [JsonProperty("build_info", NullValueHandling = NullValueHandling.Ignore)]
            public BuildInfo BuildInfo { get; set; }

            [JsonProperty("cloud", NullValueHandling = NullValueHandling.Ignore)]
            public Cloud Cloud { get; set; }

            [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
            public string Timezone { get; set; }

            [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
            public double? Lat { get; set; }

            [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
            public double? Lng { get; set; }

            [JsonProperty("tzautodetect", NullValueHandling = NullValueHandling.Ignore)]
            public bool? Tzautodetect { get; set; }

            [JsonProperty("tz_utc_offset", NullValueHandling = NullValueHandling.Ignore)]
            public long? TzUtcOffset { get; set; }

            [JsonProperty("tz_dst", NullValueHandling = NullValueHandling.Ignore)]
            public bool? TzDst { get; set; }

            [JsonProperty("tz_dst_auto", NullValueHandling = NullValueHandling.Ignore)]
            public bool? TzDstAuto { get; set; }

            [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
            public string Time { get; set; }

            [JsonProperty("unixtime", NullValueHandling = NullValueHandling.Ignore)]
            public long? Unixtime { get; set; }

            [JsonProperty("led_status_disable", NullValueHandling = NullValueHandling.Ignore)]
            public bool? LedStatusDisable { get; set; }

            [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
            public Actions Actions { get; set; }

            [JsonProperty("hwinfo", NullValueHandling = NullValueHandling.Ignore)]
            public Hwinfo Hwinfo { get; set; }

            [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
            public string Mode { get; set; }

            [JsonProperty("max_power", NullValueHandling = NullValueHandling.Ignore)]
            public long? MaxPower { get; set; }

            [JsonProperty("longpush_time", NullValueHandling = NullValueHandling.Ignore)]
            public long? LongpushTime { get; set; }

            [JsonProperty("relays", NullValueHandling = NullValueHandling.Ignore)]
            public Relay[] Relays { get; set; }

            [JsonProperty("rollers", NullValueHandling = NullValueHandling.Ignore)]
            public Roller[] Rollers { get; set; }
        }
    }
}
