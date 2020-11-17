using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using System;

namespace Core.Domain.Vehicle.Events
{
    [Serializable]
    public class TrackerRemoved : IEvent
    {
        public VehicleId VehicleId { get; }

        public TrackerId TrackerId { get; }

        public TrackerRemoved(VehicleId vehicleId, TrackerId trackerId)
        {
            VehicleId = vehicleId;
            TrackerId = trackerId;
        }
    }
}