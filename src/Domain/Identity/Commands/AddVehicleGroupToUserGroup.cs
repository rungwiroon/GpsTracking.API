using Core.Domain.Vehicles;
using Domain;

namespace Core.Domain.Identity.Commands
{
    public class AddVehicleGroupToUserGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }
        public VehicleGroupId VehicleGroupId { get; }

        public AddVehicleGroupToUserGroup(UserGroupId userGroupId, VehicleGroupId vehicleGroupId)
        {
            UserGroupId = userGroupId;
            VehicleGroupId = vehicleGroupId;
        }
    }
}