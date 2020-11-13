using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using Domain.Tracker.Modules;
using Domain.User;

namespace Domain.Tracker
{
    public sealed record TrackerId : EntityId
    {
        public TrackerId() : base() { }

        public TrackerId(Guid id) : base(id) { }
    }

    [Serializable]
    public class Tracker
    {
        public TrackerId Id { get; }

        public TrackerInfo? Info { get; }

        public AccountId OwnerId { get; }

        public string SerialNumber { get; }

        private readonly List<DeviceModule> modules = new();
        public IReadOnlyCollection<DeviceModule> Modules => modules.AsReadOnly();

        private readonly List<DeviceOption> options = new();
        public IReadOnlyCollection<DeviceOption> Options => options.AsReadOnly();

        public DateTimeOffset CreatedAt { get; }

#pragma warning disable CS8618
        private Tracker() { }
#pragma warning restore CS8618

        public Tracker(AccountId owner, string serialNumber, TrackerInfo? info = null)
        {
            Id = new TrackerId();
            OwnerId = owner;
            SerialNumber = serialNumber;
            Info = info;
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void AttachModule(DeviceModule module)
        {
            throw new NotImplementedException();
        }

        public void RemoveModule(DeviceModuleId moduleId)
        {
            throw new NotImplementedException();
        }

        public void AttachSensor(Sensor sensor, SensorOption option)
        {
            throw new NotImplementedException();
        }

        public void RemoveSensor(Sensor sensor, DateTimeOffset effectiveDate)
        {
            throw new NotImplementedException();
        }
    }
}
