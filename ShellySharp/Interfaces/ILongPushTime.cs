using System;
using System.Collections.Generic;
using System.Text;

namespace ShellySharp.Interfaces
{
    interface ILongPushTime
    { 
        public long? LongpushTime { get; set; }

        public void SetLongPushTime(long pushtime);
    }
}
