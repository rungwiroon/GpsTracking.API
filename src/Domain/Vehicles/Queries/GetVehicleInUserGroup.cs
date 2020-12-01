using Core.Domain.Identity;
using Core.Domain.Vehicles.Views;

namespace Core.Domain.Vehicles.Queries
{
    public class GetVehicleInUserGroup : IQuery<UserGroupVehiclesView>
    {
        public UserGroupId UserGroupId { get; }

        public GetVehicleInUserGroup(UserGroupId userGroupId)
        {
            UserGroupId = userGroupId;
        }
    }
}
