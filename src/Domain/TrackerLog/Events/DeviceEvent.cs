﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Tracker;

namespace Domain.TrackerLog.Events
{
    public abstract class DeviceEvent
    {
        public DeviceId DeviceId { get; }
        public DateTimeOffset TimeStamp { get; }
    }
}