using Core.Domain.Identity;
using Core.Domain.SeedWork;
using System;

namespace Core.Domain.Vehicles.Repositories
{
    public interface IVehicleTypeRepository : IRepository
    {
        VehicleType[] GetByTenantId(TenantId tenantId);

        VehicleType GetById(VehicleTypeId id);

        void Create(VehicleType vehicleType);
        void Update(VehicleType vehicleType);
    }
}