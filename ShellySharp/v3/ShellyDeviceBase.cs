using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public abstract class ShellyDeviceBase : IDisposable
    {
        protected HttpClient HttpClient;
        public string DeviceIp { get; }
        public string RpcUrl { get; }
        protected ShellyStatusListener StatusListener;

        // Gemeinsame Komponenten können als Collections gehalten werden.
        public IReadOnlyList<IShellySwitch> Switches { get; protected set; }
        public IReadOnlyList<IShellyInput> Inputs { get; protected set; }

        public ShellyDeviceBase(string deviceIp)
        {
            DeviceIp = deviceIp;
            RpcUrl = $"http://{deviceIp}/rpc";
            HttpClient = new HttpClient();
        }

        /// <summary>
        /// Sendet einen RPC-Request und liefert das JSON-Ergebnis.
        /// </summary>
        public async Task<JsonDocument> SendRpcRequestAsync(string method, object parameters = null)
        {
            var requestObj = new
            {
                id = 1,
                src = this.GetType().Name,
                method = method,
                @params = parameters
            };

            var json = JsonSerializer.Serialize(requestObj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync(RpcUrl, content);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(responseJson);
        }

        /// <summary>
        /// Initialisiert den WebSocket-Listener für Echtzeit-Statusupdates.
        /// </summary>
        public async Task InitializeStatusListenerAsync()
        {
            StatusListener = new ShellyStatusListener(DeviceIp);
            StatusListener.StatusUpdated += OnStatusUpdated;
            await StatusListener.StartListeningAsync();
        }

        public async Task<string> ExecuteGetRequestAsync(string relativeUrl)
        {
            // RpcUrl ist z.B. "http://192.168.33.1/rpc"
            string url = $"{RpcUrl}/{relativeUrl}";
            var response = await HttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Wird aufgerufen, wenn ein Statusupdate über den WebSocket empfangen wird.
        /// </summary>
        protected virtual void OnStatusUpdated(string message)
        {
            Console.WriteLine($"[{this.GetType().Name}] Status update received: {message}");
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            StatusListener?.Dispose();
        }
    }
}
