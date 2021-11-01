//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using IC.Common.Helpers;
//using IC.Common.UserPrincipal;
//using IC.Common.Web.UserPrincipal;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using MyFirstOpenIddict.Common.Helpers;
//using MyFirstOpenIddict.Common.Web.Api.Helpers;
//using MyFirstOpenIddict.Common.Web.Api.Providers.Authorizations;
//using MyFirstOpenIddict.Common.Web.Helpers;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Attributes;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Configurations;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Handlers.Client;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Handlers.Server;
//using MyFirstOpenIddict.Common.Web.OpenIddict.Helpers;
//using OpenIddict.Validation;
//using OpenIddict.Validation.AspNetCore;
//using static OpenIddict.Server.OpenIddictServerEvents;

//namespace MyFirstOpenIddict.Common.Web.OpenIddict.DependencyInjection
//{
//    public static class OpenIddictEventHandlerExtensions
//    {
//        /// <summary>
//        /// Customize standard response. 
//        /// Customize event handler of <see cref="ApplyTokenResponseContext"/>.
//        /// </summary>
//        /// <param name="builder"></param>
//        /// <returns></returns>
//        public static OpenIddictServerBuilder AddStandardBaseResponseHandler(this OpenIddictServerBuilder builder)
//        {
//            return builder.AddEventHandler<ApplyTokenResponseContext>(config =>
//            {
//                config.UseSingletonHandler<CustomizeApplyTokenResponseContextHandler>();
//            });
//        }

//        /// <summary>
//        /// Customize <see cref="ProcessSignInContext"/> of OpenIddict.
//        /// </summary>
//        /// <param name="builder">The OpenIddictServerBuilder</param>
//        /// <param name="loginOptionTyp">The login option type.</param>
//        /// <returns></returns>
//        public static OpenIddictServerBuilder AddCustomProcessSignInContextHandler(this OpenIddictServerBuilder builder
//            , Type loginOptionTyp)
//        {
//            return builder.AddEventHandler<ProcessSignInContext>(config =>
//            {
//                config.UseSingletonHandler(new CustomizeProcessSignInContextHandler(loginOptionTyp));
//            });
//        }

//        /// <summary>
//        /// Customize <see cref="HandleIntrospectionRequestContext"/> of OpenIddict.
//        /// </summary>
//        /// <param name="builder">The OpenIddictServerBuilder</param>
//        /// <returns></returns>
//        public static OpenIddictServerBuilder AddCustomHandleIntrospectionRequestContextHandler(this OpenIddictServerBuilder builder)
//        {
//            return builder.AddEventHandler<HandleIntrospectionRequestContext>(config =>
//            {
//                config.UseSingletonHandler<CustomizeHandleIntrospectionRequestContextHadler>();
//            });
//        }

//        /// <summary>
//        /// Customize <see cref="OpenIddictValidationEvents.ProcessChallengeContext"/> for return result.
//        /// </summary>
//        /// <param name="builder">The OpenIddictValidationBuilder</param>
//        /// <returns></returns>
//        public static OpenIddictValidationBuilder AddCustomValidationProcessChallengeContextHandler(this OpenIddictValidationBuilder builder)
//            => builder.AddEventHandler<OpenIddictValidationEvents.ProcessChallengeContext>(config =>
//            {
//                config.UseSingletonHandler<CustomizeProcessChallengeContextHandler>();
//            });

//        /// <summary>
//        /// Use OpenIddict with Introspection for validation token by <see cref="IntrospectionConfiguration"/>.
//        /// </summary>
//        /// <param name="services">The service collections.</param>
//        /// <param name="configuration">The configuartion.</param>
//        /// <returns></returns>
//        public static IServiceCollection AddOpenIddictIntrospectionForClient(this IServiceCollection services)
//        {
//            var introspectionConfig = new IntrospectionConfiguration();
//            using (var serviceProvider = services.BuildServiceProvider())
//            {
//                var configuration = serviceProvider.GetService<IConfiguration>();
//                var environment = serviceProvider.GetService<IHostEnvironment>();
//                if (MyFirstOpenIddictHelper.IsOpenAuthenticationOnLocal(configuration, environment))
//                {
//                    return services;
//                }
//                configuration.GetSection(nameof(IntrospectionConfiguration)).Bind(introspectionConfig);
//            }
//            return services.AddOpenIddictIntrospectionForClient(introspectionConfig);
//        }

