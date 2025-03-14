using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShellySharp.v3.Interface
{ 
    public interface IShellyDimmer
    {
        int Id { get; }
        /// <summary>
        /// Setzt die Helligkeit (z. B. 0-100).
        /// </summary>
        Task SetBrightnessAsync(int brightness);
        Task<JsonDocument> GetStatusAsync();
    }
}
