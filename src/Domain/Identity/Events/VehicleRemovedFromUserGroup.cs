using Core.Domain.SeedWork;
using Core.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class VehicleRemovedFromUserGroup : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public VehicleId VehicleId { get; }

        public VehicleRemovedFromUserGroup(UserGroupId userGroupId, VehicleId vehicleId)
        {
            UserGroupId = userGroupId;
            VehicleId = vehicleId;
        }
    }
}
