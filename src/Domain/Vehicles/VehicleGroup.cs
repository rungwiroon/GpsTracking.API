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

        private readonly List<Vehicle> vehicles = new();
        public IReadOnlyCollection<Vehicle> Vehicles => vehicles.AsReadOnly();

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

            vehicles.Add(vehicle);

            return new()
            {
                new VehicleAddedToGroup(
                    vehicle.TenantId, Id, Name, vehicle.Id,
                    vehicle.LicensePlateId, vehicle.Name)
            };
        }

        public Seq<IDomainEvent> AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            if(vehicles == null)
                throw new ArgumentNullException(nameof(vehicles));

            this.vehicles.AddRange(vehicles);

            return vehicles
                .Select(vehicle => (IDomainEvent)new VehicleAddedToGroup(
                    TenantId, Id, Name, vehicle.Id, 
                    vehicle.LicensePlateId, vehicle.Name))
                .ToSeq();
        }

        public Seq<IDomainEvent> RemoveVehicle(VehicleId vehicleId)
        {
            if(vehicleId == null)
                throw new ArgumentNullException(nameof(vehicleId));

            this.vehicles.Remove(this.vehicles.Single(v => v.Id == vehicleId));

            return new() { new VehicleRemovedFromGroup(Id, vehicleId) };
        }

        public Seq<IDomainEvent> Clear()
        {
            var vehiclesToRemove = this.Vehicles.ToArray();
            vehicles.Clear();
            
            return vehiclesToRemove
                .Select(vehicle => (IDomainEvent)new VehicleRemovedFromGroup(Id, vehicle.Id))
                .ToSeq();
        }
    }
}
