using System;
using Core.Application;
using Core.Domain.Identity;
using Core.Domain.Identity.Commands;
using Core.Domain.Identity.Repositories;

namespace GpsTracking.Application.Accounts
{
    public class AccountHandler : ICommandHandler<RegisterTenant>
    {
        private readonly ITenantRepository tenantRepository;
        private readonly IEventBus eventBus;

        public AccountHandler(
            ITenantRepository tenantRepository, IEventBus eventBus)
        {
            this.tenantRepository = tenantRepository;
            this.eventBus = eventBus;
        }

        public void Handle(RegisterTenant command)
        {
            var newId = 1111;
            var (tenant, userAccount, events) = Tenant.CreateAccount(newId, 
                command.UserName, command.Password, command.Email);

            tenantRepository.Create(tenant);
            eventBus.Publish(events);
        }
    }
}
