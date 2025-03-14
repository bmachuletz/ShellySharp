using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class ShellySwitch : IShellySwitch
    {
        private readonly ShellyDeviceBase _device;
        public int Id { get; }

        public ShellySwitch(ShellyDeviceBase device, int id)
        {
            _device = device;
            Id = id;
        }

        public async Task ToggleAsync()
        {
            // Hier wird der state-Parameter ignoriert, da der Endpunkt
            // den Befehl "Toggle" ausführt und somit den Schalter umschaltet.
            var responseContent = await _device.ExecuteGetRequestAsync($"Switch.Toggle?id={Id}");
            Console.WriteLine($"Switch {Id} toggled: {responseContent}");
        }

        public async Task SwitchAsync(bool state)
        {
            var responseContent = await _device.ExecuteGetRequestAsync($"Switch.Set?id={Id}&on={state.ToString().ToLower()}");
            Console.WriteLine($"Switch {Id} switched: {responseContent}");
        }

        public async Task<JsonDocument> GetStatusAsync()
        {
            return await _device.SendRpcRequestAsync("Shelly.GetStatus");
        }


    }
}
