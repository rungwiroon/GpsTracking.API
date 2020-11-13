using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleTypeChanged : IEvent
    {
        public VehicleId VehicleId { get; }
        public VehicleTypeId OldTypeId { get; }
        public VehicleTypeId NewTypeId { get; }

        public VehicleTypeChanged(
            VehicleId vehicleId,
            VehicleTypeId oldTypeId,
            VehicleTypeId newTypeId)
        {
            VehicleId = vehicleId;
            OldTypeId = oldTypeId;
            NewTypeId = newTypeId;
        }
    }
}