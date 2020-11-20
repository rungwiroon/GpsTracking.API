using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleAdded : IDomainEvent
    {
        public VehicleId VehicleId { get; }
        public string LicensePlateId { get; }
        public string? Name { get; }
        public VehicleTypeId VehicleTypeId { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleAdded(
            VehicleId vehicleId,
            string licensePlateId,
            string name,
            VehicleTypeId vehicleTypeId)
        {
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
            Name = name;
            VehicleTypeId = vehicleTypeId;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}