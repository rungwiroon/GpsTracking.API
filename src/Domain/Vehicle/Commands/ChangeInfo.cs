using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class ChangeInfo : ICommand
    {
        public VehicleId VehicleId { get; }

        public string Brand { get; }

        public string Model { get; }

        public string Name { get;  }

        public ChangeInfo(
            VehicleId vehicleId,
            string brand, string model, string name)
        {
            VehicleId = vehicleId;
            Brand = brand;
            Model = model;
            Name = name;
        }
    }
}
