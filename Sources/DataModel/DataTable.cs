using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
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
    }
}
