﻿using Core.Domain.SeedWork;
using Core.Domain.Trackers.DeviceOpions;
using Core.Domain.Trackers.Modules;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using Core.Domain.Trackers.Events;
using System.Linq;
using LanguageExt;
using Core.Domain.TrackerLogs;

namespace Core.Domain.Trackers
{
    public sealed record TrackerId : EntityId
    {
        public TrackerId() : base() { }

        public TrackerId(Guid id) : base(id) { }
    }

    [Serializable]
    public class Tracker : Entity, IAggregateRoot
    {
        public TrackerId Id { get; }

        public TrackerInfo? Info { get; }

        public TenantId OwnerId { get; }

        public string SerialNumber { get; }

        private readonly List<DeviceModule> modules = new();
        public IReadOnlyCollection<DeviceModule> Modules => modules.AsReadOnly();

        private readonly List<DeviceOption> options = new();
        public IReadOnlyCollection<DeviceOption> Options => options.AsReadOnly();

        public DateTimeOffset CreatedAt { get; }

        public bool IsActive { get; private set; }

        public DateTimeOffset? TerminatedAt { get; private set; }

#pragma warning disable CS8618
        private Tracker() { }
#pragma warning restore CS8618

        internal Tracker(TenantId owner, string serialNumber, TrackerInfo? info = null)
        {
            Id = new TrackerId();
            OwnerId = owner;
            SerialNumber = serialNumber;
            Info = info;
            CreatedAt = DateTimeOffset.UtcNow;
            IsActive = true;
        }

        public Seq<IDomainEvent> AttachModule(DeviceModule module)
        {
            modules.Add(module);

            return new() { new ModuleAttachedToTracker() };
        }

        public Seq<IDomainEvent> RemoveModule(DeviceModuleId moduleId)
        {
            modules.Remove(modules.Single(m => m.Id == moduleId));

            return new() { new ModuleRemovedFromTracker() };
        }

        public void AttachSensor(Sensor sensor, SensorOption option)
        {
            throw new NotImplementedException();
        }

        public void RemoveSensor(Sensor sensor, DateTimeOffset effectiveDate)
        {
            throw new NotImplementedException();
        }

        public Seq<IDomainEvent> Terminate()
        {
            if(!IsActive)
                return new SeqEmpty();
            
            IsActive = false;
            TerminatedAt = DateTimeOffset.UtcNow;

            return new() { new TrackerTerminated() };
        }

        public (TrackerLog, Seq<IDomainEvent>) CreateLog()
        {
            throw new NotImplementedException();
        }
    }
}
