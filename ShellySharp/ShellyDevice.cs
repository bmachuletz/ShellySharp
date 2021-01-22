using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ShellySharp.Resources;
using ShellySharp.Settings;

namespace ShellySharp
{
    public abstract partial class ShellyDevice
    {
        public event EventHandler DeviceLoaded;

        [JsonIgnore]   
        public string deviceUrl;

        [JsonIgnore]
        public string settingsUrl, deviceInformationUrl, otaStatusUrl;

        System.Threading.Timer gcTimer;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("mac", NullValueHandling = NullValueHandling.Ignore)]
        public string Mac { get; set; }

        [JsonProperty("wifi_sta", NullValueHandling = NullValueHandling.Ignore)]
        public WifiSta wifista { get; set; }

        [JsonProperty("cloud", NullValueHandling = NullValueHandling.Ignore)]
        public WifiAp wifiap { get; set; }

        [JsonProperty("ota", NullValueHandling = NullValueHandling.Ignore)]
        public Update ota { get; set; }

        //      [JsonProperty("rollers", NullValueHandling = NullValueHandling.Ignore)]


        protected virtual void OnDeviceLoaded(EventArgs e)
        {
            DeviceLoaded?.Invoke(this, e);
        }

        public ShellyDevice() { }

        public ShellyDevice(string url)
        {
            // we need to garbage collect periodically
            // seems that the static methods from newtonsoft json are filling up the memory
       //     gcTimer = new System.Threading.Timer(gcCallback, null, 5000, 10000);


            deviceUrl = url;

            otaStatusUrl= string.Format("{0}/ota", deviceUrl);
            settingsUrl = string.Format("{0}/settings", deviceUrl);
            deviceInformationUrl = string.Format("{0}/shelly", deviceUrl);

            InitialUpdateSettings();
        }

        private void gcCallback(object state)
        {
            Console.WriteLine("Garbage Collecting");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        void UpdateStatus()
        {
            string statusUrl = string.Format("{0}/settings", deviceUrl);

            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(statusUrl).Result;
                StatusResponse statusResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusResponse>(httpResponse);
            }
        }


        // Update from specific url and beta url will be supported someday
        void UpdateFirmware()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(string.Format("{0}/update=true", otaStatusUrl)).Result;

                this.ota = Newtonsoft.Json.JsonConvert.DeserializeObject<Update>(httpResponse);
            }
        }


        private void InitialUpdateSettings()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var httpResponse = httpClient.GetStringAsync(settingsUrl).Result;


                string deviceTypeString = (string)Newtonsoft.Json.Linq.JObject.Parse(httpResponse).SelectToken("$.device.type");

                ShellyDevice shellyDevice;

                
                switch(deviceTypeString)
                {
                    case "SHSW-25":
                        shellyDevice = new Shelly25();
                        shellyDevice = Newtonsoft.Json.JsonConvert.DeserializeObject<Shelly25>(httpResponse);
                        break;
                    case "SHDM-2":
                        shellyDevice = new ShellyDimmer2();
                        shellyDevice = Newtonsoft.Json.JsonConvert.DeserializeObject<ShellyDimmer2>(httpResponse);
                        break;
                    default:
                        shellyDevice = null;
                        break;
                        
                }
                
                // remove the dynamic
                dynamic deviceInformation = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(httpResponse).device;

                shellyDevice.GetType().GetProperties().ToList().ForEach(property =>
                {
                    if (this.GetType().GetProperty(property.Name) != null)
                    {
                        var val = shellyDevice.GetType().GetProperty(property.Name).GetValue(shellyDevice);
                        this.GetType().GetProperty(property.Name).SetValue(this, val);
                    }
                });

                this.Type = deviceInformation.type;
                this.Mac = deviceInformation.mac;

                httpResponse = httpClient.GetStringAsync(otaStatusUrl).Result;
                this.ota = Newtonsoft.Json.JsonConvert.DeserializeObject<Update>(httpResponse);

            }
        }
    }
}
