using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class ShellyStatusListener : IDisposable
    {
        private readonly ClientWebSocket _webSocket;
        private readonly Uri _uri;
        private CancellationTokenSource _cts;
        public event Action<string> StatusUpdated;

        public ShellyStatusListener(string deviceIp)
        {
            _uri = new Uri($"ws://{deviceIp}/rpc");
            _webSocket = new ClientWebSocket();
        }

        public async Task StartListeningAsync()
        {
            _cts = new CancellationTokenSource();
            await _webSocket.ConnectAsync(_uri, _cts.Token);
            _ = Task.Run(() => ReceiveMessagesAsync(_cts.Token));
        }

        private async Task ReceiveMessagesAsync(CancellationToken token)
        {
            var buffer = new byte[4096];
            while (!token.IsCancellationRequested && _webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", token);
                }
                else
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    StatusUpdated?.Invoke(message);
                }
            }
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _webSocket?.Dispose();
        }
    }
}
