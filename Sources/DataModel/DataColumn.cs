using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataColumn
    {
        public string Name { get; set; }

        public bool IsIdentity { get; set; }

        public bool IsNullable { get; set; }

        public bool IsComputed { get; set; }

        public bool IsPK { get; set; }

        public DataType Type { get; set; }

        public string FKRefTable { get; set; }

        public string FKRefColumn { get; set; }

        public DataType FKRefColumnType { get; set; }

        public override string ToString()
        {
            return $"[{Name}] : {Type.SqlType + (!string.IsNullOrEmpty(FKRefTable) ? $", FK -> {FKRefTable}.{FKRefColumn}"  : string.Empty)} ";
        }


    }
}
