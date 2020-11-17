using Core.Domain.SeedWork;
using Domain.User;

namespace Core.Domain.Vehicle.Events
{
    public class VehicleGroupCreated : IEvent
    {
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
