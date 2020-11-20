using Core.Application.Vehicles.Views;
using Core.Domain.Identity;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Vehicles.Views
{
    public class GetVehicleInUserGroup : IQuery<UserGroupVehiclesView>
    {
        public UserGroupId UserGroupId { get; }

        public GetVehicleInUserGroup(UserGroupId userGroupId)
        {
            UserGroupId = userGroupId;
        }
    }

    public class VehicleInUserGroupQueryHandler :
        IQueryHandler<GetVehicleInUserGroup, UserGroupVehiclesView>
    {
        public UserGroupVehiclesView Handle(GetVehicleInUserGroup query)
        {
            throw new NotImplementedException();
        }
    }
}
