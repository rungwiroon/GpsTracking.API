using Core.Domain.Vehicles.Queries;
using Core.Domain.Vehicles.Views;
using GpsTracking.Application;
using System;

namespace Core.Application.Vehicles.Views
{
    public class VehicleInUserGroupQueryHandler :
        IQueryHandler<GetVehicleInUserGroup, UserGroupVehiclesView>
    {
        public UserGroupVehiclesView Handle(GetVehicleInUserGroup query)
        {
            throw new NotImplementedException();
        }
    }
}
