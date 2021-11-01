//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using static OpenIddict.Abstractions.OpenIddictConstants;

//namespace MyFirstOpenIddict.Common.Web.OpenIddict.Attributes
//{
//    /// <summary>
//    /// Validation token of two-factor authentication. 
//    /// Support grant type is : 'twofactor'
//    /// </summary>
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//    public class TwoFactorAuthorizationAttribute : Attribute, IAuthorizationFilter
//    {
//        public void OnAuthorization(AuthorizationFilterContext context)
//        {
//            //ถ้า grant type เป็น password ไม่ต้องเช็ค เพราะจะใช้ access token คนละชุดกัน
//            if (ValidationPasswordGrantType(context.HttpContext))
//            {
//                return;
//            }

//            //ตรวจสอบ grant type ว่าเป็น twofactor หรือไม่
//            if (!ValidationGrantTypeTwoFactor(context.HttpContext))
//            {
//                context.Result = new OkObjectResult(new BaseResponseResult
//                {
//                    StatusCode = 401,
//                    IsSuccess = false,
//                    Errors = new List<ErrorResponseResult>
//                    {
//                        new ErrorResponseResult
//                        {
//                            Id = "401",
//                            Code = "Unauthorized",
//                            Message = "Grant type missing or grant type not support."
//                        }
//                    }
//                });
//                return;
//            }

//            string headerValue = GetAuthorizationHeader(context.HttpContext);
//            if (headerValue.IsEmpty())
//            {
//                context.Result = UnauthorizationResult();
//                return;
//            }

//            if (!headerValue.Contains(TokenTypes.Bearer))
//            {
//                context.Result = UnauthorizationResult();
//                return;
//            }

//            var tokenData = GetTokenData(headerValue);
//            if (!TwoFactorAuthenticationSecurityGenerate.ValidateToken(tokenData.AccessToken))
//            {
//                context.Result = UnauthorizationResult();
//                return;
//            }
//            //Register claims into HttpContext, CurrentPrincipal into thread.
//            RegisterClaims(tokenData.AccessToken, context.HttpContext);
//        }

//        private string GetAuthorizationHeader(HttpContext context)
//        {
//            if (!context.Request.Headers.Any(w => w.Key == OpenIddictDefaultDatas.AuthorizationHeaderKey))
//            {
//                return string.Empty;
//            }
//            return context.Request.Headers[OpenIddictDefaultDatas.AuthorizationHeaderKey].ToString();
//        }

//        internal static (string Schema, string AccessToken) GetTokenData(string token)
//        {
//            string[] values = token.Split(" ");
//            return (values[0], values[1]);
//        }

//        private OkObjectResult UnauthorizationResult()
//            => new OkObjectResult(new BaseResponseResult
//            {
//                StatusCode = 401,
//                IsSuccess = false,
//                Errors = new List<ErrorResponseResult>
//                {
//                    new ErrorResponseResult
//                    {
//                        Id = "401",
//                        Code = "Unauthorized",
//                        Message = "Unauthorized token missing, token invalid or token expired."
//                    }
//                }
//            });

//        private bool ValidationGrantTypeTwoFactor(HttpContext context)
//        {
//            if (context.Request.ContentType.IsEmpty())
//            {
//                return false;
//            }

//            if (!context.Request.Form.Any(w => w.Key == Parameters.GrantType))
//            {
//                return false;
//            }

//            return context.Request.Form[Parameters.GrantType].ToString() == OpenIddictDefaultDatas.CustomGrantTypes.TwoFactorAuthenticationValue;
//        }

//        private bool ValidationPasswordGrantType(HttpContext context)
//        {
//            if (context.Request.ContentType.IsEmpty())
//            {
//                return false;
//            }

//            if (!context.Request.Form.Any(w => w.Key == Parameters.GrantType))
//            {
//                return false;
//            }

//            var grantType = context.Request.Form[Parameters.GrantType].ToString();
//            return grantType == GrantTypes.Password || grantType == GrantTypes.RefreshToken;
//        }

//        private void RegisterClaims(string token, HttpContext context)
//        {
//            var userData = TwoFactorAuthenticationSecurityGenerate.GetDataByToken(token);
//            var claims = new List<Claim>
//            {
//                new Claim(Claims.Subject, userData.UserId.ToString()),
//                new Claim(IdentityClaimType.UserName, userData.Username),
//                new Claim(Claims.Username, userData.Username),
//                new Claim(Claims.Name, userData.Username),
//                new Claim(Claims.Email, userData.Username)
//            };
//            ThreadPrincipal.Register(claims);
//            WebPrincipal.Register(context, claims);
//        }
//    }
//}
