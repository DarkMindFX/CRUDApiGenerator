using CRUDAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.Generators
{
    public class GeneratorParams
    {
        public IList<CRUDAPI.DataModel.DataTable> Tables { get; set; }
        public CRUDAPI.DataModel.DataTable Table { get; set; }

        public DalCreatorSettings Settings { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
