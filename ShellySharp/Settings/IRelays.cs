using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShellySharp.Settings
{
    interface IRelays
    {
        void UpdateRelays(object state);

        public List<Relay> Relays { get; set; }
    }
}
