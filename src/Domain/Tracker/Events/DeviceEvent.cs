using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class DeviceEvent
    {
        public DeviceId DeviceId { get; }
        public DateTimeOffset TimeStamp { get; }
    }
}
