using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3.Interface
{
    public interface IShellySwitch
    {
        int Id { get; }
        Task ToggleAsync();
        Task SwitchAsync(bool state);
        Task<JsonDocument> GetStatusAsync();
    }
}
