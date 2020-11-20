using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Repositories
{
    public interface IVehicleRepository : IRepository
    {
        Vehicle[] GetByUserTenantId(UserAccountId userAccountId);
        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
    }
}