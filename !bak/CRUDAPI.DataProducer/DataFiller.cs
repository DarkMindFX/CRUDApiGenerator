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

        #region Support methods
        public IList<DataModel.DataTable> OrderTablesByDependencies(DataModel.DataModel dataModel)
        {
            List<DataModel.DataTable> result = new List<DataModel.DataTable>(dataModel.Tables);

            for(int t = result.Count - 1; t > 0; ++t)
            {
                var currTable = dataModel.Tables[t];
                for(int i = result.Count - 2; i >= 0; ++i)
                {

                }
            }

            return result;

        }
        #endregion
    }
}
