using Core.Application.Vehicles.Views;
using Core.Domain.Identity;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Vehicles.Queries
{
    public class VehicleInVehicleGroupQuery : IQuery<VehicleGroupVehiclesView>
    {
        public UserGroupId UserGroupId { get; }

        public VehicleInVehicleGroupQuery(UserGroupId userGroupId)
        {
            UserGroupId = userGroupId;
        }
    }

    public class VehicleInVehicleGroupQueryHandler :
        IQueryHandler<VehicleInVehicleGroupQuery, VehicleGroupVehiclesView>
    {
        public VehicleGroupVehiclesView Handle(VehicleInVehicleGroupQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
