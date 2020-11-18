using System;
using System.Collections.Generic;
using Core.Domain.SeedWork;
using Core.Domain.Identity.Events;
using System.Linq;
using Core.Domain.Vehicles;

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

        public AccountId AccountId { get; }

        private readonly List<UserAccountId> accounts = new();
        public IReadOnlyCollection<UserAccountId> Accounts => accounts.AsReadOnly();

        private readonly List<VehicleId> vehicles = new();
        public IReadOnlyCollection<VehicleId> Vehicles => vehicles.AsReadOnly();

        internal UserGroup(AccountId owner, string name, string? descriptions = null)
        {
            Id = new UserGroupId();
            Name = name;
            Descriptions = descriptions;
            AccountId = owner;

            AddDomainEvent(new UserGroupCreated(Id, Name, owner));
        }

        public void ChangeName(string newName)
        {
            if(string.IsNullOrEmpty(newName))
                throw new ArgumentNullException();

            var @event = new UserGroupRenamed(Id, Name, newName);
            
            Name = newName;

            AddDomainEvent(@event);
        }

        public void ChangeDescription(string newDescriptions)
        {
            Descriptions = newDescriptions;
        }

        public void AddAccount(UserAccount account)
        {
            accounts.Add(account.Id);

            AddDomainEvent(new UserAddedToGroup(Id, account.Id, Name, account.UserName));
        }

        public void RemoveAccount(UserAccountId accountId)
        {
            accounts.Remove(accounts.Single(aId => aId == accountId));

            AddDomainEvent(new UserRemovedFromGroup(Id, accountId));
        }

        public void ClearUsers()
        {
            var accountsToRemove = accounts.ToArray();

            accounts.Clear();

            foreach(var accountId in accountsToRemove)
                AddDomainEvent(new UserRemovedFromGroup(Id, accountId));
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle.Id);

            AddDomainEvent(new VehicleAddedToUserGroup(Id, vehicle.Id, vehicle.LicensePlateId, vehicle.Name));
        }

        public void RemoveVehicle(VehicleId vehicleId)
        {
            vehicles.Remove(vehicles.Single(vId => vId == vehicleId));

            AddDomainEvent(new VehicleRemovedFromUserGroup(Id, vehicleId));
        }

        public void ClearVehicles()
        {
            var vehiclesToRemove = vehicles.ToArray();

            vehicles.Clear();

            foreach (var vehicleId in vehiclesToRemove)
                AddDomainEvent(new VehicleRemovedFromUserGroup(Id, vehicleId));
        }
    }
}
