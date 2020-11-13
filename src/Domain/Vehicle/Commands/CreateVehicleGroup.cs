using Domain;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class CreateVehicleGroup : ICommand
    {
        public UserGroupId UserGroupId { get; }

        public string Name { get; }
    }
}
