using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.TrackerLogs
{
    public record TrackerLogId : EntityId
    {
        public TrackerLogId() : base() { }

        public TrackerLogId(Guid id) : base(id) { }
    }

    public class TrackerLog : IEntity, IAggregateRoot
    {
        public TrackerLogId Id { get; }


    }
}
