using Core.Domain.Identity;
using Core.Domain.Vehicles.Views;
using System;

namespace Core.Domain.Vehicles.Queries
{
    public class VehicleInVehicleGroupQuery : IQuery<VehicleGroupVehiclesView>
    {
        public UserGroupId UserGroupId { get; }

        public VehicleInVehicleGroupQuery(UserGroupId userGroupId)
        {
            UserGroupId = userGroupId;
        }
    }
}
