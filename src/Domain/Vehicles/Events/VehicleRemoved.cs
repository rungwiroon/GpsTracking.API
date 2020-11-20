using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleRemoved : IDomainEvent
    {
        public VehicleId VehicleId { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleRemoved(VehicleId vehicleId)
        {
            VehicleId = vehicleId;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}
