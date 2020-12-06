using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using Core.Domain.Vehicles.Events;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

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
        public VehicleId Id { get; private set; }

        public string LicensePlateId { get; private set; }

        public string? Name { get; private set; }

        public VehicleInfo? Info { get; }

        public VehicleTypeId Type { get; private set; }

        public TenantId TenantId { get; private set; }

        private readonly List<TrackerId> trackers = new();
        public IReadOnlyCollection<TrackerId> Trackers => trackers;

        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset? TerminatedAt { get; private set; }

#pragma warning disable CS8618
        private Vehicle() { }
#pragma warning restore CS8618

        internal static (Vehicle, Seq<IDomainEvent>) CreateVehicle(
            string licensePlateId, TenantId tenantId, 
            VehicleType? vehicleType = null, string? name = null)
        {
            var @event = new VehicleAdded(
                    new VehicleId(),
                    licensePlateId,
                    (vehicleType ?? VehicleType.Default).Id,
                    tenantId,
                    name);

            var vehicle = new Vehicle();
            vehicle.Apply(@event);

            return (vehicle, new() { @event });
        }

        public void Apply(VehicleAdded @event)
        {
            Id = @event.VehicleId;

            LicensePlateId = @event.LicensePlateId;
            Type = @event.VehicleTypeId;
            Name = @event.Name;
            TenantId = @event.TenantId;
        }

        public Seq<IDomainEvent> InstallTracker(Tracker tracker)
        {
            var @event = new TrackerInstalled(
                    Id, tracker.Id,
                    tracker.SerialNumber,
                    tracker.Info?.Brand, tracker.Info?.Model);

            Apply(@event);

            return new()
            {
                @event
            };
        }

        public void Apply(TrackerInstalled @event)
        {
            trackers.Add(@event.TrackerId);
        }

        public Seq<IDomainEvent> RemoveTracker(TrackerId trackerId)
        {
            var @event = new TrackerRemoved(Id, trackerId);

            Apply(@event);

            return new()
            {
                @event
            };
        }

        public void Apply(TrackerRemoved @event)
        {
            trackers.RemoveAll(tid => tid == @event.TrackerId);
        }

        public Seq<IDomainEvent> ChangeLicensePlate(string newLicensePlateId)
        {
            var @event = new VehicleLicensePlateChanged(Id, this.LicensePlateId, newLicensePlateId);

            Apply(@event);

            return new() { @event };
        }

        public void Apply(VehicleLicensePlateChanged @event)
        {
            LicensePlateId = @event.NewLicensePlateId;
        }

        public Seq<IDomainEvent> ChangeName(string newName)
        {
            var @event = new VehicleNameChanged(Id, this.Name, newName);

            Apply(@event);

            return new() { @event };
        }

        public void Apply(VehicleNameChanged @event)
        {
            Name = @event.NewName;
        }

        public Seq<IDomainEvent> ChangeVehicleType(VehicleType newVehicleType)
        {
            var @event = new VehicleTypeChanged(Id, Type, newVehicleType.Id, newVehicleType.Name);

            Apply(@event);

            return new() { @event };
        }

        public void Apply(VehicleTypeChanged @event)
        {
            Type = @event.NewTypeId;
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

        public void Apply(VehicleTerminated @event)
        {
            TerminatedAt = DateTimeOffset.UtcNow;
        }
    }
}
