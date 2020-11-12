using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Vehicle
{
    public record VehicleId : EntityId
    {

    }

    public class Vehicle
    {
        public VehicleId Id { get; }

        public string LicensePlate { get; }

        public string Name { get; }


        private DeviceId[] deviceIds;
        public IReadOnlyCollection<DeviceId> Devices => deviceIds;

        public void AddDevice(DeviceId deviceId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDevice(DeviceId deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
