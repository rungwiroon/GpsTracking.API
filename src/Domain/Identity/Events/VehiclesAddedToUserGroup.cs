using Core.Domain.SeedWork;
using Core.Domain.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Identity.Events
{
    public class VehiclesAddedToUserGroup : IDomainEvent
    {
        public UserGroupId UserGroupId { get; }

        public string UserGroupName { get; }

        public IEnumerable<Vehicle> Vehicles { get; }

        public record Vehicle
        {
            public VehicleId VehicleId { get; }

            public string LicensePlateId { get; }

            public string? Name { get; }

            public Vehicle(VehicleId vehicleId, string licensePlateId, string? name)
            {
                VehicleId = vehicleId;
                LicensePlateId = licensePlateId;
                Name = name;
            }
        }

        public VehiclesAddedToUserGroup(
            UserGroupId userGroupId, string userGroupName,
            IEnumerable<Vehicle> vehicles)
        {
            UserGroupId = userGroupId;
            UserGroupName = userGroupName;
            Vehicles = vehicles.ToArray();
        }
    }
}
