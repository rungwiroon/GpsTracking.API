using Core.Domain.Identity;
using Core.Domain.Vehicles;
using Core.Domain.Vehicles.Commands;
using Core.Domain.Vehicles.Repositories;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Vehicles
{
    public class VehicleCommandHandler :
        ICommandHandler<AddVehicle>,
        ICommandHandler<RemoveVehicle>
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;

        public VehicleCommandHandler(
            IVehicleRepository vehicleRepository,
            IUserGroupRepository userGroupRepository, 
            IVehicleTypeRepository vehicleTypeRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.userGroupRepository = userGroupRepository;
            this.vehicleTypeRepository = vehicleTypeRepository;
        }

        public void Handle(AddVehicle command)
        {
            var userGroup = userGroupRepository.GetById(command.UserGroupId);
            var vehicleType = command.VehicleTypeId == null
                ? vehicleTypeRepository.GetById(command.VehicleTypeId)
                : null;
            var vehicle = new Vehicle(
                command.LicensePlateId,
                userGroup.TenantId,
                vehicleType,
                command.Name);

            vehicleRepository.Create(vehicle);
        }

        public void Handle(RemoveVehicle command)
        {
            throw new NotImplementedException();
        }
    }
}
