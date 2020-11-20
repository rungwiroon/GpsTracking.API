using Core.Domain.Vehicles;

namespace Core.Domain.Identity
{
    public interface IUserGroupRepository
    {
        UserGroup GetById(UserGroupId userGroupId);

        UserGroup[] GetByUserTenantId(UserAccountId userAccountId);

        UserGroup[] GetByVehicleId(VehicleId vehicleId);

        void Update(UserGroup userGroup);
    }
}