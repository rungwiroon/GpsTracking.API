using Domain;
using Core.Domain.Identity;
using System;

namespace Core.Domain.Vehicles.Commands
{
    [Serializable]
    public class AddVehicle : ICommand
    {
        public UserAccountId IssuedBy { get; }

        public string LicensePlateId { get; }

        public UserGroupId UserGroupId { get; }

        public string? Name { get; }

        public string? Brand { get; }

        public string? Model { get; }

        public int? Mileage { get; }

        public VehicleTypeId? VehicleTypeId { get; }

        public VehicleGroupId? VehicleGroupId { get; }

        public AddVehicle(
            string licensePlateId, UserGroupId userGroupId,
            string? brand, string? model, string name, int? mileage,
            VehicleTypeId? vehicleTypeId, VehicleGroupId? vehicleGroupId)
        {
            LicensePlateId = licensePlateId;
            UserGroupId = userGroupId;
            Brand = brand;
            Model = model;
            Name = name;
            Mileage = mileage;
            VehicleTypeId = vehicleTypeId;
            VehicleGroupId = vehicleGroupId;
        }
    }
}