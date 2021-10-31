using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PPT.DTO
{
    public class LoginRequest
    {
        [JsonPropertyName("Login")]
        public string Login
        {
            get;
            set;
        }

        [JsonPropertyName("Password")]
        public string Password
        {
            get;
            set;
        }
    }

    public class LoginResponse
    {
        [JsonPropertyName("User")]
        public User User
        {
            get; set;
        }

        [JsonPropertyName("Token")]
        public string Token
        {
            get; set;
        }

        [JsonPropertyName("Expires")]
        public DateTime Expires
        {
            get; set;
        }
    }
}
