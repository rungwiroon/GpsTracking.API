using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleAdded : IEvent
    {
        public VehicleId VehicleId { get; }
        public string LicensePlateId { get; }
        public string? Name { get; }
        public VehicleTypeId VehicleTypeId { get; }

        public VehicleAdded(
            VehicleId vehicleId,
            string licensePlateId,
            string name,
            VehicleTypeId vehicleTypeId)
        {
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
            Name = name;
            VehicleTypeId = vehicleTypeId;
        }
    }
}