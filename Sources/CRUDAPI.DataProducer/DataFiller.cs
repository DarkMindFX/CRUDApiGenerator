using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataProducer
{
    public class DataFiller
    {
        private DataFillerParams _fillerParams = null;
        public void Init(DataFillerParams fillerParams)
        {
            _fillerParams = fillerParams;
        }

        public void PopulateModel()
        {

        }
    }
}
