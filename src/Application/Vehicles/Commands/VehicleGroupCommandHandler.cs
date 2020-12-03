using Core.Domain.Identity;
using Core.Domain.Identity.Events;
using Core.Domain.Identity.Repositories;
using Core.Domain.SeedWork;
using Core.Domain.Vehicles.Commands;
using Core.Domain.Vehicles.Repositories;
using GpsTracking.Application;
using System.Linq;

namespace Core.Application.Vehicles
{
    public class VehicleGroupCommandHandler :
        ICommandHandler<CreateVehicleGroup>,
        ICommandHandler<DeleteVehicleGroup>
    {
        private readonly IVehicleGroupRepository vehicleGroupRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly ITenantRepository tenantRepository;
        private readonly IEventBus eventBus;

        public VehicleGroupCommandHandler(
            IVehicleGroupRepository vehicleGroupRepository,
            IVehicleRepository vehicleRepository,
            IUserGroupRepository userGroupRepository,
            ITenantRepository tenantRepository,
            IEventBus eventBus)
        {
            this.vehicleGroupRepository = vehicleGroupRepository;
            this.vehicleRepository = vehicleRepository;
            this.userGroupRepository = userGroupRepository;
            this.tenantRepository = tenantRepository;
            this.eventBus = eventBus;
        }

        public void Handle(CreateVehicleGroup command)
        {
            var tenant = tenantRepository.GetById(command.TenantId);
            var (vehicleGroup, events) = tenant.CreateVehicleGroup(command.Name, command.Description);

            vehicleGroupRepository.Create(vehicleGroup);

            eventBus.Publish(events);
        }

        public void Handle(DeleteVehicleGroup command)
        {
            var vehicles = vehicleRepository.GetByVehicleGroupId(command.VehicleGroupId);
            var userGroups = userGroupRepository.GetByVehicleGroupId(command.VehicleGroupId);

            vehicleGroupRepository.Delete(command.VehicleGroupId);

            var events = userGroups
                .Select(userGroup => (IDomainEvent)new VehiclesRemovedFromUserGroup(
                    userGroup.Id, userGroup.Name,
                    vehicles.Select(v => new VehiclesRemovedFromUserGroup.Vehicle(
                        v.Id, v.LicensePlateId, v.Name))))
                .ToSeq();

            eventBus.Publish(events);
        }
    }
}
