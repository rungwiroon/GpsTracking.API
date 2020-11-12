using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DeviceEvent
    {
        public DeviceId DeviceId { get; }
        public DateTimeOffset TimeStamp { get; }
    }
}
