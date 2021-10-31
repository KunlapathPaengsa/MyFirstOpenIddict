using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Identity.DTOs.LogIn.Responses
{
    /// <summary>
    /// Response of login
    /// </summary>
    public class LogInResponse
    {
        /// <summary>
        /// Access token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Password expired status. Return true is expire, false not expire.
        /// </summary>
        [JsonPropertyName("is_password_expired")]
        public bool IsPasswordExpired { get; set; }

        /// <summary>
        /// Token for refresh.
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

    }
}
