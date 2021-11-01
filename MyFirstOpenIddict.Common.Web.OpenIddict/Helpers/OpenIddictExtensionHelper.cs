using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace MyFirstOpenIddict.Common.Web.OpenIddict.Helpers
{
    public static class OpenIddictExtensionHelper
    {
        public static List<Claim> GetClaimRoleName(this IEnumerable<Claim> claims)
           => claims.Where(w => w.Type == Claims.Role).ToList();

        public static List<Claim> GetClaimRoleId(this IEnumerable<Claim> claims)
           => claims.Where(w => w.Type == CustomClaimType.RoleId).ToList();

        public static Claim GetClaimEmail(this IEnumerable<Claim> claims)
            => claims.FirstOrDefault(w => w.Type == Claims.Email);

        public static Claim GetClaimUserId(this IEnumerable<Claim> claims)
            => claims.FirstOrDefault(w => w.Type == Claims.Subject);

        public static Claim GetClaimUsername(this IEnumerable<Claim> claims)
            => claims.FirstOrDefault(w => w.Type == Claims.Username);

        public static Claim GetClaimName(this IEnumerable<Claim> claims)
            => claims.FirstOrDefault(w => w.Type == Claims.Name);

        public static List<string> GetRoleName(this IEnumerable<Claim> claims)
           => claims.GetClaimRoleName().Select(s => s.Value).ToList();

        public static List<string> GetRoleId(this IEnumerable<Claim> claims)
           => claims.GetClaimRoleId().Select(s => s.Value).ToList();

        public static string GetEmail(this IEnumerable<Claim> claims)
            => claims.GetClaimEmail()?.Value;

        public static string GetUserId(this IEnumerable<Claim> claims)
            => claims.GetClaimUserId()?.Value;

        public static string GetUsername(this IEnumerable<Claim> claims)
            => claims.GetClaimUsername()?.Value;

        public static string GetName(this IEnumerable<Claim> claims)
            => claims.GetClaimName()?.Value;

        /// <summary>
        /// Validataion grant_type is two-factor authentication.
        /// </summary>
        /// <param name="request">The request for validation</param>
        /// <returns></returns>
        public static bool IsTwoFactorGranType(this OpenIddictRequest request)
            => request.GrantType == OpenIddictDefaultDatas.CustomGrantTypes.TwoFactorAuthenticationValue;
    }

}
