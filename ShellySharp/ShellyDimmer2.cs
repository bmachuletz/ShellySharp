using Newtonsoft.Json;
using ShellySharp.Settings;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Http;
using ShellySharp.Interfaces;

namespace ShellySharp
{
    public partial class ShellyDimmer2 : ShellySwitch, ILights
    {
        public event EventHandler RelaysLoaded;

        [JsonIgnore]
        System.Threading.Timer updateLightTimer;

        [JsonProperty("lights", NullValueHandling = NullValueHandling.Ignore)]
        public List<Light> Lights { get; set; }

        public ShellyDimmer2() : base() { }

        public ShellyDimmer2(string url) : base(url)
        {
            ShellyDimmer2_DeviceLoaded(this, null);
            
            updateLightTimer = new System.Threading.Timer(UpdateLights, null, 5000, 1000);
        }

        private void ShellyDimmer2_DeviceLoaded(object sender, EventArgs e)
        {
            UpdateLights(null);
        }

        protected virtual void OnRelaysLoaded(EventArgs e)
        {
            RelaysLoaded?.Invoke(this, e);
        }


        // Timer Callback

        public void UpdateLights(object state)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int x = 0; x < Lights.Count(); x++)
                {
                    string relayUrl = string.Format("{0}/settings/light/{1}", deviceUrl, x);
                    var httpResponse = httpClient.GetStringAsync(relayUrl).Result;


                    Lights[x] = JsonConvert.DeserializeObject<Light>(httpResponse);
                    Lights[x].Parent = this;
                    Lights[x].Id = x;
                }

                Console.WriteLine("Lights updated");
            }
        }
    }


    public partial class ShellyDimmer2
    {
        public static ShellyDevice FromJson(string json) => JsonConvert.DeserializeObject<ShellyDevice>(json, ShellySharp.Converter.Settings);
    }

}
