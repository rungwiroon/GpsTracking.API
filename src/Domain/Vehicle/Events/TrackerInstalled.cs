using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using System;

namespace Core.Domain.Vehicles.Events
{
    [Serializable]
    public class TrackerInstalled : IEvent
    {
        public VehicleId VehicleId { get; }

        public TrackerId TrackerId { get; }

        public string TrackerSerialNumber { get; }

        public string? TrackerBrand { get; }

        public string? TrackerModel { get; }

        public TrackerInstalled(
            VehicleId vehicleId, 
            TrackerId trackerId, 
            string trackerSerialNumber, 
            string? trackerBrand, 
            string? trackerModel)
        {
            VehicleId = vehicleId;
            TrackerId = trackerId;
            TrackerSerialNumber = trackerSerialNumber;
            TrackerBrand = trackerBrand;
            TrackerModel = trackerModel;
        }
    }
}