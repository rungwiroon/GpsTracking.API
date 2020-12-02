using Core.Domain.Identity;
using Core.Domain.Identity.Commands;
using Core.Domain.Identity.Repositories;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Accounts
{
    public class UserAccountHandler : ICommandHandler<CreateEditorAccount>
    {
        private readonly ITenantRepository tenantRepository;

        public UserAccountHandler(
            ITenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        public void Handle(CreateEditorAccount command)
        {
            var tenant = tenantRepository.GetByUserTenantId(command.IssuedBy);
            tenant.CreateUserAccount(command.IssuedBy,
                command.UserName, command.Password, UserRole.Editor, command.Email);

            tenantRepository.Update(tenant);
        }
    }
}
