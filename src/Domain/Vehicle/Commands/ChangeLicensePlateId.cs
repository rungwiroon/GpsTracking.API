using Domain;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class ChangeLicensePlateId : ICommand
    {
        public VehicleId VehicleId { get; }
        public string LicensePlateId { get; }

        public ChangeLicensePlateId(
            VehicleId vehicleId, string licensePlateId)
        {
            VehicleId = vehicleId;
            LicensePlateId = licensePlateId;
        }
    }
}