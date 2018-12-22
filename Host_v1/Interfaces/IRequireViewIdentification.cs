using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host_v1.Interfaces
{
    public interface IRequireViewIdentification
    {
        Guid ViewID { get; }
    }
}
