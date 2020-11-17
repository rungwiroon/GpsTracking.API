using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class RemoveVehicle : ICommand
    {
        public VehicleId VehicleId { get; }

        public RemoveVehicle(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}