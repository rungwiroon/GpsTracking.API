using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public interface IEvent<T>
    {
        long GlobalSequenceNumber { get; }

        T Message { get; }
    }
}
