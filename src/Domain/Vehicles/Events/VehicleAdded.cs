using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleAdded : IDomainEvent
    {
        public TenantId TenantId { get; }
        public VehicleId VehicleId { get; }
        public string LicensePlateId { get; }
        public string? Name { get; }
        public VehicleTypeId VehicleTypeId { get; }
        public DateTimeOffset CreatedAt { get; }

        public VehicleAdded(
            VehicleId vehicleId,
            string licensePlateId,
            VehicleTypeId vehicleTypeId,
            TenantId tenantId,
            string? name = null)
        {
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
            Name = name;
            VehicleTypeId = vehicleTypeId;
            CreatedAt = DateTimeOffset.UtcNow;
            TenantId = tenantId;
        }
    }
}