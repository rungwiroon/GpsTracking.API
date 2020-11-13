using Domain;
using Domain.Vehicle;
using System;
using System.Collections.Generic;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleRemoved : IEvent
    {
        public VehicleId VehicleId { get; }

        public VehicleRemoved(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
