using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    // Shelly Dimmer G3 Device (enthält einen Dimmer)
    public class ShellyDimmerG3Device : ShellyDeviceBase
    {
        public IShellyDimmer Dimmer { get; private set; }

        public ShellyDimmerG3Device(string deviceIp) : base(deviceIp)
        {
            // Hier wird angenommen, dass der Shelly Dimmer G3 nur einen Dimmer (z. B. "dimmer:0") besitzt.
            Dimmer = new ShellyDimmer(this, 0);
            // Optional: Falls das Gerät weitere Komponenten (z. B. Inputs) besitzt, können diese ebenfalls initialisiert werden.
            Switches = new List<IShellySwitch>(); // Falls keine Switches vorhanden sind.
            Inputs = new List<IShellyInput>();     // Falls keine Inputs vorhanden sind.
        }
    }
}
