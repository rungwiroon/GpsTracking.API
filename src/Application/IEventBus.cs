using Core.Domain.SeedWork;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public interface IEventBus
    {
        Unit Publish(IDomainEvent @event);
        Unit Publish(Seq<IDomainEvent> domainEvents);
    }
}
