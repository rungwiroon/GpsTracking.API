using Core.Domain.SeedWork;
using System;

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
