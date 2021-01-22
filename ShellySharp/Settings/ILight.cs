using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Settings
{
    interface ILight
    {
        [JsonIgnore]
        public Int32 Id { get; set; }

        void SwitchOn();
        void SwitchOff();
        void SetBrightness();
    }
}
