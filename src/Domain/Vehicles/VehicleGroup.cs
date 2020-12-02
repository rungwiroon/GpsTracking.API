using Core.Domain.SeedWork;
using Core.Domain.Vehicles.Events;
using Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public VehicleGroup(TenantId tenantId,
            string name, string? description = null)
        {
            Id = new VehicleGroupId();
            Name = name;
            TenantId = tenantId;
            Description = description;

            AddDomainEvent(new VehicleGroupCreated(TenantId, Id, Name));
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if(vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            vehicles.Add(vehicle);

            AddDomainEvent(new VehicleAddedToGroup(
                vehicle.TenantId, Id, Name, vehicle.Id, 
                vehicle.LicensePlateId, vehicle.Name));
        }

        public void AddVehicles(IEnumerable<Vehicle> vehicles)
        {
            if(vehicles == null)
                throw new ArgumentNullException(nameof(vehicles));

            this.vehicles.AddRange(vehicles);

            foreach(var vehicle in vehicles)
                AddDomainEvent(new VehicleAddedToGroup(
                    TenantId, Id, Name, vehicle.Id, 
                    vehicle.LicensePlateId, vehicle.Name));
        }

        public void RemoveVehicle(VehicleId vehicleId)
        {
            if(vehicleId == null)
                throw new ArgumentNullException(nameof(vehicleId));

            this.vehicles.Remove(this.vehicles.Single(v => v.Id == vehicleId));

            AddDomainEvent(new VehicleRemovedFromGroup(Id, vehicleId));
        }

        public void Clear()
        {
            var vehiclesToRemove = this.Vehicles.ToArray();
            vehicles.Clear();
            
            foreach(var vehicle in vehiclesToRemove)
                AddDomainEvent(new VehicleRemovedFromGroup(Id, vehicle.Id));
        }
    }
}
