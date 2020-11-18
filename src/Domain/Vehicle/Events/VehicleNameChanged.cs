using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class VehicleNameChanged : IEvent
    {
        public VehicleId VehicleId { get; }
        public string? OldName { get; }
        public string? NewName { get; }

        public VehicleNameChanged(
            VehicleId vehicleId,
            string? oldName,
            string? newName)
        {
            VehicleId = vehicleId;
            OldName = oldName;
            NewName = newName;
        }
    }
}