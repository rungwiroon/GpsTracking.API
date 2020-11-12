﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DeviceEvents
{
    public class PositionEvent : DeviceEvent
    {
        public GpsPosition Position { get; }

        public float Speed { get; }

        public float Heading { get; }

        public float Accuracy { get; }
    }
}
