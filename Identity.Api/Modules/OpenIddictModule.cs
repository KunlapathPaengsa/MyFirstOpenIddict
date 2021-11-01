using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyFirstOpenIddict.Common.Web.OpenIddict.Configurations;
using Quartz;
using static OpenIddict.Abstractions.OpenIddictConstants;


namespace Identity.Api.Modules
{
    /// <summary>
    /// Register OpenIddict module.
    /// </summary>
    public class OpenIddictModule : Module
    {
        /// <inheritdoc/>
        public OpenIddictModule(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            var services = new ServiceCollection();
            var authorizeSettings = GetAuthorizeSettings();

            // OpenIddict offers native integration with Quartz.NET to perform scheduled tasks
            // (like pruning orphaned authorizations/tokens from the database) at regular intervals.
            services.AddQuartz(options =>
           {
               options.UseMicrosoftDependencyInjectionJobFactory();
               options.UseSimpleTypeLoader();
               options.UseInMemoryStore();
           });

            // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

            services.AddOpenIddict()
                    // Register the OpenIddict core components.
                    .AddCore(options =>
                    {
                        // Configure OpenIddict to use the Entity Framework Core stores and models.
                        // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                        options.UseEntityFrameworkCore()
                               .UseDbContext<IdentityDbContext>();

                        // Enable Quartz.NET integration.
                        options.UseQuartz();
                    })
                    // Register the OpenIddict server components.
                    .AddServer(options =>
                    {
                        // Enable the token endpoint.
                        options.SetTokenEndpointUris("/connect/token")
                               .SetIntrospectionEndpointUris("/connect/introspect");

                        // Mark the "email", "profile" and "roles" scopes as supported scopes.
                        options.RegisterScopes(Scopes.Email, Scopes.Profile, Scopes.Roles, Scopes.OfflineAccess);

                        // Enable the client credentials flow.
                        options.AllowPasswordFlow()
                               .AllowRefreshTokenFlow();

                        options.AcceptAnonymousClients();

                        //Set Lifetime of access token and refresh token
                        options.SetAccessTokenLifetime(TimeSpan.FromSeconds(authorizeSettings.AccessTokenLifetimeOfSeconds))
                               .SetRefreshTokenLifetime(TimeSpan.FromSeconds(authorizeSettings.RefreshTokenLifetimeOfSeconds))
                               .SetRefreshTokenReuseLeeway(TimeSpan.FromSeconds(authorizeSettings.RefreshTokenLifetimeOfSeconds));

                        // Register the signing and encryption credentials.
                        options.AddDevelopmentEncryptionCertificate()
                               .AddDevelopmentSigningCertificate();

                        // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                        options.UseAspNetCore()
                               .EnableTokenEndpointPassthrough()
                               .EnableStatusCodePagesIntegration();

                        //options.DisableAccessTokenEncryption();
                        options.UseDataProtection()
                               .PreferDefaultAccessTokenFormat()
                               .PreferDefaultRefreshTokenFormat();

                        options.UseReferenceAccessTokens()
                               .UseReferenceRefreshTokens();

                    })
                    // Register the OpenIddict validation components.
                    .AddValidation(options =>
                    {
                        // Validate token.
                        options.EnableTokenEntryValidation();

                        // Import the configuration from the local OpenIddict server instance.
                        options.UseLocalServer();

                        // Register the ASP.NET Core host.
                        options.UseAspNetCore();
                    });

            builder.Populate(services);
        }

        private AuthorizeSettings GetAuthorizeSettings()
        {
            var settings = new AuthorizeSettings();
            Configuration.GetSection(nameof(AuthorizeSettings)).Bind(settings);
            return settings;
        }
    }
}
