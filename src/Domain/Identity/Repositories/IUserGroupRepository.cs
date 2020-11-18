using Core.Domain.Vehicles;

namespace Core.Domain.Identity
{
    public interface IUserGroupRepository
    {
        UserGroup GetById(UserGroupId userGroupId);

        UserGroup[] GetByUserAccountId(UserAccountId userAccountId);

        UserGroup[] GetByVehicleId(VehicleId vehicleId);

        void Update(UserGroup userGroup);
    }
}