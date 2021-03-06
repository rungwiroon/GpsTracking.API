﻿using Core.Domain.Identity;
using Core.Domain.Identity.Repositories;
using Core.Domain.Vehicles.Commands;
using Core.Domain.Vehicles.Events;
using Core.Domain.Vehicles.Repositories;
using GpsTracking.Application;

namespace Core.Application.Vehicles
{
    public class VehicleCommandHandler :
        ICommandHandler<AddVehicle>,
        ICommandHandler<RemoveVehicle>
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IVehicleGroupRepository vehicleGroupRepository;
        private readonly ITenantRepository tenantRepository;
        private readonly IEventBus eventBus;

        public VehicleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUserGroupRepository userGroupRepository,
            IVehicleTypeRepository vehicleTypeRepository,
            IVehicleGroupRepository vehicleGroupRepository,
            ITenantRepository tenantRepository,
            IEventBus eventBus)
        {
            this.vehicleRepository = vehicleRepository;
            this.userGroupRepository = userGroupRepository;
            this.vehicleTypeRepository = vehicleTypeRepository;
            this.vehicleGroupRepository = vehicleGroupRepository;
            this.tenantRepository = tenantRepository;
            this.eventBus = eventBus;
        }

        public void Handle(AddVehicle command)
        {
            var userGroup = userGroupRepository.GetById(command.UserGroupId);
            var vehicleType = command.VehicleTypeId == null
                ? vehicleTypeRepository.GetById(command.VehicleTypeId)
                : null;
            var tenant = tenantRepository.GetById(userGroup.TenantId);

            var (vehicle, events) = tenant.CreateVehicle(
                command.LicensePlateId,
                vehicleType,
                command.Name);

            vehicleRepository.Create(vehicle);
            eventBus.Publish(events);
        }

        public void Handle(RemoveVehicle command)
        {
            var vehicleGroups = vehicleGroupRepository.GetByVehicleId(command.VehicleId);
            
            foreach(var vehicleGroup in vehicleGroups)
            {
                vehicleGroup.RemoveVehicle(command.VehicleId);
            }

            vehicleRepository.Delete(command.VehicleId);
            eventBus.Publish(new VehicleRemoved(command.VehicleId));
        }
    }
}
