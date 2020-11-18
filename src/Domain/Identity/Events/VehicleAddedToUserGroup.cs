using Core.Domain.SeedWork;
using Core.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class VehicleAddedToUserGroup : IEvent
    {
        public UserGroupId UserGroupId { get; }

        public VehicleId VehicleId { get; }

        public string LicensePlateId { get; }

        public string? Name { get; }

        public VehicleAddedToUserGroup(UserGroupId userGroupId, VehicleId vehicleId, string licensePlateId, string? name)
        {
            UserGroupId = userGroupId;
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
            Name = name;
        }
    }
}
