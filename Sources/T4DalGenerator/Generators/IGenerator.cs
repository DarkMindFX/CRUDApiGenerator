using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4DalGenerator.Generators
{
    public interface IGenerator
    {
        IList<string> Generate();
    }
}
