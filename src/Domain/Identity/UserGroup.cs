using Core.Domain.Identity.Events;
using Core.Domain.SeedWork;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Events;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Identity
{
    [Serializable]
    public record UserGroupId : EntityId
    {
        public UserGroupId() : base() { }

        public UserGroupId(Guid id) : base(id) { }
    }

    [Serializable]
    public class UserGroup : Entity, IAggregateRoot
    {
        public UserGroupId Id { get; }

        public UserGroup? Parent { get; }

        public string Name { get; private set; }

        public string? Descriptions { get; private set; }

        public TenantId TenantId { get; }

        private readonly List<UserAccountId> userAccounts = new();
        public IReadOnlyCollection<UserAccountId> Accounts => userAccounts.AsReadOnly();

        private readonly List<VehicleId> vehicles = new();
        public IReadOnlyCollection<VehicleId> Vehicles => vehicles.AsReadOnly();

        private readonly List<VehicleGroupId> vehicleGroups = new();
        public IReadOnlyCollection<VehicleGroupId> VehicleGroups => vehicleGroups.AsReadOnly();

#pragma warning disable CS8618
        private UserGroup() { }
#pragma warning restore CS8618

        internal UserGroup(TenantId owner, string name, string? descriptions = null)
        {
            Id = new UserGroupId();
            Name = name;
            Descriptions = descriptions;
            TenantId = owner;
        }

        public Seq<IDomainEvent> ChangeName(string newName)
        {
            if(string.IsNullOrEmpty(newName))
                throw new ArgumentNullException();

            var @event = new UserGroupRenamed(Id, Name, newName);
            
            Name = newName;

            return new() { @event };
        }

        public void ChangeDescription(string newDescriptions)
        {
            Descriptions = newDescriptions;
        }

        public Seq<IDomainEvent> AddAccount(UserAccount account)
        {
            userAccounts.Add(account.Id);

            return new() { new UserAddedToGroup(Id, account.Id, Name, account.UserName) };
        }

        public Seq<IDomainEvent> RemoveAccount(UserAccountId tenantId)
        {
            userAccounts.Remove(userAccounts.Single(aId => aId == tenantId));

            return new() { new UserRemovedFromGroup(Id, tenantId) };
        }

        public Seq<IDomainEvent> ClearUsers()
        {
            var accountsToRemove = userAccounts.ToArray();

            userAccounts.Clear();

            return accountsToRemove
                .Select(uid => (IDomainEvent)new UserRemovedFromGroup(Id, uid))
                .ToSeq();
        }

        public Seq<IDomainEvent> AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle.Id);

            return new()
            {
                new VehicleAddedToUserGroup(Id, vehicle.Id, vehicle.LicensePlateId, vehicle.Name)
            };
        }

        public Seq<IDomainEvent> RemoveVehicle(VehicleId vehicleId)
        {
            vehicles.Remove(vehicles.Single(vId => vId == vehicleId));

            return new()
            {
                new VehicleRemovedFromUserGroup(Id, vehicleId)
            };
        }

        public Seq<IDomainEvent> ClearVehicles()
        {
            var vehiclesToRemove = vehicles.ToArray();

            vehicles.Clear();

            return vehiclesToRemove
                .Select(vehicleId => (IDomainEvent)new VehicleRemovedFromUserGroup(Id, vehicleId))
                .ToSeq();
        }

        public Seq<IDomainEvent> AddVehicleGroup(VehicleGroup vehicleGroup)
        {
            vehicleGroups.Add(vehicleGroup.Id);

            return new()
            {
                new VehicleGroupAddedToUserGroup(
                    TenantId,
                    vehicleGroup.Id, vehicleGroup.Name,
                    this.Id, this.Name)
            };
        }
        
        public Seq<IDomainEvent> RemoveVehicleGroup(VehicleGroupId vehicleGroupId)
        {
            vehicleGroups.RemoveAll(vg => vg == vehicleGroupId);

            return new()
            {
                new VehicleGroupRemovedFromUserGroup(
                    vehicleGroupId, Id)
            };
        }
    }
}
