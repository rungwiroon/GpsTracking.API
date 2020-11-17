using Core.Domain.Trackers;
using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class RemoveTracker : ICommand
    {
        public VehicleId VehicleId { get; }

        public TrackerId TrackerId { get; }

        public DateTimeOffset RemoveddAt { get; }

        public string? RemovedBy { get; }

        public RemoveTracker(
            VehicleId vehicleId, TrackerId trackerId, 
            DateTimeOffset removeddAt, string? removedBy)
        {
            VehicleId = vehicleId;
            TrackerId = trackerId;
            RemoveddAt = removeddAt;
            RemovedBy = removedBy;
        }
    }
}