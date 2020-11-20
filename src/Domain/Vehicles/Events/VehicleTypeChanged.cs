using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleTypeChanged : IDomainEvent
    {
        public VehicleId VehicleId { get; }
        public VehicleType OldType { get; }
        public VehicleType NewType { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleTypeChanged(
            VehicleId vehicleId,
            VehicleType oldType,
            VehicleType newType)
        {
            VehicleId = vehicleId;
            OldType = oldType;
            NewType = newType;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}