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

        /// <summary>
        /// This methods orders tables based on their FK relations. Tables with less FK-s are put at the beginning on the list. 
        /// Tables with FK-s will be put after the tables their are referencing.
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public IList<DataModel.DataTable> OrderTablesByDependencies(DataModel.DataModel dataModel)
        {
            List<DataModel.DataTable> result = new List<DataModel.DataTable>(dataModel.Tables);

            for(int t = result.Count - 1; t > 0; ++t)
            {
                var currTable = dataModel.Tables[t];
                for(int i = result.Count - 2; i >= 0; ++i)
                {
                    if (!currTable.ReferencesTable(dataModel.Tables[i].Name))
                    {
                        // swapping table positions
                        dataModel.Tables[t] = dataModel.Tables[i];
                        dataModel.Tables[i] = currTable;
                    }
                }
            }

            return result;

        }
        #endregion
    }
}
