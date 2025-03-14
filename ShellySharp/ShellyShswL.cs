using Newtonsoft.Json;
using ShellySharp.Settings;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Http;
using ShellySharp.Interfaces;

namespace ShellySharp
{
    public partial class ShellyShswL : ShellySwitch, IRelays, ISwitch
    {
        public event EventHandler RelaysLoaded;
        public event EventHandler<DeviceSwitchedEventArgs> RelaySwitched;

        [JsonProperty("relays", NullValueHandling = NullValueHandling.Ignore)]
        public List<Relay> Relays { get; set; }

        [JsonProperty("rollers", NullValueHandling = NullValueHandling.Ignore)]
        public Roller[] Rollers { get; set; }

        [JsonIgnore]
        System.Threading.Timer updateRelayTimer;

        public ShellyShswL() : base() { }

        public ShellyShswL(string url) : base(url)
        {
            ShellyShswL_DeviceLoaded(this, null);
            
            updateRelayTimer = new System.Threading.Timer(UpdateRelays, null, 5000, 2000);
        }

        private void ShellyShswL_DeviceLoaded(object sender, EventArgs e)
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
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    for (int x = 0; x < Relays.Count(); x++)
                    {
                        string relayUrl = string.Format("{0}/settings/relay/{1}", deviceUrl, x);
                        var httpResponse = httpClient.GetStringAsync(relayUrl).Result;


                        Relay rel = JsonConvert.DeserializeObject<Relay>(httpResponse);

                        List<Variance> variances = rel.DetailedCompare(Relays[x]);

                        variances.ForEach(variance =>
                        {
                            Console.WriteLine("Property {0} changed from {1} to {2}.", variance.Prop, variance.valB, variance.valA);

                            if (variance.valA != null && variance.valB != null)
                            {
                                Relays[x].GetType().GetProperty(variance.Prop).SetValue(Relays[x], variance.valA);

                                if (variance.Prop.Equals("Ison"))
                                {
                                    RelaySwitched?.Invoke(this, new DeviceSwitchedEventArgs { Device = this, IsOn = rel.Ison });
                                }
                            }
                        });

                        /*
                        if (rel.Ison != Relays[x].Ison)
                        {

                            Relays[x].Ison = rel.Ison;
                        }
                        */
                        //   Relays[x] = rel;
                        Relays[x].Parent = this;
                        Relays[x].Id = x;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("================================================================================================");
                Console.WriteLine("Can`t Updates Relay");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("================================================================================================");
            }
        }
    }


    public partial class ShellyShswL
    {
        public static ShellyDevice FromJson(string json) => JsonConvert.DeserializeObject<ShellyDevice>(json, ShellySharp.Converter.Settings);
    }

}
