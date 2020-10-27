using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Interfaces
{
    interface IFactoryResetFromSwitch
    {
        public bool? FactoryResetFromSwitch { get; set; }
        public void SetFactoryResetFromSwitchEnabled(bool _enable);
    }
}
