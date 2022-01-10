using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Services.Common.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
