// Ignore Spelling: Req

using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.FluentValidation;
using ServiceStack.Web;
using ServiceStack.Host.NetCore;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Int2Roman.ServiceModel;
using System.Data;
using ServiceStack.Caching;
using Microsoft.AspNetCore.Identity;
using ServiceStack.Validation;

[assembly: HostingStartup(typeof(Int2Roman.ConfigureAuth))]

namespace Int2Roman
{
    // Add any additional metadata properties you want to store in the Users Typed Session
    public class CustomUserSession : AuthUserSession
    {
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            base.OnAuthenticated(authService, session, tokens, authInfo);
        }
    }
 
    public class ConfigureAuth : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder) => builder
            .ConfigureServices(services => {
                //services.AddSingleton<ICacheClient>(new MemoryCacheClient()); //Store User Sessions in Memory Cache (default)
            })
            .ConfigureAppHost(appHost => {
                var appSettings = appHost.AppSettings;
                appHost.Plugins.Add(new AuthFeature(() => new CustomUserSession(),
                    new IAuthProvider[] {
                        new NetCoreIdentityAuthProvider(appSettings) {
                            AdminRoles = [ "Manager" ], // Automatically Assign additional roles to Admin Users                            
                        }, /* Use ServiceStack Auth in MVC */
                        
                    }));

                appHost.Plugins.Add(new RegistrationFeature()); //Enable /register Service
               

                ////////Store User Sessions in Memory
                //////appHost.Register<ICacheClient>(new MemoryCacheClient());
                ////////Store Authenticated Users in Memory
                //////appHost.Register<IAuthRepository>(new InMemoryAuthRepository());

                // Handles validation manually
                appHost.Plugins.RemoveAll(x => x is ValidationFeature);

            });
    }
}
