using System;
using System.Collections.Generic;
using System.Text;
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

        public string Description { get; }
    }
}
