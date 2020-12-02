using System.Linq;
using Core.Domain.Identity;
using Core.Domain.Identity.Events;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Commands;
using Core.Domain.Vehicles.Repositories;
using GpsTracking.Application;

namespace Core.Application.Vehicles
{
    public class VehicleGroupCommandHandler :
        ICommandHandler<CreateVehicleGroup>,
        ICommandHandler<DeleteVehicleGroup>
    {
        private readonly IVehicleGroupRepository vehicleGroupRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IEventBus eventBus;

        public VehicleGroupCommandHandler(
            IVehicleGroupRepository vehicleGroupRepository,
            IVehicleRepository vehicleRepository,
            IUserGroupRepository userGroupRepository,
            IEventBus eventBus)
        {
            this.vehicleGroupRepository = vehicleGroupRepository;
            this.vehicleRepository = vehicleRepository;
            this.userGroupRepository = userGroupRepository;
            this.eventBus = eventBus;
        }

        public void Handle(CreateVehicleGroup command)
        {
            var vehicleGroup = new VehicleGroup(command.TenantId, command.Name);

            vehicleGroupRepository.Create(vehicleGroup);
        }

        public void Handle(DeleteVehicleGroup command)
        {
            var vehicles = vehicleRepository.GetByVehicleGroupId(command.VehicleGroupId);
            var userGroups = userGroupRepository.GetByVehicleGroupId(command.VehicleGroupId);

            vehicleGroupRepository.Delete(command.VehicleGroupId);

            foreach(var userGroup in userGroups)
            {
                var vehicleRemovedFromUserGroup = new VehiclesRemovedFromUserGroup(
                    userGroup.Id, userGroup.Name,
                    vehicles.Select(v => new VehiclesRemovedFromUserGroup.Vehicle(
                        v.Id, v.LicensePlateId, v.Name)));

                eventBus.Publish(vehicleRemovedFromUserGroup);
            }
        }
    }
}
