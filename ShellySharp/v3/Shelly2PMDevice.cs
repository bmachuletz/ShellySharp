using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class Shelly2PMDevice : ShellyDeviceBase
    {
        public Shelly2PMDevice(string deviceIp) : base(deviceIp)
        {
            Switches = new List<IShellySwitch>
            {
                new ShellySwitch(this, 0),
                new ShellySwitch(this, 1)
            };
            Inputs = new List<IShellyInput>
            {
                new ShellyInput(this, 0),
                new ShellyInput(this, 1)
            };
        }
    }
}
