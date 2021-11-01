using System;
using Microsoft.AspNetCore.Authorization;
using OpenIddict.Validation.AspNetCore;

namespace MyFirstOpenIddict.Common.Web.OpenIddict.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OpenIddictAuthorizeAttribute : AuthorizeAttribute
    {
        public OpenIddictAuthorizeAttribute()
        {
            AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        }
    }
}
