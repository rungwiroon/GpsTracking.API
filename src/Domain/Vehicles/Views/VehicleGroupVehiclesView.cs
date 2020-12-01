using Core.Domain.Identity;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Vehicles.Views
{
    public class VehicleGroupVehiclesView : IViewModel
    {
        public TenantId TenantId { get; }

        public VehicleGroupId VehicleGroupId { get; }

        public string VehicleGroupName { get; set; }

        private readonly Dictionary<VehicleId, VehicleInGroupView> vehicles = new ();
        public IEnumerable<VehicleInGroupView> Vehicles => vehicles
            .Select(v => v.Value);

        public long LastEventSeq { get; private set; }

        public VehicleGroupVehiclesView(VehicleGroupCreated @event)
        {
            TenantId = @event.TenantId;
            VehicleGroupId = @event.VehicleGroupId;
            VehicleGroupName = @event.VehicleGroupName;
        }

        public long UpdateLastEventSequence(long seq)
            => seq > LastEventSeq
                ? LastEventSeq = seq
                : throw new ArgumentException("Sequence must greater than current last event sequence.");

        public void Apply(VehicleGroupRenamed @event)
        {
            VehicleGroupName = @event.NewName;
        }

        public void Apply(VehicleAddedToGroup @event)
        {
            vehicles.Add(@event.VehicleId, new VehicleInGroupView()
            {
                VehicleId = @event.VehicleId,
                LicensePlateId = @event.VehicleLicensePlateId,
                Name = @event.VehicleName,
            });
        }

        public void Apply(VehicleRemovedFromGroup @event)
        {
            vehicles.Remove(@event.VehicleId);
        }

        public void Apply(VehicleLicensePlateChanged @event)
        {
            var vehicle = vehicles[@event.VehicleId];
            vehicle.LicensePlateId = @event.NewLicensePlateId;
        }

        public void Apply(VehicleNameChanged @event)
        {
            var vehicle = vehicles[@event.VehicleId];
            vehicle.Name = @event.NewName;
        }
    }
}
