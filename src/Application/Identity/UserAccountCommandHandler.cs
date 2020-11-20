using Core.Domain.Identity;
using Core.Domain.Identity.Commands;
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
        private readonly IAccountRepository accountRepository;

        public UserAccountHandler(
            IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Handle(CreateEditorAccount command)
        {
            var account = accountRepository.GetByUserTenantId(command.IssuedBy);
            account.CreateUserAccount(command.IssuedBy,
                command.UserName, command.Password, UserRole.Editor, command.Email);

            accountRepository.Update(account);
        }
    }
}
