using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShellySharp.Settings
{
    interface ILights
    {
        void UpdateLights(object state);

        public List<Light> Lights { get; set; }
    }
}
