using Core.Domain.Vehicles.Commands;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Vehicles
{
    public class VehicleGroupCommandHandler :
        ICommandHandler<CreateVehicleGroup>
    {
        public void Handle(CreateVehicleGroup command)
        {
            throw new NotImplementedException();
        }
    }
}
