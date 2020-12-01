using System;
using Core.Application;
using Core.Domain;
using Domain;

namespace GpsTracking.Application
{
    public interface ICommandHandler<T>
        where T : ICommand
    {
        void Handle(T command);
    }

    public interface IEventHandler<T>
        where T : IEvent<T>
    {
        void Handle(IEvent<T> @event);
    }

    public interface IQueryHandler<T, U>
        where T : IQuery<U>
        where U : IViewModel
    {
        U Handle(T query);
    }
}