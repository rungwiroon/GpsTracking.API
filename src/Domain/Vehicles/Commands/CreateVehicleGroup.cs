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

        public string? Description { get; }

        public CreateVehicleGroup(
            TenantId tenantId, string name, string? description = null)
        {
            TenantId = tenantId;
            Name = name;
            Description = description;
        }
    }
}
