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

    public class Vehicle
    {
        public VehicleId Id { get; }

        public string LicensePlateId { get; }

        public string? Name { get; }

        public VehicleType Type { get; }
        public VehicleGroup? Group { get; }

        public UserGroupId UserGroupId { get; }

        private DeviceId[] deviceIds;
        public IReadOnlyCollection<DeviceId> Devices => deviceIds;

        public DateTimeOffset CreatedAt { get; }

        private Vehicle() { }

        public Vehicle(string licensePlateId, UserGroupId userGroupId, VehicleType? vehicleType = null, string? name = null)
        {
            LicensePlateId = licensePlateId;
            Type = vehicleType ?? VehicleType.Default;
            Name = name;
            UserGroupId = userGroupId;
        }

        public void AddDevice(DeviceId deviceId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDevice(DeviceId deviceId)
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
