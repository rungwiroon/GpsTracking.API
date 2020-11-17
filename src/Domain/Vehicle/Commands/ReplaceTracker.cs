using Core.Domain.Trackers;
using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class ReplaceTracker : ICommand
    {
        public VehicleId VehicleId { get; }

        public TrackerId OldTrackerId { get; }

        public TrackerId NewTrackerId { get; }

        public DateTimeOffset ReplacedAt { get; }

        public string? ReplacedBy { get; }

        public ReplaceTracker(
            VehicleId vehicleId, TrackerId oldTrackerId, TrackerId newTrackerId, 
            DateTimeOffset replacedAt, string? replacedBy)
        {
            VehicleId = vehicleId;
            OldTrackerId = oldTrackerId;
            NewTrackerId = newTrackerId;
            ReplacedAt = replacedAt;
            ReplacedBy = replacedBy;
        }
    }
}