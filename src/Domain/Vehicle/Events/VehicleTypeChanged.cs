using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleTypeChanged : IEvent
    {
        public VehicleId VehicleId { get; }
        public VehicleType OldType { get; }
        public VehicleType NewType { get; }

        public VehicleTypeChanged(
            VehicleId vehicleId,
            VehicleType oldType,
            VehicleType newType)
        {
            VehicleId = vehicleId;
            OldType = oldType;
            NewType = newType;
        }
    }
}