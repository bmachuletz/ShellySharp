using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public static class ShellyDeviceFactory
    {
        public static async Task<ShellyDeviceBase> CreateDeviceAsync(string deviceIp)
        {
            // Beispielhafter RPC-Aufruf, um Geräteinformationen abzurufen.
            // Hier wird angenommen, dass im Rückgabe-JSON im Feld "device" -> "type" der Gerätetyp enthalten ist.
            using var client = new HttpClient();
            string rpcUrl = $"http://{deviceIp}/rpc";
            var requestObj = new
            {
                id = 1,
                src = "ShellyDeviceFactory",
                method = "Shelly.GetDeviceInfo"
            };
            var json = JsonSerializer.Serialize(requestObj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(rpcUrl, content);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseJson);

            // Annahme: Der Gerätetyp ist im Pfad "device" -> "type" enthalten.
            string deviceType = doc.RootElement
                                   .GetProperty("result")
                                   .GetProperty("app")
                                   .GetString();

            if (deviceType != null)
            {
                if (deviceType.IndexOf("Plus1PM", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return new Shelly1PMDevice(deviceIp);
                }
                else if (deviceType.IndexOf("Shelly 2 PM", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return new Shelly2PMDevice(deviceIp);
                }
                else if (deviceType.IndexOf("Shelly Dimmer G3", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return new ShellyDimmerG3Device(deviceIp);
                }
            }
            throw new NotSupportedException($"Gerätetyp '{deviceType}' wird nicht unterstützt.");
        }
    }
}
