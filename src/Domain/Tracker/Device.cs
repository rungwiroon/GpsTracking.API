using Domain.DeviceOpions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public sealed record DeviceId : EntityId
    {
        public DeviceId() : base() { }

        public DeviceId(Guid id) : base(id) { }
    }

    public class Device
    {
        public DeviceId Id { get; }

        public DeviceOption? Option { get; }

        public Device()
        {
            Id = new DeviceId();
        }

        public Device(DeviceId deviceId)
        {
            Id = deviceId;
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
