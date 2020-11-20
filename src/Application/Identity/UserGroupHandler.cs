using Core.Domain.Identity.Commands;
using GpsTracking.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Accounts
{
    public class CreateUserGroupHandler :
        ICommandHandler<CreateUserGroup>,
        ICommandHandler<RenameUserGroup>,
        ICommandHandler<DeleteUserGroup>
    {
        public void Handle(CreateUserGroup command)
        {
            throw new NotImplementedException();
        }

        public void Handle(RenameUserGroup command)
        {
            throw new NotImplementedException();
        }

        public void Handle(DeleteUserGroup command)
        {
            throw new NotImplementedException();
        }
    }
}
