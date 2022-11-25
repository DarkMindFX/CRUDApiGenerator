using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.API.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int SessionTimeout { get; set; }
    }
}
