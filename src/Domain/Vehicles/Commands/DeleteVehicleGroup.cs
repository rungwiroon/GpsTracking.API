using Domain;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class DeleteVehicleGroup : ICommand
    {
        public VehicleGroupId VehicleGroupId { get; }

        public DeleteVehicleGroup(
            VehicleGroupId vehicleGroupId)
        {
            VehicleGroupId = vehicleGroupId;
        }
    }
}