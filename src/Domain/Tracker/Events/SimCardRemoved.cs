using Domain;
using Domain.Tracker.Modules;
using System;
using System.Collections.Generic;

namespace Core.Domain.Tracker.Events
{
    public record SimCardRemoved : IEvent
    {
        public string SimCardSerialNumber { get; }
        public string? SimCardPhoneNumber { get; }
        public DeviceModuleId CellularModuleId { get; }

        public SimCardRemoved(
            string simCardSerialNumber,
            DeviceModuleId cellularModuleId,
            string? simCardPhoneNumber = null)
        {
            SimCardSerialNumber = simCardSerialNumber;
            CellularModuleId = cellularModuleId;

            SimCardPhoneNumber = simCardPhoneNumber;
        }
    }
}
