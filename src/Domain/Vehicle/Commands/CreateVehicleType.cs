using Domain;
using System;

namespace Core.Domain.Vehicle.Commands
{
    [Serializable]
    public class CreateVehicleType : ICommand
    {
        public string Name { get; }

        public Icon Icon { get; }

        public CreateVehicleType(
            string name, Icon? icon = null)
        {
            Name = name;
            Icon = icon ?? Icon.Default;
        }
    }
}