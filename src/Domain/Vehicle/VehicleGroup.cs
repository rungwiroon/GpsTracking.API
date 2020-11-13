using System;
using System.Collections.Generic;
using Domain.User;

namespace Domain.Vehicle
{
    public record VehicleGroupId : EntityId
    {
        public VehicleGroupId() : base() { }

        public VehicleGroupId(Guid id) : base(id) { }
    }

    public class VehicleGroup
    {
        public VehicleGroupId Id { get; }

        public UserGroupId UserGroupId { get; }

        public string Name { get; }

        public string? Description { get; }

#pragma warning disable CS8618
        private VehicleGroup() { }
#pragma warning restore CS8618

        public VehicleGroup(string name, UserGroupId userGroupId, string? description = null)
        {
            Id = new VehicleGroupId();
            Name = name;
            UserGroupId = userGroupId;
            Description = description;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            throw new NotImplementedException();
        }

        public void RemoveVehicle(VehicleId vehicleId)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
