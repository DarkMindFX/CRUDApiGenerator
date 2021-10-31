using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PPT.DTO
{
    public class HealthResponse
    {
        [JsonPropertyName("Timestamp")]
        public DateTime Timestamp
        {
            get;
            set;
        }

        [JsonPropertyName("Message")]
        public string Message
        {
            get;
            set;
        }

        [JsonPropertyName("Diagnostics")]
        public Dictionary<string, object> Diagnostics
        {
            get;
            set;
        }
    }
}
