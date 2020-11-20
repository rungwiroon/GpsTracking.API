using Core.Domain.SeedWork;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleGroupChanged : IDomainEvent
    {
        public VehicleId VehicleId { get; }

        public UserGroupId OldGroup { get; }

        public UserGroupId NewGroup { get; }

        public VehicleGroupChanged(
            VehicleId vehicleId,
            UserGroupId oldGroup,
            UserGroupId newGroup)
        {
            VehicleId = vehicleId;
            OldGroup = oldGroup;
            NewGroup = newGroup;
        }
    }
}
