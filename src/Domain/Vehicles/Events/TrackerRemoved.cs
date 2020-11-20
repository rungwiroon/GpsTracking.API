using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class TrackerRemoved : IDomainEvent
    {
        public VehicleId VehicleId { get; }

        public TrackerId TrackerId { get; }

        public DateTimeOffset GlobalSequenceNumber { get; }

        public TrackerRemoved(VehicleId vehicleId, TrackerId trackerId)
        {
            VehicleId = vehicleId;
            TrackerId = trackerId;

            GlobalSequenceNumber = DateTimeOffset.UtcNow;
        }
    }
}