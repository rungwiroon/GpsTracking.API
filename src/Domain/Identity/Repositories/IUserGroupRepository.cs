using Core.Domain.Vehicles;

namespace Core.Domain.Identity
{
    public interface IUserGroupRepository
    {
        UserGroup GetById(UserGroupId userGroupId);

        UserGroup[] GetByUserTenantId(UserAccountId userAccountId);

        UserGroup[] GetByVehicleId(VehicleId vehicleId);

        UserGroup[] GetByVehicleGroupId(VehicleGroupId vehicleGroupId);

        void Update(UserGroup userGroup);
    }
}