using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4DalGenerator.Generators
{
    public class GeneratorParams
    {
        public IList<DataModel.DataTable> Tables { get; set; }
        public DataModel.DataTable Table { get; set; }

        public DalCreatorSettings Settings { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
