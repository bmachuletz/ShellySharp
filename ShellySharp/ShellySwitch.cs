using Newtonsoft.Json;
using ShellySharp.Interfaces;
using ShellySharp.Resources;
using ShellySharp.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ShellySharp
{
    public abstract class ShellySwitch : ShellyDevice, ISwitch, IMaxPower, ILEDStatusDisable, ILongPushTime
    {
        public ShellySwitch() : base() { }

        public ShellySwitch(string url) : base(url)
        {
            Console.WriteLine("Instantiated ShellySwitch");
        }

        [JsonProperty("factory_reset_from_switch", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FactoryResetFromSwitch { get; set; }

        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty("max_power", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxPower { get; set; }
        
        [JsonProperty("led_status_disable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LedStatusDisable { get; set; }

        [JsonProperty("longpush_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? LongpushTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SetFactoryResetFromSwitchEnabled(bool enable)
        {
            string statusUrl = string.Format("{0}?factory_reset_from_switch=", settingsUrl, enable.ToString());

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
                StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
            }
        }

        public void SetLedStatusDisable(bool disabled)
        {
            string statusUrl = string.Format("{0}?led_status_disable={0}", settingsUrl, disabled.ToString()); ;

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
                //  StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
            }
        }

        public void SetLongPushTime(long pushtime)
        {
            string statusUrl = string.Format("{0}?longpush_time={0}", settingsUrl, pushtime.ToString()); ;

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
                //  StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
            }
        }

        public void SetMaxPower(long powerInWatts)
        {
            if (Mode == DeviceMode.roller.ToString())
            {
                string statusUrl = string.Format("{0}?max_power={0}", settingsUrl, powerInWatts.ToString()); ;

                using (HttpClient httpClient = new HttpClient())
                {
                    var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
                    //  StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
                }
            }
        }

        public void SetMode(DeviceMode mode)
        {
            string statusUrl = string.Format("{0}?mode={0}", settingsUrl, mode.ToString()); ;

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
              //  StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
            }
        }
    }
}
