using Domain;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using static LanguageExt.Prelude;

namespace Core.Domain.SeedWork
{
    public class Entity : IEntity
    {
        //[NonSerialized] private readonly Queue<IDomainEvent> uncommittedEvents = new ();

        //public Unit AddDomainEvent(IDomainEvent @event)
        //{
        //    uncommittedEvents.Enqueue(@event);
        //    return unit;
        //}
    }
}
