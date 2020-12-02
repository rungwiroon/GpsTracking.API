using Domain;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class CreateVehicleGroup : ICommand
    {
        public TenantId TenantId { get; }

        public string Name { get; }

        public CreateVehicleGroup(
            TenantId tenantId, string name)
        {
            TenantId = tenantId;
            Name = name;
        }
    }
}
