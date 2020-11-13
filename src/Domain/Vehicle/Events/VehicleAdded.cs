using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleCreated
    {
        public VehicleId VehicleId { get; }
        public string LicensePlateId { get; }
        public string? Name { get; }
        public VehicleTypeId VehicleTypeId { get; }

        public VehicleCreated(
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