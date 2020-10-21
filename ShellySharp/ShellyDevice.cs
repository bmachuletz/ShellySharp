using System;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Newtonsoft.Json;


namespace ShellySharp
{
    public abstract partial class ShellyDevice
    {
        public event EventHandler DeviceLoaded;

        public string deviceUrl;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }

        [JsonProperty("wifi_sta", NullValueHandling = NullValueHandling.Ignore)]
        public WifiSta wifista { get; set; }

        [JsonProperty("cloud", NullValueHandling = NullValueHandling.Ignore)]
        public WifiAp wifiap { get; set; }



        protected virtual void OnDeviceLoaded(EventArgs e)
        {
            DeviceLoaded?.Invoke(this, e);
        }

        public ShellyDevice() { }

        public ShellyDevice(string url)
        {
            deviceUrl = url;

            string settingsUrl = string.Format("{0}/settings", deviceUrl);
            string deviceInformationUrl = string.Format("{0}/shelly", deviceUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(settingsUrl).Result;
                ShellyDevice dev = Newtonsoft.Json.JsonConvert.DeserializeObject<Shelly25>(httpResponse);
                dynamic deviceInformation = (Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(httpResponse)).device;

                dev.GetType().GetProperties().ToList().ForEach(property =>
                {
                    if (this.GetType().GetProperty(property.Name) != null)
                    {
                        var val = dev.GetType().GetProperty(property.Name).GetValue(dev);
                        this.GetType().GetProperty(property.Name).SetValue(this, val);
                    }
                });

                this.Type = deviceInformation.type;
                this.Mac = deviceInformation.mac;
            }
            /*
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(settingsUrl).Result;

                dynamic deviceInformation = (Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(httpResponse)).device;

                ShellyDevice dev = new ShellyDevice();




                dev.GetType().GetProperties().ToList().ForEach(property =>
                {
                    if (this.GetType().GetProperty(property.Name) != null)
                    {
                        var val = dev.GetType().GetProperty(property.Name).GetValue(dev);
                        this.GetType().GetProperty(property.Name).SetValue(this, val);
                    }
                    else
                    {
                        this.GetType().
                    }
                });

                this.Type = deviceInformation.type;
                this.Mac = deviceInformation.mac; 

                OnDeviceLoaded(new EventArgs());
            }
            */
        }

    }


}
