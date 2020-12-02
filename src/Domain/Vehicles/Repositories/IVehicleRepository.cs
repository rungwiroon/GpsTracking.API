using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Repositories
{
    public interface IVehicleRepository : IRepository
    {
        Vehicle[] GetByUserTenantId(UserAccountId userAccountId);

        Vehicle[] GetByVehicleGroupId(VehicleGroupId vehicleGroupId);

        void Create(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(VehicleId vehicleId);
    }
}