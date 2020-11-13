using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tracker.Modules
{
    public class CellularModule : DeviceModule
    {
        public string Imei { get; }
    }
}