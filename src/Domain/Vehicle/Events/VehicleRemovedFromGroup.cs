using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleRemovedFromGroup : IEvent
    {
        public VehicleGroupId VehicleGroupId { get; }

        public VehicleId VehicleId { get; }

        public VehicleRemovedFromGroup(
            VehicleGroupId vehicleGroupId, VehicleId vehicleId)
        {
            VehicleId = vehicleId;
            VehicleGroupId = vehicleGroupId;
        }
    }
}