using Domain;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class CreateVehicleGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }

        public string Name { get; }

        public CreateVehicleGroup(
            UserGroupId userGroupId, string name)
        {
            UserGroupId = userGroupId;
            Name = name;
        }
    }
}
