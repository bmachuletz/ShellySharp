using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public class DeviceSwitchedEventArgs : EventArgs
    {
        public ShellyDevice Device { get; set; }
        public bool ?IsOn { get; set; }
    }
}
