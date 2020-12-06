using System;
using Core.Domain.SeedWork;

namespace Core.Domain.Vehicles
{
    public record VehicleTypeId : EntityId
    {
        public VehicleTypeId() : base() { }

        public VehicleTypeId(Guid id) : base(id) { }
    }

    public class VehicleType : Entity
    {
        public VehicleTypeId Id { get; }

        public string Name { get; }

        public string? Description { get; }

        public Uri? IconUrl { get; }

        //public Icon Icon { get; }

        private static readonly VehicleType defaultType = new (
            new VehicleTypeId(Guid.Empty), "Default", "Default vehicle type");
        public static VehicleType Default => defaultType;

        internal VehicleType(VehicleTypeId id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
