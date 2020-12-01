using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public interface IQueryBus
    {
        U Query<T, U>(IQuery<U> query);
    }
}
