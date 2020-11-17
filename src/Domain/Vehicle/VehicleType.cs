using System;
using Core.Domain.SeedWork;
using Core.Domain.Vehicle.Events;

namespace Core.Domain.Vehicle
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

        private static readonly VehicleType defaultType = new (
            new VehicleTypeId(Guid.Empty), "Default", "Default vehicle type");
        public static VehicleType Default => defaultType;

        public VehicleType(VehicleTypeId id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;

            base.AddDomainEvent(new VehicleTypeCreated(Id, Name));
        }
    }
}
