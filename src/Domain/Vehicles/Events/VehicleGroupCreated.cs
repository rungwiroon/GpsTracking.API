using Core.Domain.SeedWork;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Events
{
    public class VehicleGroupCreated : IDomainEvent
    {
        public TenantId TenantId { get; }

        public VehicleGroupId VehicleGroupId { get; }

        public string VehicleGroupName { get; }

        public VehicleGroupCreated(
            TenantId tenantId, VehicleGroupId vehicleGroupId, string vehicleGroupName)
        {
            TenantId = tenantId;
            VehicleGroupId = vehicleGroupId;
            VehicleGroupName = vehicleGroupName;
        }
    }
}
