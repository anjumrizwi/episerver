using EPiServerDemoSite.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.WsFederation;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(EPiServerDemoSite.Startup))]

namespace EPiServerDemoSite
{
    public class Startup
    {
        private const string LogoutUrl = "/util/logout.aspx";

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity =
                        SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                },
                LogoutPath = new PathString("/Account/LogOff")
            });

            app.Map(LogoutUrl, map =>
            {
                map.Run(ctx =>
                {
                    ctx.Authentication.SignOut();
                    ctx.Response.Redirect("/");
                    return Task.FromResult(0);
                });
            });

            //Tell antiforgery to use the name claim
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when 
            // they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(
                DefaultAuthenticationTypes.TwoFactorCookie,
                TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such 
            // as phone or email. Once you check this option, your second step of 
            // verification during the login process will be remembered on the device where 
            // you logged in from. This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(
                DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in 
            // with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication();
        }

        /// <summary>
        /// http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-CMS/8/Security/mixed-mode-owin-authentication/
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth_todo(IAppBuilder app)
        {
            //This will configure cookie authentication at the following urls.  In those pages you are responsible for authentication and calling the OwinContext.Authentication.SignIn method to properly sign in the user
            // and  OwinContext.Authentication.SignOut to logout a user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Application",
                LoginPath = new PathString("/Login"),
                LogoutPath = new PathString("/Logout")
            });

            //This will set ADFS as the default authentication provider 
            app.SetDefaultSignInAsAuthenticationType(Microsoft.Owin.Security.WsFederation.WsFederationAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
           {
               AuthenticationType = Microsoft.Owin.Security.WsFederation.WsFederationAuthenticationDefaults.AuthenticationType
           });
            //Enable federated authentication
            app.UseWsFederationAuthentication(new Microsoft.Owin.Security.WsFederation.WsFederationAuthenticationOptions()
            {
                //Trusted URL to federation server meta data
                MetadataAddress = "https://devdc.dev.test/federationmetadata/2007-06/federationmetadata.xml",
                //Value of Wtreal must *exactly* match what is configured in the federation server
                Wtrealm = "http://localhost:61528/",
                Notifications = new Microsoft.Owin.Security.WsFederation.WsFederationAuthenticationNotifications()
                {
                    RedirectToIdentityProvider = (ctx) =>
                        {
                            //To avoid a redirect loop to the federation server send 403 when user is authenticated but does not have access
                            if (ctx.OwinContext.Response.StatusCode == 401 && ctx.OwinContext.Authentication.User.Identity.IsAuthenticated)
                            {
                                ctx.OwinContext.Response.StatusCode = 403;
                                ctx.HandleResponse();
                            }
                            return Task.FromResult(0);
                        },
                    SecurityTokenValidated = (ctx) =>
                        {
                            //Ignore scheme/host name in redirect Uri to make sure a redirect to HTTPS does not redirect back to HTTP
                            var redirectUri = new Uri(ctx.AuthenticationTicket.Properties.RedirectUri, UriKind.RelativeOrAbsolute);
                            if (redirectUri.IsAbsoluteUri)
                            {
                                ctx.AuthenticationTicket.Properties.RedirectUri = redirectUri.PathAndQuery;
                            }
                            //Sync user and the roles to EPiServer in the background
                            EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Security.SynchronizingUserService>().SynchronizeAsync(ctx.AuthenticationTicket.Identity);
                            return Task.FromResult(0);
                        }
                }
            });
            //Add stage marker to make sure WsFederation runs on Authenticate (before URL Authorization and virtual roles)
            app.UseStageMarker(PipelineStage.Authenticate);

            //Remap logout to a federated logout
            app.Map(LogoutUrl, map =>
            {
                map.Run(ctx =>
                {
                    ctx.Authentication.SignOut();
                    return Task.FromResult(0);
                });
            });

            //Tell antiforgery to use the name claim
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
    }
}
