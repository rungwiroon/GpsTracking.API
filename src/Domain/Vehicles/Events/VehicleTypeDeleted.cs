﻿using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Vehicles.Events
{
    public class VehicleTypeDeleted : IDomainEvent
    {
        public DateTimeOffset GlobalSequenceNumber => throw new NotImplementedException();
    }
}
