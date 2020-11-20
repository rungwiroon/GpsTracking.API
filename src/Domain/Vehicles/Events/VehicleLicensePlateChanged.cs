using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleLicensePlateChanged : IDomainEvent
    {
        public VehicleId VehicleId { get; }
        public string OldLicensePlateId { get; }
        public string NewLicensePlateId { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public VehicleLicensePlateChanged(
            VehicleId vehicleId,
            string oldLicensePlateId,
            string newLicensePlateId)
        {
            VehicleId = vehicleId;
            OldLicensePlateId = oldLicensePlateId;
            NewLicensePlateId = newLicensePlateId;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}