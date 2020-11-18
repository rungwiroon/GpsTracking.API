using Core.Domain.SeedWork;
using Core.Domain.Trackers;
using Core.Domain.Vehicles.Events;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public VehicleGroup? Group { get; }

        public AccountId AccountId { get; private set; }

        private readonly List<TrackerId> trackers = new();
        public IReadOnlyCollection<TrackerId> Trackers => trackers;

        public DateTimeOffset CreatedAt { get; }

#pragma warning disable CS8618
        private Vehicle() { }
#pragma warning restore CS8618

        public Vehicle(
            string licensePlateId, AccountId accountId, 
            VehicleType? vehicleType = null, string? name = null)
        {
            Id = new();

            LicensePlateId = licensePlateId;
            Type = vehicleType ?? VehicleType.Default;
            Name = name;
            AccountId = accountId;

            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void InstallTracker(Tracker tracker)
        {
            trackers.Add(tracker.Id);

            base.AddDomainEvent(new TrackerInstalled(Id, tracker.Id, 
                tracker.SerialNumber, tracker.Info?.Brand, tracker.Info?.Model));
        }

        public void RemoveTracker(TrackerId trackerId)
        {
            trackers.Remove(trackers.Single(t => t == trackerId));

            base.AddDomainEvent(new TrackerRemoved(Id, trackerId));
        }

        public void ChangeLicensePlate(string newLicensePlateId)
        {
            var @event = new VehicleLicensePlateChanged(Id, this.LicensePlateId, newLicensePlateId);

            LicensePlateId = newLicensePlateId;

            base.AddDomainEvent(@event);
        }

        public void ChangeName(string newName)
        {
            var @event = new VehicleNameChanged(Id, this.Name, newName);

            Name = newName;

            base.AddDomainEvent(@event);
        }

        public void ChangeVehicleType(VehicleType newVehicleType)
        {
            var @event = new VehicleTypeChanged(Id, Type, newVehicleType);

            Type = newVehicleType;

            base.AddDomainEvent(@event);
        }

        //public void ChangeUserGroup(UserGroupId newUserGroupId)
        //{
        //    var @event = new VehicleGroupChanged(Id, AccountId, newUserGroupId);

        //    AccountId = newUserGroupId;

        //    AddDomainEvent(@event);
        //}
    }
}
