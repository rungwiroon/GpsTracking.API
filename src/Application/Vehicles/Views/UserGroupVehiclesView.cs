using Core.Domain.Identity;
using Core.Domain.Identity.Events;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Vehicles.Views
{
    public class UserGroupVehiclesView : IViewModel
    {
        public UserGroupId UserGroupId { get; private set; }

        public string UserGroupName { get; private set; }

        private readonly Dictionary<VehicleId, VehicleInGroupView> vehicles = new();
        public IEnumerable<VehicleInGroupView> Vehicles => vehicles
            .Select(v => v.Value);

        public void Apply(UserGroupCreated @event)
        {
            UserGroupId = @event.UserGroupId;
            UserGroupName = @event.UserGroupName;
        }

        public void Apply(VehiclesAddedToUserGroup @event)
        {
            foreach(var e in @event.Vehicles)
            {
                vehicles.Add(e.VehicleId, new VehicleInGroupView()
                {
                    VehicleId = e.VehicleId,
                    LicensePlateId = e.LicensePlateId,
                    Name = e.Name
                });
            }
        }

        public void Apply(VehiclesRemovedFromUserGroup @event)
        {
            foreach (var e in @event.Vehicles)
            {
                vehicles.Remove(e.VehicleId);
            }
        }
    }
}
