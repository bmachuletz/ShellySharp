using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class ShellyDimmer : IShellyDimmer
    {
        private readonly ShellyDeviceBase _device;
        public int Id { get; }

        public ShellyDimmer(ShellyDeviceBase device, int id)
        {
            _device = device;
            Id = id;
        }

        /// <summary>
        /// Setzt die Helligkeit des Dimmers.
        /// </summary>
        public async Task SetBrightnessAsync(int brightness)
        {
            // Annahme: Der RPC-Methodenname ist "Light.SetState" und erwartet Parameter "id" und "brightness".
            var parameters = new { id = Id, brightness = brightness };
            var response = await _device.SendRpcRequestAsync("Light.SetState", parameters);
            Console.WriteLine($"Dimmer {Id} brightness set to {brightness}: {response.RootElement}");
        }

        public async Task<JsonDocument> GetStatusAsync()
        {
            return await _device.SendRpcRequestAsync("Shelly.GetStatus");
        }
    }
}
