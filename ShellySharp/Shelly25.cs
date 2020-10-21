using Newtonsoft.Json;
using ShellySharp.Settings;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Http;

namespace ShellySharp
{
    public partial class Shelly25 : ShellyDevice
    {
        public event EventHandler RelaysLoaded;

        [JsonProperty("factory_reset_from_switch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FactoryResetFromSwitch { get; set; }

        [JsonProperty("led_status_disable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LedStatusDisable { get; set; }

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

        public Shelly25() : base() { }

        public Shelly25(string url) : base(url)
        {
            Shelly25_DeviceLoaded(this, null);

        }

        private void Shelly25_DeviceLoaded(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int x = 0; x < Relays.Count(); x++)
                {
                    string relayUrl = string.Format("{0}/settings/relay/{1}", deviceUrl, x);
                    var httpResponse = httpClient.GetStringAsync(relayUrl).Result;
                    Relays[x] = Relay.FromJson(httpResponse);
                    Relays[x].Parent = this;
                }
            }

        }

        protected virtual void OnRelaysLoaded(EventArgs e)
        {
            RelaysLoaded?.Invoke(this, e);
        }
    }


    public partial class Shelly25
    {
        public static ShellyDevice FromJson(string json) => JsonConvert.DeserializeObject<ShellyDevice>(json, ShellySharp.Converter.Settings);
    }

}
