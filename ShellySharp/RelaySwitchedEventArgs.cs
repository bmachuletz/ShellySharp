using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp
{
    public class RelaySwitchedEventArgs : EventArgs
    {
        public ShellyDevice Device { get; set; }
        public bool ?IsOn { get; set; }
    }
}
