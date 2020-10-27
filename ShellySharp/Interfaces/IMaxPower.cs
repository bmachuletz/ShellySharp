using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Interfaces
{
    interface IMaxPower
    {
        public long? MaxPower { get; set; }

        public void SetMaxPower(long powerInWatts);
    }
}
