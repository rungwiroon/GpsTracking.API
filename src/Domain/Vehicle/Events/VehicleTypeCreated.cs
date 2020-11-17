﻿using Core.Domain.SeedWork;

namespace Core.Domain.Vehicle.Events
{
    public class VehicleTypeCreated : IEvent
    {
        public VehicleTypeId VehicleTypeId { get; }

        public string VehicleTypeName { get; }

        public VehicleTypeCreated(
            VehicleTypeId vehicleTypeId, string vehicleTypeName)
        {
            VehicleTypeId = vehicleTypeId;
            VehicleTypeName = vehicleTypeName;
        }
    }
}
