using Core.Domain.SeedWork;
using Core.Domain.Vehicles.Events;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Core.Domain.Vehicles
{
    public record VehicleGroupId : EntityId
    {
        public VehicleGroupId() : base() { }

        public VehicleGroupId(Guid id) : base(id) { }
    }

    public class VehicleGroup : Entity, IAggregateRoot
    {
        public VehicleGroupId Id { get; }

        public TenantId TenantId { get; }

        public string Name { get; }

        public string? Description { get; }

        private readonly List<VehicleId> vehicles = new();
        public IReadOnlyCollection<VehicleId> Vehicles => vehicles.AsReadOnly();

#pragma warning disable CS8618
        private VehicleGroup() { }
#pragma warning restore CS8618

        internal VehicleGroup(TenantId tenantId,
            string name, string? description = null)
        {
            Id = new VehicleGroupId();
            Name = name;
            TenantId = tenantId;
            Description = description;
        }

        public Seq<IDomainEvent> AddVehicle(Vehicle vehicle)
        {
            if(vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            var @event = new VehicleAddedToGroup(
                    vehicle.TenantId, Id, Name, vehicle.Id,
                    vehicle.LicensePlateId, vehicle.Name);

            Apply(@event);

            return new() { @event };
        }

        public void Apply(VehicleAddedToGroup @event)
        {
            vehicles.Add(@event.VehicleId);
        }

        public Seq<IDomainEvent> AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            if(vehicles == null)
                throw new ArgumentNullException(nameof(vehicles));

            var events = vehicles
                .Select(vehicle => new VehicleAddedToGroup(
                    TenantId, Id, Name, vehicle.Id, 
                    vehicle.LicensePlateId, vehicle.Name))
                .ToSeq();

            foreach(var @event in events)
            {
                Apply(@event);
            }

            return events.Cast<IDomainEvent>();
        }

        public Seq<IDomainEvent> RemoveVehicle(VehicleId vehicleId)
        {
            if(vehicleId == null)
                throw new ArgumentNullException(nameof(vehicleId));

            var @event = new VehicleRemovedFromGroup(Id, vehicleId);
            Apply(@event);

            return new() { @event };
        }

        public void Apply(VehicleRemovedFromGroup @event)
        {
            this.vehicles.RemoveAll(vId => vId == @event.VehicleId);
        }

        public Seq<IDomainEvent> Clear()
        {
            var vehiclesToRemove = this.Vehicles.ToArray();
            var events = vehiclesToRemove
                .Select(vId => new VehicleRemovedFromGroup(Id, vId))
                .ToSeq();

            foreach(var @event in events)
            {
                Apply(@event);
            }

            return events.Cast<IDomainEvent>();
        }
    }
}
