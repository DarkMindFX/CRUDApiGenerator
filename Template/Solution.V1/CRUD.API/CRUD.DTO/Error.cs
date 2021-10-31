using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PPT.DTO
{
    public class Error
    {
        [JsonPropertyName("Message")]
        public string Message
        {
            get;
            set;
        }

        [JsonPropertyName("Code")]
        public int Code
        {
            get;
            set;
        }

    }
}
