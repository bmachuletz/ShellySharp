using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Interfaces
{
    interface ILEDStatusDisable
    {
        public bool? LedStatusDisable { get; set; }

        public void SetLedStatusDisable(bool disabled);
    }
}
