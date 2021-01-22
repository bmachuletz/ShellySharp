using System;
using System.Collections.Generic;

using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShellySharp.Settings
{
    public partial class Light
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ison")]
        public bool Ison { get; set; }

        [JsonProperty("default_state")]
        public string DefaultState { get; set; }

        [JsonProperty("auto_on")]
        public long AutoOn { get; set; }

        [JsonProperty("auto_off")]
        public long AutoOff { get; set; }

        [JsonProperty("schedule")]
        public bool Schedule { get; set; }

        [JsonProperty("schedule_rules")]
        public List<object> ScheduleRules { get; set; }

        [JsonProperty("btn_type")]
        public string BtnType { get; set; }

        [JsonProperty("btn_debounce")]
        public long BtnDebounce { get; set; }

        [JsonProperty("swap_inputs")]
        public long SwapInputs { get; set; }


        [JsonIgnore]
        public ShellyDevice Parent { get; set; }

        [JsonIgnore]
        public int Id { get; set; }




        private void UpdateLight(object state)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(string.Format("{0}/light/{1}", Parent.deviceUrl, Id)).Result;
           // DIMMER TODO      
           //     RelayTurnResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<RelayTurnResponse>(result);
           //     this.Ison = (bool)response.Ison;

            }
        }

        public void SwitchOn()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(string.Format("{0}/light/{1}?turn=on", Parent.deviceUrl, Id)).Result;
                // DIMMER TODO      
                //RelayTurnResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<RelayTurnResponse>(result);
                //this.Ison = (bool)response.Ison;
            }
        }

        public void SwitchOff()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var result = httpClient.GetStringAsync(string.Format("{0}/light/{1}?turn=off", Parent.deviceUrl, Id)).Result;
                // DIMMER TODO      
                //RelayTurnResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<RelayTurnResponse>(result);
                //this.Ison = (bool)response.Ison;
            }
        }

    }


}
