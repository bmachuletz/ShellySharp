using ShellySharp.v3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellySharp.v3
{
    public class ShellyInput : IShellyInput
    {
        private readonly ShellyDeviceBase _device;
        public int Id { get; }

        public ShellyInput(ShellyDeviceBase device, int id)
        {
            _device = device;
            Id = id;
        }
    }
}
