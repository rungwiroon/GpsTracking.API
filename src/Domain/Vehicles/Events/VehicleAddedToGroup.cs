using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleAddedToGroup : IDomainEvent
    {
        public TenantId TenantId { get; }

        public VehicleId VehicleId { get; }

        public VehicleGroupId VehicleGroupId { get; }

        public string VehicleGroupName { get; }

        public string VehicleLicensePlateId { get; }

        public string? VehicleName { get; }

        public VehicleAddedToGroup(
            TenantId tenantId,
            VehicleGroupId vehicleGroupId,
            string vehicleGroupName,

            VehicleId vehicleId, 
            string vehicleLicensePlateId, 
            string? vehicleName
            )
        {
            TenantId = tenantId;

            VehicleGroupId = vehicleGroupId;
            VehicleGroupName = vehicleGroupName;

            VehicleId = vehicleId;
            VehicleLicensePlateId = vehicleLicensePlateId;
            VehicleName = vehicleName;
        }
    }
}