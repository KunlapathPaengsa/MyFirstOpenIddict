using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace Identity.Models.Results
{
    public class LogInResult
    {
        public LogInOptions Options { get; set; }
        public List<Claim> Claims { get; set; }

        public class LogInOptions
        {
            [JsonPropertyName("is_password_expired")]
            public bool IsPasswordExpired { get; set; }
        }
    }
}
