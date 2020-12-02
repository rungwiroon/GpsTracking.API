using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Repositories
{
    public interface IVehicleGroupRepository : IRepository
    {
        VehicleGroup[] GetByUserTenantId(UserAccountId userAccountId);

        VehicleGroup[] GetByVehicleId(VehicleId vehicleId);

        void Create(VehicleGroup vehicleGroup);
        void Update(VehicleGroup vehicleGroup);
        void Delete(VehicleGroupId vehicleGroupId);
    }
}