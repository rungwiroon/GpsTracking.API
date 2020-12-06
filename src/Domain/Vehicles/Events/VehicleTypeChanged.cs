using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleTypeChanged : IDomainEvent
    {
        public VehicleId VehicleId { get; }
        public VehicleTypeId OldTypeId { get; }

        public VehicleTypeId NewTypeId { get; }
        public string NewVehicleTypeName { get; }

        public DateTimeOffset CreatedAt { get; }

        public VehicleTypeChanged(
            VehicleId vehicleId,
            VehicleTypeId oldVehicleTypeId,
            VehicleTypeId newVehicleTypeId, 
            string newVehicleTypeName)
        {
            VehicleId = vehicleId;
            OldTypeId = oldVehicleTypeId;
            NewTypeId = newVehicleTypeId;
            NewVehicleTypeName = newVehicleTypeName;
            CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}