using Core.Domain.Vehicles;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class RemoveVehicleGroupToUserGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }
        public VehicleGroupId VehicleGroupId { get; }

        public RemoveVehicleGroupToUserGroup(UserGroupId userGroupId, VehicleGroupId vehicleGroupId)
        {
            UserGroupId = userGroupId;
            VehicleGroupId = vehicleGroupId;
        }
    }
}