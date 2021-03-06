﻿using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleRemoved : IDomainEvent
    {
        public VehicleId VehicleId { get; }

        public VehicleRemoved(VehicleId vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}
