using ShellySharp.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Interfaces
{
    interface ISwitchMode
    {
        public string Mode { get; set; }

        public void SetMode(DeviceMode mode);
    }
}
