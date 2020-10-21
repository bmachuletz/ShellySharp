using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ShellySharp.Settings
{
    public partial class Relay
    {
        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("ison", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Ison { get; set; }

        [JsonProperty("has_timer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasTimer { get; set; }

        [JsonProperty("default_state", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultState { get; set; }

        [JsonProperty("btn_type", NullValueHandling = NullValueHandling.Ignore)]
        public string BtnType { get; set; }

        [JsonProperty("btn_reverse", NullValueHandling = NullValueHandling.Ignore)]
        public long? BtnReverse { get; set; }

        [JsonProperty("auto_on", NullValueHandling = NullValueHandling.Ignore)]
        public long? AutoOn { get; set; }

        [JsonProperty("auto_off", NullValueHandling = NullValueHandling.Ignore)]
        public long? AutoOff { get; set; }

        [JsonProperty("max_power", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxPower { get; set; }

        [JsonProperty("btn_on_url", NullValueHandling = NullValueHandling.Ignore)]
        public string BtnOnUrl { get; set; }

        [JsonProperty("btn_off_url", NullValueHandling = NullValueHandling.Ignore)]
        public string BtnOffUrl { get; set; }

        [JsonProperty("out_on_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OutOnUrl { get; set; }

        [JsonProperty("out_off_url", NullValueHandling = NullValueHandling.Ignore)]
        public string OutOffUrl { get; set; }

        [JsonProperty("longpush_url", NullValueHandling = NullValueHandling.Ignore)]
        public string LongpushUrl { get; set; }

        [JsonProperty("shortpush_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortpushUrl { get; set; }

        [JsonProperty("schedule", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Schedule { get; set; }

        [JsonProperty("schedule_rules", NullValueHandling = NullValueHandling.Ignore)]
        public object[] ScheduleRules { get; set; }

        [JsonIgnore]
        public ShellyDevice Parent { get; set; }

        // Relay-Parameter
        string turn = "turn";

        public static Relay FromJson(string json) => JsonConvert.DeserializeObject<Relay>(json);

        public void SwitchOn()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(string.Format("{0}/relay/0?{1}=on", Parent.deviceUrl, "turn")).Result;
            }
        }

        public void SwitchOff()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(string.Format("{0}/relay/0?{1}=off", Parent.deviceUrl, "turn")).Result;
            }
        }

        public void SwitchToggle()
        {

        }
    }
}
