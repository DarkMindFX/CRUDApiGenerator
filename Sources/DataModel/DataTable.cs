using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAPI.DataModel
{
    public class DataTable
    {
        public string Name { get; set; }

        public IList<DataColumn> Columns { get; set; }

        public override string ToString()
        {
            return $"[{Name}]";
        }

        public bool HasColumn(string name)
        {
            return this.Columns.FirstOrDefault(c => c.Name.Equals(name)) != null;
        }
        
        public IList<DataColumn> ForeignKeys { get; set; }

        public bool ReferencesTable(string tableName)
        {
            bool result = false;
            if(ForeignKeys != null)
            {
                result = ForeignKeys.FirstOrDefault(fk => fk.FKRefTable.Equals(tableName)) != null;
            }
            return result;
        }
    }
}
