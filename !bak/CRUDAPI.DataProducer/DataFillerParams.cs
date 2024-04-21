using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDAPI.DataModel;
using CRUDAPI.Interfaces;

namespace CRUDAPI.DataProducer
{
    public class DataFillerParams
    {
        public DataModel.DataModel Model { get; set; }

        public IDictionary<string, IDataProducer> DataProducerParams { get; set; }

        public string ConnectionString { get; set; }
    }
}
