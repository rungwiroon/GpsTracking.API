using Core.Domain.SeedWork;
using Domain.User;
using System;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleGroupChanged : IEvent
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
