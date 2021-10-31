using Identity.DTOs.LogIn.Responses;
using Identity.Models.Results;
using MediatR;
using MyFirstOpenIddict.Common.Web.Results;
using System.Text.Json.Serialization;

namespace Identity.DTOs.LogIn.Requests
{
    /// <summary>
    /// Request of login
    /// </summary>
    public class LogInRequest : IRequest<WebServiceResult<LogInResult>>
    {
        /// <summary>
        /// Username
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }

}
