using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleLicenseChanged
    {
        public VehicleId VehicleId { get; }
        public string OldLicensePlateId { get; }
        public string NewLicensePlateId { get; }

        public VehicleLicenseChanged(
            VehicleId vehicleId,
            string oldLicensePlateId,
            string newLicensePlateId)
        {
            VehicleId = vehicleId;
            OldLicensePlateId = oldLicensePlateId;
            NewLicensePlateId = newLicensePlateId;
        }
    }
}