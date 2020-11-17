using Domain;
using Domain.User;
using System;

namespace Core.Domain.Vehicle.Commands
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
