using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle
{
    public record VehicleTypeId : EntityId
    {
        public VehicleTypeId() : base() { }

        public VehicleTypeId(Guid id) : base(id) { }
    }

    public class VehicleType
    {
        public VehicleTypeId Id { get; }

        public string Name { get; }

        public string? Description { get; }

        public Uri? IconUrl { get; }

        private static VehicleType defaultType = new (
            new VehicleTypeId(Guid.Empty), "Default", "Default vehicle type");
        public static VehicleType Default => defaultType;

        public VehicleType(VehicleTypeId id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
