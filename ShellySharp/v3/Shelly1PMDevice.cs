using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class Shelly1PMDevice : ShellyDeviceBase
    {
        public Shelly1PMDevice(string deviceIp) : base(deviceIp)
        {
            Switches = new List<IShellySwitch> { new ShellySwitch(this, 0) };
            Inputs = new List<IShellyInput> { new ShellyInput(this, 0) };
        }
    }
}
