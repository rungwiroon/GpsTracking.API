using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleAddedToGroup : IEvent
    {
        public VehicleId VehicleId { get; }

        public VehicleGroupId VehicleGroupId { get; }

        public string VehicleLicensePlateId { get; }

        public string VehicleName { get; }

        public string? VehicleGroupName { get; }

        public VehicleAddedToGroup(
            VehicleGroupId vehicleGroupId,
            string vehicleGroupName,

            VehicleId vehicleId, 
            string vehicleLicensePlateId, 
            string? vehicleName
            )
        {
            VehicleGroupId = vehicleGroupId;
            VehicleGroupName = vehicleGroupName;

            VehicleId = vehicleId;
            VehicleLicensePlateId = vehicleLicensePlateId;
            VehicleName = vehicleName;
        }
    }
}