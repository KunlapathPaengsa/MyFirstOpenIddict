//using IC.Common.Helpers;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Http;
//using MyFirstOpenIddict.Common.Security;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Attributes;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Requests;

//namespace MyFirstOpenIddict.Common.Web.OpenIddict.DependencyInjection
//{
//    public static class OpenIddictExtensions
//    {
//        public static TwoFactorAuthenticationRequest GetTwoFactorAuthenticationRequest(this HttpContext context)
//        {
//            var openIddictRequest = context.GetOpenIddictServerRequest();
//            if (openIddictRequest.IsNullable())
//            {
//                return null;
//            };

//            var headerValue = context.Request.Headers[OpenIddictDefaultDatas.AuthorizationHeaderKey].ToString();
//            var tokenData = TwoFactorAuthorizationAttribute.GetTokenData(headerValue);

//            bool isEmailAuthentication = openIddictRequest.HasParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsEmailAuthentication)
//                ? (bool)openIddictRequest.GetParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsEmailAuthentication) : false;

//            bool isGoogleAuthentication = openIddictRequest.HasParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsGoogleAuthentication)
//                ? (bool)openIddictRequest.GetParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsGoogleAuthentication) : false;

//            bool isSMSAuthentication = openIddictRequest.HasParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsSMSAuthentication)
//                ? (bool)openIddictRequest.GetParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.IsSMSAuthentication) : false;

//            var data = TwoFactorAuthenticationSecurityGenerate.GetDataByToken(tokenData.AccessToken);
//            return new TwoFactorAuthenticationRequest
//            {
//                MemberId = data.UserId,
//                TwoFactorAccessToken = tokenData.AccessToken,
//                TwoFactorCode = openIddictRequest.GetParameter(OpenIddictDefaultDatas.TwoFactorParameterNames.TwoFactorCode).Value.ToString(),
//                IsEmailAuthentication = isEmailAuthentication,
//                IsGoogleAuthentication = isGoogleAuthentication,
//                IsSMSAuthentication = isSMSAuthentication
//            };
//        }
//    }
//}
