using Core.Domain.SeedWork;
using Core.Domain.Identity;

namespace Core.Domain.Vehicles.Events
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
