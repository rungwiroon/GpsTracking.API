using Domain;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public interface ICommandBus
    {
        Unit Send(ICommand command);
    }
}
