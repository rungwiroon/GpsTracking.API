using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Core.Domain.Tracker.Modules
{
    public abstract class SimCard
    {
        public string SerialNumber { get; protected set; }
    }

    public class PhoneSimCard : SimCard
    {
        public string PhoneNumber { get; }
    }

    public class IotSimCard : SimCard
    {
    }
}
