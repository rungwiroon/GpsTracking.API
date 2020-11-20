using Domain;
using System;

namespace Core.Domain.Vehicles.Commands
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