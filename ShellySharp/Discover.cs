using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace ShellySharp
{
    public static class Discover
    {
        public static DeviceClass GetDeviceInformation(string url)
        {
            DeviceClass devClass = new DeviceClass();
            string shellyInformationUrl = string.Format("{0}/{1}", url, "shelly"); 

            using(HttpClient httpClient = new HttpClient())
            {
                devClass = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceClass>(httpClient.GetStringAsync(shellyInformationUrl).Result);
            }

            return devClass;
        }
    }
}
