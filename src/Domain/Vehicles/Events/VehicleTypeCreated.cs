using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    public class VehicleTypeCreated : IDomainEvent
    {
        public VehicleTypeId VehicleTypeId { get; }

        public string VehicleTypeName { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleTypeCreated(
            VehicleTypeId vehicleTypeId, string vehicleTypeName)
        {
            VehicleTypeId = vehicleTypeId;
            VehicleTypeName = vehicleTypeName;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}
