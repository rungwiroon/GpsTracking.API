using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain.SeedWork;
using Core.Domain.Vehicles;

namespace Core.Domain.Identity.Events
{
    public class VehicleGroupAddedToUserGroup : IDomainEvent
    {
        public TenantId TenantId { get; }

        public VehicleGroupId VehicleGroupId { get; }

        public string VehicleGroupName { get; }

        public UserGroupId UserGroupId { get; }

        public string UserGroupName { get; }

        public VehicleGroupAddedToUserGroup(
            TenantId tenantId,
            VehicleGroupId vehicleGroupId,
            string vehicleGroupName,
            UserGroupId userGroupId,
            string userGroupName)
        {
            TenantId = tenantId;
            VehicleGroupId = vehicleGroupId;
            VehicleGroupName = vehicleGroupName;
            UserGroupId = userGroupId;
            UserGroupName = userGroupName;
        }
    }
}
