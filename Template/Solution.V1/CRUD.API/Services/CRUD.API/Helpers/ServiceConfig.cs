using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PPT.PhotoPrint.API.Helpers
{
    public class ServiceConfig
    {
        [JsonPropertyName("DALType")]
        public string DALType { get; set; }


        [JsonPropertyName("DALInitParams")]
        public Dictionary<string, string> DALInitParams { get; set; }
    }
}
