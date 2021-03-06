using Domain;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class ChangeVehicleType : ICommand
    {
        public VehicleId VehicleId { get; }
        public VehicleTypeId VehicleTypeId { get; }

        public ChangeVehicleType(
            VehicleId vehicleId, VehicleTypeId vehicleTypeId)
        {
            VehicleId = vehicleId;
            VehicleTypeId = vehicleTypeId;
        }
    }
}