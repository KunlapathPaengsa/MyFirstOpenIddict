using System;

namespace MyFirstOpenIddict.Common.Web.OpenIddict.Requests
{
    /// <summary>
    /// Request for two-factor authentication.
    /// </summary>
    public class TwoFactorAuthenticationRequest
    {
        /// <summary>
        /// Access token of two-factor
        /// </summary>
        public string TwoFactorAccessToken { get; set; }

        /// <summary>
        /// Member id.
        /// </summary>
        public Guid MemberId { get; set; }

        /// <summary>
        /// Code for validation two-factor authentication.
        /// </summary>
        public string TwoFactorCode { get; set; }

        /// <summary>
        /// Status of google authentication
        /// </summary>
        public bool IsGoogleAuthentication { get; set; }

        /// <summary>
        /// Status of email authentication
        /// </summary>
        public bool IsEmailAuthentication { get; set; }

        /// <summary>
        /// Status of SMS authentication
        /// </summary>
        public bool IsSMSAuthentication { get; set; }
    }
}
