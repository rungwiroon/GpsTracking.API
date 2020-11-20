using System;
using Core.Domain.Identity;
using Core.Domain.Identity.Commands;

namespace GpsTracking.Application.Accounts
{
    public class AccountHandler : ICommandHandler<RegisterAccount>
    {
        private readonly IAccountRepository accountRepository;

        public AccountHandler(
            IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public void Handle(RegisterAccount command)
        {
            var newId = 1111;
            var (account, _) = Tenant.CreateAccount(newId, 
                command.UserName, command.Password, command.Email);

            accountRepository.Create(account);
        }
    }
}
