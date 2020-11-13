using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Tracker
{
    public sealed record DeviceId : EntityId
    {
        public DeviceId() : base() { }

        public DeviceId(Guid id) : base(id) { }
    }

    [Serializable]
    public class Device
    {
        public DeviceId Id { get; }

        public string SerialNumber { get; }

        public DeviceOption? Option { get; }

        private List<DeviceModule> modules;

        private List<Sensor> sensors;

        public Device()
        {
            Id = new DeviceId();
        }

        public Device(DeviceId deviceId)
        {
            Id = deviceId;
        }

        public void AddModule()
        {
            throw new NotImplementedException();
        }

        public void RemoveModule()
        {
            throw new NotImplementedException();
        }

        public void AddSensor()
        {
            throw new NotImplementedException();
        }

        public void RemoveSensor()
        {
            throw new NotImplementedException();
        }
    }
}
