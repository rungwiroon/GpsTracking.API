using System;
using System.Collections.Generic;
using Domain.Tracker;
using Domain.User;

namespace Domain.Vehicle
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

    public class Vehicle
    {
        public VehicleId Id { get; }

        public string LicensePlateId { get; }

        public string? Name { get; }

        public VehicleInfo Info { get; }

        public VehicleType Type { get; }
        public VehicleGroup? Group { get; }

        public UserGroupId UserGroupId { get; }

        private readonly List<TrackerId> deviceIds = new();
        public IReadOnlyCollection<TrackerId> Devices => deviceIds;

        public DateTimeOffset CreatedAt { get; }

#pragma warning disable CS8618
        private Vehicle() { }
#pragma warning restore CS8618

        public Vehicle(
            string licensePlateId, UserGroupId userGroupId, 
            VehicleType? vehicleType = null, string? name = null)
        {
            Id = new();

            LicensePlateId = licensePlateId;
            Type = vehicleType ?? VehicleType.Default;
            Name = name;
            UserGroupId = userGroupId;

            CreatedAt = DateTimeOffset.UtcNow;
        }

        public void AttachDevice(TrackerId deviceId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDevice(TrackerId deviceId)
        {
            throw new NotImplementedException();
        }

        public void ChangeLicense(string license)
        {
            throw new NotImplementedException();
        }

        public void ChangeName(string name)
        {
            throw new NotImplementedException();
        }

        public void ChangeVehicleType(VehicleTypeId vehicleTypeId)
        {
            throw new NotImplementedException();
        }

        public void ChangeUserGroup(UserGroupId userGroupId)
        {
            throw new NotImplementedException();
        }
    }
}
