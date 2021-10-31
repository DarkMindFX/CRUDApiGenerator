using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataType
    {
        public string SqlType { get; set; }

        public int? CharMaxLength { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }
    }
}
