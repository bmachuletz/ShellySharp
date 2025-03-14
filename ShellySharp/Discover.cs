using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ShellySharp
{
    public static class Discover
    {
        public static DeviceClass GetDeviceInformation(string url)
        {
            DeviceClass devClass = new DeviceClass();
            string shellyInformationUrl = string.Format("{0}/{1}", url, "shelly");

            using (HttpClient httpClient = new HttpClient())
            {
                devClass = Newtonsoft.Json.JsonConvert.DeserializeObject<DeviceClass>(httpClient.GetStringAsync(shellyInformationUrl).Result);
                if(devClass.Type == null)
                {
                    devClass.Type = devClass.Model;
                }
            }

            return devClass;
        }

        public static string GetDeviceInformationJson(string url)
        {
            string shellyInformationUrl = string.Format("{0}", url);
            string retval = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                retval = httpClient.GetStringAsync(shellyInformationUrl).Result;
            }

            return retval;
        }
    }
}
