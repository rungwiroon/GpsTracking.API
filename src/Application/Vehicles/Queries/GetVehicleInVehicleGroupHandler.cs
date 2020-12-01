using Core.Domain.Vehicles.Queries;
using Core.Domain.Vehicles.Views;
using GpsTracking.Application;
using System;

namespace Core.Application.Vehicles.Queries
{
    public class VehicleInVehicleGroupQueryHandler :
        IQueryHandler<VehicleInVehicleGroupQuery, VehicleGroupVehiclesView>
    {
        public VehicleGroupVehiclesView Handle(VehicleInVehicleGroupQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
