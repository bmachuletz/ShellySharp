using Newtonsoft.Json;
using ShellySharp.Settings;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Http;
using ShellySharp.Interfaces;

namespace ShellySharp
{
    public partial class Shelly25 : ShellySwitch, IRelays, ISwitch
    {
        public event EventHandler RelaysLoaded;

        [JsonProperty("relays", NullValueHandling = NullValueHandling.Ignore)]
        public List<Relay> Relays { get; set; }

        [JsonProperty("rollers", NullValueHandling = NullValueHandling.Ignore)]
        public Roller[] Rollers { get; set; }

        [JsonIgnore]
        System.Threading.Timer updateRelayTimer;

        public Shelly25() : base() { }

        public Shelly25(string url) : base(url)
        {
            Shelly25_DeviceLoaded(this, null);
            
            updateRelayTimer = new System.Threading.Timer(UpdateRelays, null, 5000, 1000);
        }

        private void Shelly25_DeviceLoaded(object sender, EventArgs e)
        {
            UpdateRelays(null);
        }

        protected virtual void OnRelaysLoaded(EventArgs e)
        {
            RelaysLoaded?.Invoke(this, e);
        }


        // Timer Callback
        public void UpdateRelays(object state)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                for (int x = 0; x < Relays.Count(); x++)
                {
                    string relayUrl = string.Format("{0}/settings/relay/{1}", deviceUrl, x);
                    var httpResponse = httpClient.GetStringAsync(relayUrl).Result;
                    

                    Relays[x] = JsonConvert.DeserializeObject<Relay>(httpResponse);
                    Relays[x].Parent = this;
                    Relays[x].Id = x;
                }

                Console.WriteLine("Relays updated");
            }
        }
    }


    public partial class Shelly25
    {
        public static ShellyDevice FromJson(string json) => JsonConvert.DeserializeObject<ShellyDevice>(json, ShellySharp.Converter.Settings);
    }

}
