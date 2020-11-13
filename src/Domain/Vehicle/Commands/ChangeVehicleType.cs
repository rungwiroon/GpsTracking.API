using System;
using System.Collections.Generic;
using Domain.Tracker;
using Domain.User;
using Domain;

namespace Domain.Vehicle.Commands
{
    [Serializable]
    public class ChangeVehicleType : ICommand
    {
        public VehicleId VehicleId { get; }
        public VehicleTypeId VehicleTypeId { get; }
    }
}