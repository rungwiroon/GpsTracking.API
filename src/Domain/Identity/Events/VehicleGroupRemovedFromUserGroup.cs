using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain.SeedWork;
using Core.Domain.Vehicles;

namespace Core.Domain.Identity.Events
{
    public class VehicleGroupRemovedFromUserGroup : IDomainEvent
    {
        public VehicleGroupId VehicleGroupId { get; }

        public UserGroupId UserGroupId { get; }

        public VehicleGroupRemovedFromUserGroup(
            VehicleGroupId vehicleGroupId, UserGroupId userGroupId)
        {
            VehicleGroupId = vehicleGroupId;
            UserGroupId = userGroupId;
        }
    }
}
