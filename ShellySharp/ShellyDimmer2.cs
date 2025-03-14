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
        public event EventHandler<DeviceSwitchedEventArgs> LightSwitched;

        [JsonIgnore]
        System.Threading.Timer updateLightTimer;

        [JsonProperty("lights", NullValueHandling = NullValueHandling.Ignore)]
        public List<Light> Lights { get; set; }

        public ShellyDimmer2() : base() { }

        public ShellyDimmer2(string url) : base(url)
        {
            ShellyDimmer2_DeviceLoaded(this, null);
            
            updateLightTimer = new System.Threading.Timer(UpdateLights, null, 5000, 5000);
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
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    for (int x = 0; x < Lights.Count(); x++)
                    {
                        string relayUrl = string.Format("{0}/settings/light/{1}", deviceUrl, x);
                        var httpResponse = httpClient.GetStringAsync(relayUrl).Result;

                        Light light = JsonConvert.DeserializeObject<Light>(httpResponse);


                        List<Variance> variances = light.DetailedCompare(Lights[x]);

                        variances.ForEach(variance =>
                        {
                            Console.WriteLine("Property {0} changed from {1} to {2}.", variance.Prop, variance.valB, variance.valA);

                            if (variance.valA != null && variance.valB != null)
                            {
                                Lights[x].GetType().GetProperty(variance.Prop).SetValue(Lights[x], variance.valA);

                                if (variance.Prop.Equals("Ison"))
                                {
                                    LightSwitched?.Invoke(this, new DeviceSwitchedEventArgs { Device = this, IsOn = light.Ison });
                                }
                            }
                        });

                        Lights[x].Parent = this;
                        Lights[x].Id = x;

                        //                    Console.WriteLine("Lights updated");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("================================================================================================");
                Console.WriteLine("Can`t Updates Lights");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("================================================================================================");
            }
            
        }
    }


    public partial class ShellyDimmer2
    {
        public static ShellyDevice FromJson(string json) => JsonConvert.DeserializeObject<ShellyDevice>(json, ShellySharp.Converter.Settings);
    }

}
