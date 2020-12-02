using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using Core.Domain.Vehicles.Events;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Core.Domain.Vehicles
{
    public record VehicleId : EntityId
    {
        public VehicleId() : base() { }

        public VehicleId(Guid id) : base(id) { }
    }

    public class VehicleInfo
    {
        public string? Brand { get; }
        public string? Model { get; }
    }

    public class Vehicle : Entity, IAggregateRoot
    {
        public VehicleId Id { get; }

        public string LicensePlateId { get; private set; }

        public string? Name { get; private set; }

        public VehicleInfo? Info { get; }

        public VehicleType Type { get; private set; }

        public TenantId TenantId { get; private set; }

        private readonly List<TrackerId> trackers = new();
        public IReadOnlyCollection<TrackerId> Trackers => trackers;

        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset? TerminatedAt { get; private set; }

#pragma warning disable CS8618
        private Vehicle() { }
#pragma warning restore CS8618

        internal Vehicle(
            string licensePlateId, TenantId tenantId, 
            VehicleType? vehicleType = null, string? name = null)
        {
            Id = new();

            LicensePlateId = licensePlateId;
            Type = vehicleType ?? VehicleType.Default;
            Name = name;
            TenantId = tenantId;

            CreatedAt = DateTimeOffset.UtcNow;
        }

        public Seq<IDomainEvent> InstallTracker(Tracker tracker)
        {
            trackers.Add(tracker.Id);

            return new()
            {
                new TrackerInstalled(
                    Id, tracker.Id,
                    tracker.SerialNumber, 
                    tracker.Info?.Brand, tracker.Info?.Model)
            };
        }

        public Seq<IDomainEvent> RemoveTracker(TrackerId trackerId)
        {
            trackers.Remove(trackers.Single(t => t == trackerId));

            return new()
            {
                new TrackerRemoved(Id, trackerId)
            };
        }

        public Seq<IDomainEvent> ChangeLicensePlate(string newLicensePlateId)
        {
            var @event = new VehicleLicensePlateChanged(Id, this.LicensePlateId, newLicensePlateId);

            LicensePlateId = newLicensePlateId;

            return new() { @event };
        }

        public Seq<IDomainEvent> ChangeName(string newName)
        {
            var @event = new VehicleNameChanged(Id, this.Name, newName);

            Name = newName;

            return new() { @event };
        }

        public Seq<IDomainEvent> ChangeVehicleType(VehicleType newVehicleType)
        {
            var @event = new VehicleTypeChanged(Id, Type, newVehicleType);

            Type = newVehicleType;

            return new() { @event };
        }

        public Seq<IDomainEvent> Terminate()
        {
            if (TerminatedAt != null)
                return new SeqEmpty();

            TerminatedAt = DateTimeOffset.UtcNow;

            return new()
            {
                new VehicleTerminated(Id)
            };
        }
    }
}
