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

        public UserGroupId UserGroupId { get; }

        public VehicleGroupCreated(
            VehicleGroupId vehicleGroupId, string vehicleGroupName, UserGroupId userGroupId)
        {
            VehicleGroupId = vehicleGroupId;
            VehicleGroupName = vehicleGroupName;
            UserGroupId = userGroupId;
        }
    }
}
