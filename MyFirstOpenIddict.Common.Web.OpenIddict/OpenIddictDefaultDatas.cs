using System.Collections.Generic;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MyFirstOpenIddict.Common.Web.OpenIddict
{
    public class OpenIddictDefaultDatas
    {
        public const string SectionOfApiConfigName = "ApiConfigName";
        public const string AuthorizationHeaderKey = "Authorization";

        public class IdentityWorker
        {
            public static HashSet<string> DefaultScopes => new HashSet<string>
            {
                Permissions.Endpoints.Token,
                Permissions.Endpoints.Introspection,
                Permissions.GrantTypes.ClientCredentials,
                Permissions.GrantTypes.RefreshToken
            };
        }

        public class CustomGrantTypes
        {
            public const string TwoFactorAuthenticationValue = "twofactor";
            public const string TwoFactorAuthentication = Permissions.Prefixes.GrantType + "twofactor";
        }

        public class CustomFlowTypes
        {
            public const string TwoFactorAuthenticationFlow = "twofactor";
        }

        public class TwoFactorParameterNames
        {
            public const string TwoFactorCode = "two_factor_code";
            public const string IsGoogleAuthentication = "is_google_authentication";
            public const string IsEmailAuthentication = "is_email_authentication";
            public const string IsSMSAuthentication = "is_sms_authentication";
        }
    }
}