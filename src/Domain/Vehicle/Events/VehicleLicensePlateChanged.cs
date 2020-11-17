using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class VehicleLicensePlateChanged : IEvent
    {
        public VehicleId VehicleId { get; }
        public string OldLicensePlateId { get; }
        public string NewLicensePlateId { get; }

        public VehicleLicensePlateChanged(
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