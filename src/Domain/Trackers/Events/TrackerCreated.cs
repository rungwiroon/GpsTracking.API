using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Trackers.Events
{
    public class NewTrackerAdded : IDomainEvent
    {
        public TrackerId Id { get; }

        public string SerialNumber { get; }

        public DateTimeOffset AddedAt { get; }

        public string? Brand { get; }
        
        public string? Model { get; }

        public NewTrackerAdded(
            TrackerId id, string serialNumber, DateTimeOffset addedAt, string? brand, string? model)
        {
            Id = id;
            SerialNumber = serialNumber;
            AddedAt = addedAt;
            Brand = brand;
            Model = model;
        }
    }
}