//        /// <summary>
//        /// Use OpenIddict with Introspection for validation token by <see cref="IntrospectionConfiguration"/>. 
//        /// Function support gateway api only.
//        /// </summary>
//        /// <param name="services">The service collections.</param>
//        /// <param name="configuration">The configuartion.</param>
//        /// <returns></returns>
//        public static IServiceCollection AddOpenIddictIntrospectionOnGatewayAPI(this IServiceCollection services)
//        {
//            var introspectionConfig = new IntrospectionConfiguration();
//            using (var serviceProvider = services.BuildServiceProvider())
//            {
//                var configuration = serviceProvider.GetService<IConfiguration>();
//                var environment = serviceProvider.GetService<IHostEnvironment>();
//                configuration.GetSection(nameof(IntrospectionConfiguration)).Bind(introspectionConfig);
//            }
//            return services.AddOpenIddictIntrospectionForClient(introspectionConfig);
//        }

//        /// <summary>
//        /// Use OpenIddict with Introspection for validation token by <see cref="IntrospectionConfiguration"/>.
//        /// </summary>
//        /// <param name="services">The service collections.</param>
//        /// <param name="configuration">The configuartion.</param>
//        /// <returns></returns>
//        public static IServiceCollection AddOpenIddictIntrospectionForClient(this IServiceCollection services
//            , IntrospectionConfiguration introspectionConfig)
//        {
//            if (introspectionConfig.IsNullable())
//            {
//                throw new ArgumentNullException(nameof(introspectionConfig));
//            }

//            if (introspectionConfig.Issuer.IsEmpty())
//            {
//                throw new ArgumentNullException(nameof(introspectionConfig.Issuer));
//            }

//            if (introspectionConfig.ClientId.IsEmpty())
//            {
//                throw new ArgumentNullException(nameof(introspectionConfig.ClientId));
//            }

//            if (introspectionConfig.ClientSecret.IsEmpty())
//            {
//                throw new ArgumentNullException(nameof(introspectionConfig.ClientSecret));
//            }

//            services.AddAuthentication(options =>
//            {
//                options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
//            });

//            services.AddOpenIddict().AddValidation(options =>
//            {
//                options.SetIssuer(introspectionConfig.Issuer);
//                if (introspectionConfig.Audiences.Any())
//                {
//                    options.AddAudiences(introspectionConfig.Audiences.ToArray());
//                }

//                options.UseIntrospection()
//                       .SetClientId(introspectionConfig.ClientId)
//                       .SetClientSecret(introspectionConfig.ClientSecret)
//                       .AddCustomValidationProcessChallengeContextHandler();

//                // Register the System.Net.Http integration.
//                options.UseSystemNetHttp();

//                // Register the ASP.NET Core host.
//                options.UseAspNetCore();
//            });

//            return services;
//        }

//        /// <summary>
//        /// Use global authorization.
//        /// </summary>
//        /// <param name="services">The service collection.</param>
//        /// <returns></returns>
//        public static IMvcBuilder AddOpenIddictGlobalAuthorization(this IServiceCollection services)
//        {
//            return services.AddControllers(options =>
//            {
//                options.Filters.Add(new AuthorizeFilter(new List<IAuthorizeData> { new OpenIddictAuthorizeAttribute() }));
//            });
//        }

//        /// <summary>
//        /// Add authorization with client credential.
//        /// </summary>
//        /// <param name="services"></param>
//        /// <returns></returns>
//        public static IServiceCollection AddOpenIddictClientAuthorization(this IServiceCollection services)
//        {
//            using (var serviceProvider = services.BuildServiceProvider())
//            {
//                var configuration = serviceProvider.GetService<IConfiguration>();
//                var environment = serviceProvider.GetService<IHostEnvironment>();

//                //ถ้าเป็น local และ ปิดการใช้งาน authentication
//                if (MyFirstOpenIddictHelper.IsOpenAuthenticationOnLocal(configuration, environment))
//                {
//                    return services;
//                }

//                var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
//                var httpContenxtAccessor = serviceProvider.GetService<IHttpContextAccessor>();

//                var authorizationConfiguration = AuthorizeApiConfigurationHelper.GetAuthorizeConfiguration(configuration, OpenIddictDefaultDatas.SectionOfApiConfigName);
//                var authorizationApiProvider = new AuthorizationApiProvider(httpClientFactory, httpContenxtAccessor);

//                var securityResult = Task.Run(async () => await authorizationApiProvider.GetClientIdClientSecretAsync(authorizationConfiguration)).Result;
//                var introspectionConfiguration = GetIntrospectionConfiguration(configuration, securityResult);

//                services.AddOpenIddictIntrospectionForClient(introspectionConfiguration);
//            }

//            return services;
//        }

//        #region Internal methods
//        internal static IntrospectionConfiguration GetIntrospectionConfiguration(IConfiguration configuration
//            , (string ClientId, string ClientSecret) securityResult)
//        {
//            var introspectionConfig = new IntrospectionConfiguration
//            {
//                ClientId = securityResult.ClientId,
//                ClientSecret = securityResult.ClientSecret
//            };
//            configuration.GetSection(nameof(IntrospectionConfiguration)).Bind(introspectionConfig);
//            return introspectionConfig;
//        }

//        #endregion

//    }
//}
